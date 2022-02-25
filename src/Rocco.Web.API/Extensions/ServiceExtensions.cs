// <copyright file="ServiceExtensions.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

namespace Rocco.Web.API.Extensions;

public static class ServiceExtensions
{

    public static void ConfigureCors(this IServiceCollection services)
    {
        // https://bit.ly/36e4yP1
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                                  builder.AllowAnyOrigin() // WithOrigins("https://example.com")
                                                                    .AllowAnyMethod() // WithMethods("POST", "GET")
                                                                    .AllowAnyHeader() // WithHeaders("accept", "content-type")
                                                                    );
        });
    }
}

