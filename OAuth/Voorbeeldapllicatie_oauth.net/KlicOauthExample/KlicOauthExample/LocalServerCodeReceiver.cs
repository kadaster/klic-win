using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace KlicOauthExample
{
    public class LocalServerCodeReceiver
    {
        #region Private Fields

        /// <summary>Close HTML tag to return the browser so it will close itself.</summary>
        private const string ClosePageResponse =
            @"<html>
              <head><title>OAuth 2.0 Authentication Token Received</title></head>
              <body>
                Received verification code. You may now close this window.
                <script type='text/javascript'>
                  // This doesn't work on every browser.
                  window.setTimeout(function() {
                      this.focus();
                      window.opener = this;
                      window.open('', '_self', '');
                      window.close();
                    }, 1000);
                  //if (window.opener) { window.opener.checkToken(); }
                </script>
              </body>
            </html>";

        #endregion Private Fields

        #region Public Properties

        public string RedirectUri { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc />
        public async Task<string> ReceiveCodeAsync(string url,
            CancellationToken taskCancellationToken)
        {
            var authorizationUrl = url;
            // The listener type depends on platform:
            // * .NET desktop: System.Net.HttpListener
            // * .NET Core: LimitedLocalhostHttpServer (above, HttpListener is not available in any version of netstandard)
            using (var listener = StartListener())
            {
                bool browserOpenedOk;
                try
                {
                    browserOpenedOk = OpenBrowser(authorizationUrl);
                }
                catch (Exception e)
                {
                    throw new NotSupportedException(
                        $"Failed to launch browser with \"{authorizationUrl}\" for authorization. See inner exception for details.", e);
                }
                if (!browserOpenedOk)
                {
                    throw new NotSupportedException(
                        $"Failed to launch browser with \"{authorizationUrl}\" for authorization; platform not supported.");
                }
                return await GetResponseFromListener(listener, taskCancellationToken).ConfigureAwait(false);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<string> GetResponseFromListener(HttpListener listener, CancellationToken ct)
        {
            // Set up cancellation. HttpListener.GetContextAsync() doesn't accept a cancellation token,
            // the HttpListener needs to be stopped which immediately aborts the GetContextAsync() call.
            ct.Register(listener.Stop);

            // Wait to get the authorization code response.
            HttpListenerContext context;
            try
            {
                context = await listener.GetContextAsync().ConfigureAwait(false);
            }
            catch (HttpListenerException) when (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
                // Next line will never be reached because cancellation will always have been requested in this catch block.
                // But it's required to satisfy compiler.
                throw new InvalidOperationException();
            }

            // Write a "close" response.
            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.WriteLine(ClosePageResponse);
                writer.Flush();
            }
            context.Response.OutputStream.Close();

            NameValueCollection coll = context.Request.QueryString;
            return coll["code"];
        }

        private bool OpenBrowser(string url)
        {
            Process.Start(url);
            return true;
        }

        private HttpListener StartListener()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(RedirectUri);
            listener.Start();
            return listener;
        }

        #endregion Private Methods
    }
}