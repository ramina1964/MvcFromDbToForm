namespace MvcApp.IntegrationTesting;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {}

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customize your model configuration if needed
        // For example:
        // modelBuilder.Entity<Employee>().ToTable("Employees");
        // modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        // ...

        base.OnModelCreating(modelBuilder);
    }
}