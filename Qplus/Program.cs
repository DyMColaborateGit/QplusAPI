using AspNetCoreRateLimit;
using App.Infraestructure.Connect;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using App.logic.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Se encarga de Transformar Los Modelos con las ERntidades
builder.Services.InitMapper();

//Se encarga de Limitar el numero de peticiones a un EndPoint
builder.Services.ConfigurateRateLimitPeticiones();

//Iniciamos la autentication JWT
builder.Services.AddJwt(builder.Configuration);

// Se generan los permisos de cors
builder.Services.ConfigureCors();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddDbContext<ConnectContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(y =>
{
    y.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Qplus-Api",
        Description = "ASP.NET Core API General"
    });
    y.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    y.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    y.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllersWithViews();

builder.WebHost.ConfigureKestrel(opciones =>
{
    // 512 Megas
    opciones.Limits.MaxRequestBodySize = 512 * 1024 * 1024;
});


// Se Agregan los servicios
builder.Services.AddAplicacionServices();

// Se Agregan los repositories
builder.Services.AddAplicacionRepositories();


var app = builder.Build();

app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
//if (app.Environment.IsProduction())
//if (app.Environment.IsDevelopment())
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    //Este es para crear las migraciones pero para una db Nueva una que ya existe generaproblemas
    //try  
    //{
    //    var context = services.GetRequiredService<ConnectContext>();
    //    await context.Database.MigrateAsync();
    //}catch(Exception ex)
    //{
    //    var logger = loggerFactory.CreateLogger<Program>();
    //    logger.LogError(ex, "Ocurrio un Error durante la migraci�n");
    //}
}

//app.UseCors("CorPolicy");
// Configuración de middlewares
app.UseCors("AllowSpecificOrigin");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();
