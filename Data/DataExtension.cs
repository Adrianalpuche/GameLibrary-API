using System;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Data;

public static class DataExtension
{

    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameLibraryContext>();
        dbContext.Database.Migrate();
    }

    public static void AddLibraryGame(this WebApplicationBuilder builder)
    {
       var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
       builder.Services.AddDbContext<GameLibraryContext>(options =>
       options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        
    }

    

}
