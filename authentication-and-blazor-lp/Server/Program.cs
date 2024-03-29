﻿using BellyBox.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellyBox.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var bbContext = services.GetRequiredService<BellyBoxContext>();
                        var appContext = services.GetRequiredService<ApplicationDbContext>();
                        var environment = services.GetRequiredService<IWebHostEnvironment>();
                        bbContext.Database.Migrate();
                        appContext.Database.Migrate();
                        DatabaseSeed.Initialize(services, environment);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred creating the DB.");
                    }
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
