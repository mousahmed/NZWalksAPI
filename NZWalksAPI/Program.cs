using AutoMapper;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;
using NZWalksAPI.Utils;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Load environment variables from .env file
DotEnv.Load();

// Build the connection string using environment variables
string? APPLICATION_DB = Environment.GetEnvironmentVariable("SQLSERVER_DB");
string? APPLICATION_AUTH_DB = Environment.GetEnvironmentVariable("SQLSERVER_AUTH_DB");

var connectionString = (string SQLSERVER_DB) =>
{
  return string.Format(
  "Server={0},{1};Database={2};User Id={3};Password={4};TrustServerCertificate=True;",
  Environment.GetEnvironmentVariable("SQLSERVER_HOST"),
  Environment.GetEnvironmentVariable("SQLSERVER_PORT"),
  SQLSERVER_DB,
  Environment.GetEnvironmentVariable("SQLSERVER_USER"),
  Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD")
  );
};

builder.Services.Configure<JwtSettings>(options =>
{
  options.Key = Environment.GetEnvironmentVariable("JWT_SECRET");
  options.Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
  options.Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
});

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString(APPLICATION_DB)));

builder.Services.AddDbContext<ApplicationAuthDbContext>(options =>
    options.UseSqlServer(connectionString(APPLICATION_AUTH_DB)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo { Title = "NZ Walks API", Version = "v1" });
  options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
  {
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = JwtBearerDefaults.AuthenticationScheme
  });

  options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks")
    .AddEntityFrameworkStores<ApplicationAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
  options.Password.RequiredLength = 6;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")))
      };
    });

builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
