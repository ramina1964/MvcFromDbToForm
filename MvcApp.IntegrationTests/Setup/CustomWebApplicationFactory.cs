namespace MvcApp.IntegrationTests.Setup;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the existing TestDbContext registration, if any
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(TestDbContext));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            // Add the TestDbContext with the appropriate options
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseInMemoryDatabase(TestDatabase);
            });

            // Register the TestDbContext for the desired lifetime
            services.AddScoped<TestDbContext>();
        });
    }

    public string TestDatabase => "InMemortTestDb";
}
