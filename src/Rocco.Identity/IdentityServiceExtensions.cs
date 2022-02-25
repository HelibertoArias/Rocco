
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Rocco.Application.Models.Authentication;
using Rocco.Application.Contracts.Identity;
using Rocco.Identity.Models;
using Rocco.Identity.Services;

namespace Rocco.Identity;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        var stringConnection = "RoccoIdentityConnectionString";
        var connectionConfiguration = configuration.GetConnectionString(stringConnection);
        if (connectionConfiguration == null)
        {
            throw new ArgumentNullException(nameof(connectionConfiguration), $"{stringConnection} doesn't exist in your appsetings.json");
        }

        services.AddDbContext<RoccoIdentityContext>(options => options.UseSqlServer(connectionConfiguration,
            b => b.MigrationsAssembly(typeof(RoccoIdentityContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               options.Password.RequiredLength = 10;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequireNonAlphanumeric = true;
               options.Password.RequireDigit = true;
           })
            .AddEntityFrameworkStores<RoccoIdentityContext>().AddDefaultTokenProviders();

        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new { error = "401 Not authorized" });
                        return context.Response.WriteAsync(result);

                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new { error = "403 Not authorized" });
                        return context.Response.WriteAsync(result);
                    },
                };
            });
    }
}
