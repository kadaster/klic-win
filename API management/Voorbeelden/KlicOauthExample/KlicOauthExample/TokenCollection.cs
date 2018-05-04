using System;

namespace KlicOauthExample
{
    public class TokenCollection
    {
        #region Public Constructors

        public TokenCollection()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string AccessToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string TestUrl { get; set; }
        public DateTime ValidUntil { get; set; }
        public string AuthorizationEndpoint { get; set; } = "https://authorization.kadaster.nl/auth/oauth/v2";

        #endregion Public Properties

        #region Internal Properties

        internal string AuthorizationCode { get; set; }
        internal bool HasAccessToken { get { return !string.IsNullOrWhiteSpace(AccessToken); } }

        internal bool HasClientId { get { return !string.IsNullOrWhiteSpace(ClientId) && !string.IsNullOrWhiteSpace(ClientSecret); } }

        internal bool IsAccessExpired { get { return ValidUntil < DateTime.Now; } }

        #endregion Internal Properties
    }
}