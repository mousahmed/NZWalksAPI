using AutoMapper;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DotEnv.Load();

// Build the connection string using environment variables
var connectionString = string.Format(
    "Server={0},{1};Database={2};User Id={3};Password={4};TrustServerCertificate=True;",
    Environment.GetEnvironmentVariable("SQLSERVER_HOST"),
    Environment.GetEnvironmentVariable("SQLSERVER_PORT"),
    Environment.GetEnvironmentVariable("SQLSERVER_DB"),
    Environment.GetEnvironmentVariable("SQLSERVER_USER"),
    Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD")
);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
