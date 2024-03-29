﻿using Microsoft.OpenApi.Models;
using Prometheus;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Swagger Demo Documentation",
            Version = "v1",
            Description = "This is a demo to see how documentation can easily be generated for ASP.NET Core Web APIs using Swagger and ReDoc.",
            Contact = new OpenApiContact
            {
                Name = "weiyi lai",
                Email = "joy777park@gmail.com"
            }
        });

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    options.EnableAnnotations();
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Swagger Demo Documentation v1"
        );
});

app.UseReDoc(options =>
{
    options.DocumentTitle = "Swagger Demo Documentation";
    options.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpMetrics();
// Make sure these calls are made before the call to UseEndPoints.
app.UseMetricServer();

app.MapControllers();

app.Run();
