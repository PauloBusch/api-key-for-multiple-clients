## Authenticate in multiple clients using Api Key

**This is a sample Api project that uses Api Key authentication with support for multiple clients.**

## Configuration
The configuration of clients that are allowed to call the `details` endpoint are configured in `ApiKeyClients` section of `appsettings.json` file.
For each client you have to provide the ApiKey value and ClientId. For your implementation you can include another fields as needed.
``` json
"ApiKeyClients": [
    {
      "ApiKey": "S7hZ6DeKmqpUWVELawt8gR2bHc3NM9vn",
      "ClientId": "e474f624-ad33-4d2b-b515-c090b52e9cdb"
    }
]
```

## Call Endpoints

A easy way to test the authentication flow in Visual Studio is calling the endpoints using `Sample.Api.http` file.
There are samples of requests that shows you the behaviour of the Api when calling the endpoints without Api Key and with different values of it.

## Swagger UI

A Swagger documentation is included in the Api, you can see the source code to configure Api Key authentication looking at `SwaggerConfiguration` class in `Sample.Api` project.
