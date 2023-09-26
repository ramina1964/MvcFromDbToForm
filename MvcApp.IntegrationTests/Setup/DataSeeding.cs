namespace MvcApp.IntegrationTests.Setup;

public class DataSeeding
{
    private void SeedTestData(CustomWebApplicationFactory factory)
    {
        // Seed the in-memory database with test data
        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();

        // Perform data seeding
        dbContext.Employees.Add(new Employee
        {
            EmployeeId = 123451,
            FirstName = "Ramin",
            LastName = "Anvar",
            EmailAddress = "Ramin@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            EmployeeId = 123452,
            FirstName = "Afshin",
            LastName = "Anvar",
            EmailAddress = "Afshin@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            EmployeeId = 123453,
            FirstName = "Amanda S.",
            LastName = "Høyer Anvar",
            EmailAddress = "Amanda@gmail.com"
        });

        dbContext.Employees.Add(new Employee
        {
            EmployeeId = 123454,
            FirstName = "Kathinka B. H.",
            LastName = "Høyer Anvar",
            EmailAddress = "kathinka@gmail.com"
        });

        dbContext.SaveChanges();
    }
}
