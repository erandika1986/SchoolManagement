using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SchoolManagement.WebApi
{
    public class Programeke 
    {
        public static int Main(string[] args)
        {


            //var host = Host.CreateDefaultBuilder(args)
            //    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //    .ConfigureWebHostDefaults(webHostBuilder => {
            //        webHostBuilder
            //        .UseContentRoot(Directory.GetCurrentDirectory())
            //        .UseIISIntegration()
            //        .UseStartup<Startup>();
            //    })
            //.Build();

            //host.Run();





            var configurationBuilder = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            //Log.Logger = CreateSerilogLogger(configurationBuilder);

            try
            {
                //Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                var host = CreateHostBuilder(configurationBuilder, args);

                //Log.Information("Applying migrations ({ApplicationContext})...", AppName);
                //host.MigrateDbContext<EEGDbContext>((context, services) =>
                //{
                //    var env = services.GetService<IWebHostEnvironment>();
                //    var settings = services.GetService<IOptions<EEGSettings>>();
                //    var logger = services.GetService<ILogger<EEGDbContextSeed>>();

                //    new EEGDbContextSeed()
                //        .SeedAsync(context, env, logger)
                //        .Wait();
                //});

                //Log.Information("Starting web host ({ApplicationContext})...", AppName);
                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                return 1;
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }


        private static IWebHost CreateHostBuilder(IConfiguration configuration, string[] args) =>
         WebHost.CreateDefaultBuilder(args)

         .UseStartup<Startup>()
         .UseContentRoot(Directory.GetCurrentDirectory())
         .ConfigureAppConfiguration((builderContext, config) =>
         {
             config.AddConfiguration(configuration);
         })
         //.UseWebRoot("Pics")
         //.UseSerilog()
         .Build();


    }
}
