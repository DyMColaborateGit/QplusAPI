using App.Models.Helpers;
using AspNetCoreRateLimit;
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.Infraestructure.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using App.logic.IServices;
using App.logic.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using App.Models.Models.Scp;

namespace App.logic.Extensions
{
    /// <summary>
    /// AplicationServiceExtensions
    /// </summary>
    public static class AplicationServiceExtensions
    {
        /// <summary>
        /// ConfigureCors
        /// </summary>
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        /// <summary>
        /// AddAplicacionServices
        /// </summary>
        public static void AddAplicacionServices(this IServiceCollection services)
        {
            services.AddScoped<IGestEvaluacionService, GestEvaluacionService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPasswordHasher<SCP_UsuarioModels>, PasswordHasher<SCP_UsuarioModels>>();
            services.AddScoped<IEmpresasService, EmpresasService>();

            services.AddScoped<IEncabezadoEvaService, EncabezadoEvaService>();
            services.AddScoped<IProgEvaluacionSercice, ProgEvaluacionService>();
            services.AddScoped<IProgramacionMasivaEvaluacionesService, ProgramacionMasivaEvaluacionesService>();
            services.AddScoped<IResultadosEvaluacionService, ResultadosEvaluacionService>();
            services.AddScoped<ITxtFormEvaluacionService, TxtFormEvaluacionService>();
            services.AddScoped<IEscalaEvaluacionService, EscalaEvaluacionService>();
            services.AddScoped<IResultadoEvaluacionadaService, ResultadoEvaluacionadaService>();
            services.AddScoped<INotificacionesService, NotificacionesService>();
            services.AddScoped<IFuncionariosService, FuncionariosService>();
            services.AddScoped<IUsuariosRolesService, UsuariosRolesService>();
            services.AddScoped<IResultadosEvaIndicadoresService, ResultadosEvaIndicadoresService>();
            services.AddScoped<IMastIndicadoresService, MastIndicadoresService>();
            services.AddScoped<IResultcomTecnicasService, ResultcomTecnicasService>();
            services.AddScoped<IConsolidadoDesempenoService, ConsolidadoDesempenoService>();
            services.AddScoped<ITiposIndicadoresEstrategicosService, TiposIndicadoresEstrategicosService>();
            services.AddScoped<IDialogodeDesarrolloService, DialogodeDesarrolloService>();
            services.AddScoped<INormaService, NormaService>();
            services.AddScoped<ITiposActividadService, TiposActividadService>();
            services.AddScoped<IActividadesPIDService, ActividadesPIDService>();
            services.AddScoped<IActividadesIndicadoresService, ActividadesIndicadoresService>();
            services.AddScoped<IActividadesCompetenciasService, ActividadesCompetenciasService>();
            services.AddScoped<IResultIndiCoporpService, ResultIndiCoporpService>();
            services.AddScoped<IZonasService, ZonasService>();
            services.AddScoped<IEncuestaPreguntaService, EncuestaPreguntaService>();
            services.AddScoped<IOficinasService, OficinasService>();
            services.AddScoped<IProcesoService, ProcesoService>();
            services.AddScoped<IGeneralService, GeneralService>();
            services.AddScoped<IMatrizdeTalentoService, MatrizdeTalentoService>();
            services.AddScoped<IEmpresasTitulosService, EmpresasTitulosService>();
            services.AddScoped<IEvaAuditoresService, EvaAuditoresService>();
            services.AddScoped<IEvaPreguntasService, EvaPreguntasService>();
            services.AddScoped<IPesosxTipoIndxNivelCompService, PesosxTipoIndxNivelCompService>();
            services.AddScoped<IDocumentosControladosService, DocumentosControladosService>();
            services.AddScoped<IAreasService, AreasService>();
            services.AddScoped<IProductosService, ProductosService>();
            services.AddScoped<ISistemasGestionService, SistemasGestionService>();
            services.AddScoped<ITipos_DocumentoService, Tipos_DocumentoService>();
            services.AddScoped<ICargosService, CargosService>();
            services.AddScoped<IHistorialCambiosService, HistorialCambiosService>();
            services.AddScoped<IControlDistribucionService, ControlDistribucionService>();
            services.AddScoped<ICargosProcesosService, CargosProcesosService>();
            services.AddScoped<IParametrosEmpresasService, ParametrosEmpresasService>();
            services.AddScoped<INivelDesempenoPpalService, NivelDesempenoPpalService>();
        }

