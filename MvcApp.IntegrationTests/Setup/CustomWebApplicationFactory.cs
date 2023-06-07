namespace MvcApp.IntegrationTests.Setup;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Configure the test server
        builder.UseEnvironment("Test");

        // Optionally configure other settings, such as the content root, logging, etc.
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<TestDbContext>(optionss =>
            {
                optionss.UseInMemoryDatabase(TestDatabase);
            });
        });

        // Call the base ConfigureWebHost method to apply the default configuration
        base.ConfigureWebHost(builder);
    }

    public string TestDatabase => "InMemortTestDb";

    // IDisposable implementation
    private bool _disposed = false;
}
