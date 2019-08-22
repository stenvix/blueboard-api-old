using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using Serilog;

namespace BlueBoard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.SetBasePath(Directory.GetCurrentDirectory());
                        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                        builder.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                            optional: true, reloadOnChange: true);
                        builder.AddEnvironmentVariables();
                    })
                .UseStartup<Startup>()
                .ConfigureLogging(LoggingSetup)
                .UseKestrel();

        private static void LoggingSetup(WebHostBuilderContext context, ILoggingBuilder loggingBuilder)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            loggingBuilder.AddSerilog();
        }
    }
}
