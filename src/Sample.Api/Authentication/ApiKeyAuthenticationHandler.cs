using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Sample.Api.Settings;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Sample.Api.Authentication;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
{
    private readonly IConfiguration _configuration;

    public ApiKeyAuthenticationHandler(
        IConfiguration configuration,
        IOptionsMonitor<ApiKeyAuthenticationOptions> options,
        ILoggerFactory logger, UrlEncoder encoder
    ) : base(options, logger, encoder)
    {
        _configuration = configuration;    
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(ApiKeyAuthenticationOptions.HeaderName, out var apiKey))
            return AuthenticateResult.Fail("Api Key was not provided");

        var clientId = await GetClientIdFromApiKeyAsync(apiKey.ToString());
        if (clientId is null) return AuthenticateResult.Fail("Invalid Api Key");

        var claims = new[] { new Claim(ClaimTypes.Name, clientId.Value.ToString()) };
        var identity = new ClaimsIdentity(claims, ApiKeyAuthenticationOptions.DefaultScheme);
        var ticket = new AuthenticationTicket(
            new ClaimsPrincipal([identity]),
            ApiKeyAuthenticationOptions.DefaultScheme
        );

        return AuthenticateResult.Success(ticket);
    }

    private Task<Guid?> GetClientIdFromApiKeyAsync(string apiKey)
    {
        var apiKeyClients = _configuration.GetSection("ApiKeyClients").Get<List<ApiKeyClient>>();
        var clientId = apiKeyClients?.FirstOrDefault(a => a.ApiKey == apiKey)?.ClientId;
        return Task.FromResult(clientId);
    }
}
