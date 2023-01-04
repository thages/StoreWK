﻿namespace Catalog.API.Infrastructure.Factories;

public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();

        optionsBuilder.UseMySql(config["ConnectionString"], new MySqlServerVersion(new Version(8, 10, 30)), mySqlOptionsAction: o => o.MigrationsAssembly("Catalog.API"));

        return new CatalogContext(optionsBuilder.Options);
    }

}
