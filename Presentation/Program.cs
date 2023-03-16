using Microsoft.Extensions.Configuration;

using ToDoApplication.Application;
using ToDoApplication.Infrastructure;

using ToDoApplication.Presentation.Middlewares;

using Serilog;
using Serilog.Events;
using Serilog.AspNetCore;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
Serilog.Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add services to the container.
builder.Services.ConfigureApplication();

string connectionString = builder.Configuration.GetConnectionString("ToDo_dbConnection")!;
builder.Services.ConfigurePersistence(connectionString);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

Log.CloseAndFlush();