// <copyright file="Program.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.AspNetCore.HttpOverrides;
using Rocco.Application;
using Rocco.Persistence;
using Rocco.Web.API.Extensions;
using Rocco.Web.API.Middleware;
using Rocco.Identity;
using Rocco.Application.Contracts;
using Rocco.Web.API.Services;
using Rocco.Web.API.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(configuration);

// Injectiong the service to get the current user
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

// Loading a simple setting from the appsettings.json
builder.Services.Configure<GeneralSettings>(configuration.GetSection("GeneralSettings"));


builder.AddSerilog();

// Use only if you will calling to another webservices
builder.Services.AddHttpClient();

// Add services to the container.

builder.Services.ConfigureCors(); //CORS https://bit.ly/36e4yP1
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // JsonPatch in ASP.NET Core web API:  https://bit.ly/3sTw5gn

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();

// START Swagger
// Swashbucled https://bit.ly/34Vs4jF 
// Open API support for ASP.NET Core Minimal API  https://bit.ly/3HiwDlc
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below. \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {

                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,


                        },
                        new List<string>()
                      }
                    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rocco Company API",
        Description = "An ASP.NET Core Web API for Rocco Compay",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Heliberto Arias",
            Url = new Uri("https://localhost/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://localhost/license")
        }
    });
});
// END Swagger



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}
// Custom error handling https://bit.ly/34U4PGD 
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

// ForwardedHeaders https://bit.ly/3h3OYri
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

app.UseAuthentication(); // This is required for [Authorize] in controllers
app.UseAuthorization();

app.MapControllers();

app.Run();
