// <copyright file="WeatherForecast.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

namespace Rocco.Web.API;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
