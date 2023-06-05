namespace MvcApp.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Configure the test server
        builder.UseEnvironment("Test");

        // Optionally configure other settings, such as the content root, logging, etc.

        // Call the base ConfigureWebHost method to apply the default configuration
        base.ConfigureWebHost(builder);
    }
}
