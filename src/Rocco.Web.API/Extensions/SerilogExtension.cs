// <copyright file="SerilogExtension.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Serilog;

namespace Rocco.Web.API.Extensions;

/// <summary>
///Adding Serilog  https://bit.ly/3rZM8dp
// Using Serilog https://bit.ly/3BAitKV
/// </summary>
public static class SerilogHelper
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
             .ReadFrom.Configuration(builder.Configuration).WriteTo
                      .File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                      .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
    }
}
