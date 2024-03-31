using Microsoft.AspNetCore.Authentication;

namespace Sample.Api.Authentication
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ClientKey";
        public const string HeaderName = "X-Api-Key";
    }
}
