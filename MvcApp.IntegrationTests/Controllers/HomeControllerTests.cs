namespace MvcApp.IntegrationTests.Controllers;

public class HomeControllerTests
{
    private readonly CustomWebApplicationFactory _factory;

    public HomeControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;

        // Seed the in-memory database with test data
        using var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();

        // Perform data seeding
        dbContext.Employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe" });
        dbContext.Employees.Add(new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" });
        // Add more test data as needed

        dbContext.SaveChanges();
    }
}
