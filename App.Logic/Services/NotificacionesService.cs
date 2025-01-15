using App.logic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class NotificacionesService: INotificacionesService
    {
        public NotificacionesService()
        {

        }

        public async Task<string> SentNotificacionComceptoFinal(string Asunto, string Mensaje, string Rol, int EmpresaId)
        {
            return "";
        }
    }
}
