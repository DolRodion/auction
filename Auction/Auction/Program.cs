using MBC.Core.DataAccess.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Auction
{
    public class Program
    {
        private static string[] configFiles = {
            "database-config.json",
        };
        public static async Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .Build();

            await CreateHostBuilder(args, configuration).Build()
               .MigrateDbContext<ApplicationDbContext>()
               .RunAsync();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((host, builder) =>
                {
                    builder.SetBasePath(AppContext.BaseDirectory);
                    foreach (var configFile in configFiles)
                    {
                        builder.AddJsonFile($"configs/{configFile}", optional: false, reloadOnChange: true);
                    }
                });
    }
}
