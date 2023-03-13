using Microsoft.Extensions.Configuration;

using ToDoApplication.Application;
using ToDoApplication.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.GetConnectionString("Mongo_Connection");

// Add services to the container.
builder.Services.ConfigureApplication();
builder.Services.Configureinfrastructure(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
