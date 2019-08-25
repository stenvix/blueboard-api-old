using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BlueBoard.API.Options;
using BlueBoard.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Serilog;

namespace BlueBoard.API.Infrastructure
{
    public static class Extensions
    {
        private static string _jwtSectionName = "Jwt";

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(_jwtSectionName));
            var options = configuration.GetSection(_jwtSectionName).Get<JwtOptions>();
            services.AddAuthentication(i =>
                {
                    i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    //TODO: Uncomment when deploy
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                        ValidIssuer = options.Issuer,
                        ValidAudience = options.ValidAudience,
                        ValidateAudience = options.ValidateAudience,
                        ValidateLifetime = options.ValidateLifetime
                    };
                });
        }

        public static void RunMigrations(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();
                var logger = scope.ServiceProvider.GetService<ILogger<BlueBoardContext>>();
                WaitForDatabase(config.GetConnectionString("Default"), logger);
                using (var context = scope.ServiceProvider.GetService<BlueBoardContext>())
                {
                    var migrations = context.Database.GetPendingMigrations();
                    if (migrations.Any()) context.Database.Migrate();
                }
            }
        }

        private static void WaitForDatabase(string connectionString, ILogger<BlueBoardContext> logger, int retryCount = 60)
        {
            var connectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
            var retry = 0;

            using (var connection = new NpgsqlConnection(connectionStringBuilder.ConnectionString))
            {
                while (retry < retryCount)
                {
                    try
                    {
                        connection.Open();
                        return;
                    }
                    catch (Exception exception)
                    {
                        retry++;
                        logger.LogError(exception.Message, exception);
                        Task.Delay(250);
                    }
                }
            }
        }
    }
}
