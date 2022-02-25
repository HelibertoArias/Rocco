// <copyright file="Program.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Rocco.Application;
using Rocco.Persistence;
using Rocco.Web.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.AddPersistenceServices(configuration);
builder.Services.AddApplicationServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
