namespace MvcApp.IntegrationTests.Setup;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Todo: Customize your model configuration if needed:
        // For example:
        // modelBuilder.Entity<Employee>().ToTable("Employees");
        // modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        // ...

        base.OnModelCreating(modelBuilder);
    }
}