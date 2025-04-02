using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ManagementControlAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Expressions;

DotNetEnv.Env.Load(); // Loads .env

var builder = WebApplication.CreateBuilder(args);

// Database setting from .env
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

//
if (connectionString == string.Empty)
{
    throw new InvalidOperationException("CONNECTION STRING IS EMPTY!");
}

// Builder for db
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization();

// JWT Secret .env
var JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET");

// Check if there is anything
if (string.IsNullOrEmpty(JWT_SECRET))
{
    throw new InvalidOperationException("JWT_SECRET is not set in the environment variables.");
}

// Build service to auth JWT
//TODO: Make in another file
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_SECRET))
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Api working!");
app.MapControllers();

app.Run();
