using Sample.Api.Authentication;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddAuthentication()
    .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, null);

services.AddScoped<ApiKeyAuthenticationHandler>();

var app = builder.Build();

app.MapControllers();

app.Run();
