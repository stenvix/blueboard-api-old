using BlueBoard.API.Options;
using BlueBoard.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

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
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                using var scope = builder.ApplicationServices.CreateScope();
                await using var context = scope.ServiceProvider.GetService<BlueBoardContext>();
                var migrations = context.Database.GetPendingMigrations();
                if (migrations.Any()) context.Database.Migrate();
                var seeder = scope.ServiceProvider.GetService<DataSeeder>();
                await seeder.SeedAsync();
            });
        }
    }
}
