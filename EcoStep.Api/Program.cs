using EcoStep.Api.Middleware;
using EcoStep.Application.Services.Classes;
using EcoStep.Application.Services.Interfaces;
using EcoStep.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DotNetEnv;
using System.Text.Json;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
Env.Load();

// Connection String
string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

#region Services Configuration

// Add controllers
builder.Services.AddControllers();

// Configure Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EcoStep API",
        Version = "v1"
    });

    // Configura el esquema de seguridad
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en el formato: Bearer {token}"
    });

    // Aplica el esquema de seguridad globalmente
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// Configure Entity Framework and Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
  
});

// Configure CORS
var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigins")!;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins(allowedOrigin).AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("free", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add custom services
builder.Services.AddSingleton<IAuthenticationService, FirebaseAuthenticationService>();

#endregion

#region Application Initialization

var app = builder.Build();


// Firebase initialization
string? type = Environment.GetEnvironmentVariable("TYPE");
string? projectId = Environment.GetEnvironmentVariable("PROJECT_ID");
string? privateKeyId = Environment.GetEnvironmentVariable("PRIVATE_KEY_ID");
string? privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");
string? clientEmail = Environment.GetEnvironmentVariable("CLIENT_EMAIL");
string? clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
string? authUri = Environment.GetEnvironmentVariable("AUTH_URI");
string? tokenUri = Environment.GetEnvironmentVariable("TOKEN_URI");
string? authProviderCertUrl = Environment.GetEnvironmentVariable("AUTH_PROVIDER_X509_CERT_URL");
string? clientCertUrl = Environment.GetEnvironmentVariable("CLIENT_X509_CERT_URL");
string? universeDomain = Environment.GetEnvironmentVariable("UNIVERSE_DOMAIN");

string json = $@"
{{
    ""type"": ""{type}"",
    ""project_id"": ""{projectId}"",
    ""private_key_id"": ""{privateKeyId}"",
    ""private_key"": ""{privateKey}"",
    ""client_email"": ""{clientEmail}"",
    ""client_id"": ""{clientId}"",
    ""auth_uri"": ""{authUri}"",
    ""token_uri"": ""{tokenUri}"",
    ""auth_provider_x509_cert_url"": ""{authProviderCertUrl}"",
    ""client_x509_cert_url"": ""{clientCertUrl}"",
    ""universe_domain"":""{universeDomain}""
}}
";

var rootPath = AppContext.BaseDirectory;
string filePath = Path.Combine(rootPath, "serviceAccountKey.json");
File.WriteAllText(filePath, json);

EcoStep.Infrastructure.Extensions.Firebase.FirebaseAdminHelper.InitializerFirebase(filePath);

// Serve static files
app.UseStaticFiles();

#endregion

#region Middleware Configuration

// Swagger configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors();

// Enforce HTTPS
app.UseHttpsRedirection();

// Add custom authentication middleware
app.UseMiddleware<FirebaseAuthenticationMiddleware>();

// Authorization middleware
app.UseAuthorization();

#endregion

#region Endpoint Mapping

// Map controllers
app.MapControllers();

#endregion

// Run the application
app.Run();
