using Microsoft.AspNetCore.Mvc.Testing;

namespace MvcApp.IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
}

