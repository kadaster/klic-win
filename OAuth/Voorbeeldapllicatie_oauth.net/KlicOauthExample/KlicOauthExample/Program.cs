using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlicOauthExample
{
    public static class Program
    {
        #region Public Methods

        public static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }

        #endregion Public Methods

        #region Private Methods

        private static async Task DoTestCall(string accessToken, string endPoint)
        {
            Console.WriteLine($"Test api call met verkregen access token {accessToken}");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await client.GetAsync(endPoint);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        private static async Task GetAccessToken(TokenCollection tokens)
        {
            Console.WriteLine("Access token wordt opgevraagd...");
            string tokenUri = tokens.AuthorizationEndpoint + "/token";
            var content = new StringContent
            (
                "code=" + tokens.AuthorizationCode
                + "&client_id=" + tokens.ClientId
                + "&client_secret=" + tokens.ClientSecret
                + "&redirect_uri=" + tokens.RedirectUri
                + "&grant_type=" + "authorization_code"
            );
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var client = new HttpClient();
            DateTime startTime = DateTime.Now;
            HttpResponseMessage response = await client.PostAsync(tokenUri, content);
            string result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(result));
            var serializer = new DataContractJsonSerializer(typeof(RequestTokenResponse));
            var tokenResponse = (RequestTokenResponse)serializer.ReadObject(stream);
            tokens.AccessToken = tokenResponse.AccessToken;
            tokens.RefreshToken = tokenResponse.RefreshToken;
            tokens.ValidUntil = startTime.AddSeconds(int.Parse(tokenResponse.ExpiresIn));
            Console.WriteLine($"Access token en refresh token ontvangen");
        }

        /// <summary>
        /// Haalt een nieuwe Authorisation token op
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private static async Task GetAuthorizationToken(TokenCollection tokens)
        {
            Console.WriteLine($"Authorisation wordt opgevraagd via browser...");
            // Create an authorization code request.
            var CodeReceiver = new LocalServerCodeReceiver();
            string authorizationEndpoint = tokens.AuthorizationEndpoint + "/authorize";
            CodeReceiver.RedirectUri = tokens.RedirectUri;
            string parameters = $"response_type=code&client_id={tokens.ClientId}&client_secret={tokens.ClientSecret}&redirect_uri={tokens.RedirectUri}&scope={tokens.Scope}";
            CancellationToken taskCancellationToken;
            // Receive the code.
            var response = await CodeReceiver.ReceiveCodeAsync($"{authorizationEndpoint}?{parameters}", taskCancellationToken)
                .ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(response))
            {
                throw new ApplicationException($"Authorisation code ophalen is mislukt.");
            }
            Console.WriteLine($"Authorisation code {response} ontvangen");
            tokens.AuthorizationCode = response;
        }

        private static TokenCollection LoadTokens()
        {
            var tokenRepo = new TokenRepository();
            if (!File.Exists(tokenRepo.ConfigFileName))
            {
                //Lege config file aanmaken
                try
                {
                    tokenRepo.SaveTokens(new TokenCollection());
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Kan config {tokenRepo.ConfigFileName} niet aanmaken.", ex);
                }
            }
            TokenCollection tokens = tokenRepo.LoadTokens();
            if (!tokens.HasClientId)
            {
                throw new ApplicationException($"Geen ClientId en ClientSecret gevonden. Vraag deze aan bij het kadaster en voeg deze toe aan {tokenRepo.ConfigFileName}");
            }
            return tokens;
        }

        private static async Task MainAsync()
        {
            try
            {
                //Uitschakelen van certificate validation. Niet gebruiken in productie code!
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                TokenCollection tokens = LoadTokens();
                if (!tokens.HasAccessToken)
                {
                    await GetAuthorizationToken(tokens);
                    await GetAccessToken(tokens);
                    SaveTokens(tokens);
                    Console.WriteLine($"Access token & refresh token opgeslagen voor toekomstig gebruik.");
                }
                else if (tokens.IsAccessExpired)
                {
                    await RefreshAccessToken(tokens);
                    SaveTokens(tokens);
                    Console.WriteLine($"Access token & refresh token opgeslagen voor toekomstig gebruik.");
                }
                else
                {
                    Console.WriteLine($"Geldig access token gevonden, deze wordt gebruikt.");
                }
                //nu hebben we een geldig access token
                //test call naar klic api
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"Verstreken tijd {sw.ElapsedMilliseconds / 1000} sec.");

                    await DoTestCall(tokens.AccessToken, tokens.TestUrl);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task RefreshAccessToken(TokenCollection tokens)
        {
            Console.WriteLine($"Access token gevonden maar deze is verlopen. Nieuw access token wordt opgehaald.");
            string refreshUri = tokens.AuthorizationEndpoint + "/token";
            var content = new StringContent
            (
                "&client_id=" + tokens.ClientId
                + "&client_secret=" + tokens.ClientSecret
                + "&refresh_token=" + tokens.RefreshToken
                + "&grant_type=" + "refresh_token"
                + "&scope=" + tokens.Scope
            );
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var client = new HttpClient();
            DateTime startTime = DateTime.Now;
            HttpResponseMessage response = await client.PostAsync(refreshUri, content);
            string result = await response.Content.ReadAsStringAsync();
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(result));
            var serializer = new DataContractJsonSerializer(typeof(RequestTokenResponse));
            var tokenResponse = (RequestTokenResponse)serializer.ReadObject(stream);
            tokens.AccessToken = tokenResponse.AccessToken;
            tokens.RefreshToken = tokenResponse.RefreshToken;
            tokens.ValidUntil = startTime.AddSeconds(int.Parse(tokenResponse.ExpiresIn));
        }

        private static void SaveTokens(TokenCollection tokens)
        {
            new TokenRepository().SaveTokens(tokens);
        }

        #endregion Private Methods
    }
}