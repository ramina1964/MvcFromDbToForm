﻿namespace MvcApp.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IDisposable
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Configure the test server
        builder.UseEnvironment("Test");

        // Optionally configure other settings, such as the content root, logging, etc.

        // Call the base ConfigureWebHost method to apply the default configuration
        base.ConfigureWebHost(builder);
    }

    protected override void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose of any resources held by the factory
                // For example, dispose of the test server

                // Dispose logic here
            }

            _disposed = true;
        }
    }

    public new void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // IDisposable implementation
    private bool _disposed = false;
}
