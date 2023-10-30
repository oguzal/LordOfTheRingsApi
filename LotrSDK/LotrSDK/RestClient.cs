
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using System.Configuration;

namespace LotrSDK
{
    public class LotrClient
    {
        public RestClient RestClient { get; set; }

        public LotrClient(string bearerToken)
        {           
            var baseUrl ="https://the-one-api.dev/v2";
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(bearerToken, "Bearer");
            var options = new RestClientOptions(baseUrl)
            {
                Authenticator = authenticator
            };
            RestClient = new RestClient(options);
        }

    }
}
