using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities;
using App.Infraestructure.Connect.Entities.Share;
using App.Models.Global;
using App.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Infraestructure.Helpers
{
    public class ExceptionLogHelpers
    {

        public static void LogException(string metodo, Exception exception, string observacion)
        {
            IConfiguration config = ConfigurationHelpers.config;
            var optionsBuilder = new DbContextOptionsBuilder<ConnectContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            var dbContext = new ConnectContext(optionsBuilder.Options);

            var exceptionLog = new Exception_LogEntities
            {
                Metodo = metodo,
                Aplicacion = GetAplications.Valoracion,
                ExceptionString = exception.Message.ToString(),
                Observacion = observacion,
                Anio = DateTime.Now.Year,
                FechaLog = DateTime.Now
            };

            dbContext.Exception_Log.Add(exceptionLog);
            dbContext.SaveChanges();
        }
    }
}
