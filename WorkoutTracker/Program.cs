using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WorkoutTracker.Data;

namespace WorkoutTracker
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();

      CreateDbIfNoteExists(host);

      host.Run();
    }

    private static void CreateDbIfNoteExists(IHost host)
    {
      using var scope = host.Services.CreateScope();
      var services = scope.ServiceProvider;
      try
      {
        var context = services.GetRequiredService<WorkoutTrackerContext>();
        DbInitializer.Initialize(context);
      }
      catch (Exception ex)
      {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating the DB");
        throw;
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
