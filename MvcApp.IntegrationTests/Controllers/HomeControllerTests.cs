namespace MvcApp.IntegrationTests.Controllers;

public class HomeControllerTests : IClassFixture<CustomWebApplicationFactory>, IDisposable
{
    public HomeControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        SeedTestData();
    }

    public void Dispose()
    {
        // Dispose any additional resources used by the test class
    }

    private void SeedTestData()
    {
        // Seed the in-memory database with test data
        using var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();

        // Perform data seeding
        dbContext.Employees.Add(new Employee
        {
            Id = 1,
            EmployeeId = 123451,
            FirstName = "Ramin",
            LastName = "Anvar",
            EmailAddress = "Ramin@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            Id = 2,
            EmployeeId = 123452,
            FirstName = "Afshin",
            LastName = "Anvar",
            EmailAddress = "Afshin@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            Id = 3,
            EmployeeId = 123453,
            FirstName = "Amanda S.",
            LastName = "Høyer Anvar",
            EmailAddress = "Amanda@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            Id = 4,
            EmployeeId = 123454,
            FirstName = "Kathinka B. H.",
            LastName = "Høyer Anvar",
            EmailAddress = "kathinka@gmail.com"
        });

        // Add more test data as needed

        dbContext.SaveChanges();
    }

    private readonly CustomWebApplicationFactory _factory;
}
