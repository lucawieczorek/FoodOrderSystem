using FoodOrderSystem.Domain.Commands;
using FoodOrderSystem.Domain.Commands.EnsureAdminUser;
using FoodOrderSystem.Domain.Model.User;
using FoodOrderSystem.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FoodOrderSystem.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<SystemDbContext>();
                dbContext.Database.Migrate();
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var currentUser = new User(new UserId(Guid.Empty), "admin", Role.SystemAdmin, null, null);

                var commandDispatcher = services.GetService<ICommandDispatcher>();
                var result = commandDispatcher.PostAsync(new EnsureAdminUserCommand(), currentUser).Result;
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
