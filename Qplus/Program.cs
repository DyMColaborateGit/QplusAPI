using AspNetCoreRateLimit;
using App.Infraestructure.Connect;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using App.logic.Extensions;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Mappers y Rate Limit
builder.Services.InitMapper();
builder.Services.ConfigurateRateLimitPeticiones();
builder.Services.AddJwt(builder.Configuration);
builder.Services.ConfigureCors();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ConnectContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(y =>
{
    y.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Qplus-Api" });
    y.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    y.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new List<string>()
        }
    });
});

builder.Services.AddControllersWithViews();

builder.WebHost.ConfigureKestrel(opciones =>
{
    opciones.Limits.MaxRequestBodySize = 512 * 1024 * 1024;
});

builder.Services.AddSingleton(typeof(ITools), new PdfTools());

builder.Services.AddSingleton<IConverter, SynchronizedConverter>();

builder.Services.AddAplicacionServices();
builder.Services.AddAplicacionRepositories();

var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseRouting();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();