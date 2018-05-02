using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KlicOauthExample
{
    [DataContract]
    public class RequestTokenResponse
    {
        public RequestTokenResponse()
        {
        }

        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "token_type")] public string TokenType { get; set; }
        [DataMember(Name = "expires_in")] public string ExpiresIn { get; set; }
        [DataMember(Name = "id_token")] public string IdToken { get; set; }
        [DataMember(Name = "refresh_token")] public string RefreshToken { get; set; }
    }

}