        /// <summary>
        /// AddAplicacionRepositories
        /// </summary>
        public static void AddAplicacionRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmpresasRepository, EmpresasRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEncabezadoRepository, EncabezadoRepository>();
            services.AddScoped<IProgEvaluacionRepository, ProgEvaluacionRepository>();
            services.AddScoped<IProgramacionMasivaEvaluacionesRepository, ProgramacionMasivaEvaluacionesRepository>();
            services.AddScoped<IResultadosEvaluacionRepository, ResultadosEvaluacionRepository>();
            services.AddScoped<IEscalaEvaluacionRepository, EscalaEvaluacionRepository>();
            services.AddScoped<ITxtFormEvaluacionRepository, TxtFormEvaluacionRepository>();
            services.AddScoped<IPesosxTipoIndxNivelCompRepository, PesosxTipoIndxNivelCompRepository>();
            services.AddScoped<IResultadosEvaIndicadoresRepository, ResultadosEvaIndicadoresRepository>();
            services.AddScoped<IAspectosValoracionRepository, AspectosValoracionRepository>();
            services.AddScoped<IResultadoEvaluacionadaRepository, ResultadoEvaluacionadaRepository>();
            services.AddScoped<IObjetivosCalidadRepository, ObjetivosCalidadRepository>();
            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            services.AddScoped<IUsuariosRolesRepository, UsuariosRolesRepository>();
            services.AddScoped<IParametrosDesempenoRepository, ParametrosDesempenoRepository>();
            services.AddScoped<IGetPorcentajesRepository, GetPorcentajesRepository>();
            services.AddScoped<ITiposIndicadoresEstrategicosRepository, TiposIndicadoresEstrategicosRepository>();
            services.AddScoped<IResultadosRepository, ResultadosRepository>();
            services.AddScoped<IResultcomTecnicasRepository, ResultcomTecnicasRepository>();
            services.AddScoped<IPesosxTipoIndEstxTipoNivelEstRepository, PesosxTipoIndEstxTipoNivelEstRepository>();
            services.AddScoped<ITotalIndEstCorporativosRepository, TotalIndEstCorporativosRepository>();
            services.AddScoped<IResulDirectorGerentesRepository, ResulDirectorGerentesRepository>();
            services.AddScoped<IZonasRepository, ZonasRepository>();
            services.AddScoped<IOficinasRepository, OficinasRepository>();
            services.AddScoped<IConsolidadoDesempenoRepository, ConsolidadoDesempenoRepository>();
            services.AddScoped<INivelesCompetenciasRepository, NivelesCompetenciasRepository>();
            services.AddScoped<INivelesdeDesempenoRepository, NivelesdeDesempenoRepository>();
            services.AddScoped<IMastIndicadoresRepository, MastIndicadoresRepository>();
            services.AddScoped<IDialogodeDesarrolloRepository, DialogodeDesarrolloRepository>();
            services.AddScoped<IRelGestoresDialogoDesarrolloRepository, RelGestoresDialogoDesarrolloRepository>();
            services.AddScoped<INormaRepository, NormaRepository>();
            services.AddScoped<INivelesCargoCompRepository, NivelesCargoCompRepository>();
            services.AddScoped<ITiposActividadRepository, TiposActividadRepository>();
            services.AddScoped<IActividadesPIDRepository, ActividadesPIDRepository>();
            services.AddScoped<IActividadesIndicadoresRepository, ActividadesIndicadoresRepository>();
            services.AddScoped<IActividadesCompetenciasRepository, ActividadesCompetenciasRepository>();
            services.AddScoped<IResultIndiCoporpRepository, ResultIndiCoporpRepository>();
            services.AddScoped<IEncuestaPreguntaRepository, EncuestaPreguntaRepository>();
            services.AddScoped<IEncuestaRepository, EncuestaRepository>(); 
            services.AddScoped<IPreguntasRepository, PreguntasRepository>();
            services.AddScoped<IMatrizdeTalentoRepository, MatrizdeTalentoRepository>();
            services.AddScoped<IProcesoRepository, ProcesoRepository>();
            services.AddScoped<IEmpresasTitulosRepository, EmpresasTitulosRepository>();
            services.AddScoped<IEvaAuditoresRepository, EvaAuditoresRepository>();
            services.AddScoped<IEvaPreguntasRepository, EvaPreguntasRepository>();
            services.AddScoped<IPesosxTipoIndxNivelCompRepository, PesosxTipoIndxNivelCompRepository>();
            services.AddScoped<IDocumentosControladosRepository, DocumentosControladosRepository>();
            services.AddScoped<IAreasRepository, AreasRepository>();
            services.AddScoped<IProductosRepository, ProductosRepository>();
            services.AddScoped<ISistemasGestionRepository, SistemasGestionRepository>();
            services.AddScoped<ITipos_DocumentoRepository, Tipos_DocumentoRepository>();
            services.AddScoped<ICargosRepository, CargosRepository>();
            services.AddScoped<IHistorialCambiosRepository, HistorialCambiosRepository>();
            services.AddScoped<IControlDistribucionRepository, ControlDistribucionRepository>();
            services.AddScoped<ICargosProcesosRepository, CargosProcesosRepository>();
            services.AddScoped<IParametrosEmpresasRepository, ParametrosEmpresasRepository>();
            services.AddScoped<INivelDesempenoPpalRepository, NivelDesempenoPpalRepository>();
        }

        /// <summary>
        /// ConfigurateRateLimitPeticiones
        /// </summary>
        public static void ConfigurateRateLimitPeticiones(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();

            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 15
                    }
                };
            });
        }

        /// <summary>
        /// AddJwt
        /// </summary>
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationHelpers.TartConfiguration(configuration);
            services.Configure<JWTHelpers>(configuration.GetSection("JWT"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true, 
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                    };
                });
        }

        /// <summary>
        /// InitMapper
        /// </summary>
        public static void InitMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AplicationServiceExtensions));
            var configMapper = new MapperConfiguration(mapConfig =>
            {
                mapConfig.AddProfile(new MappingProfiles());
            });
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
