using System;

namespace App.logic.IServices
{
    public interface INotificacionesService
    {
        Task<string> SentNotificacionComceptoFinal(string Asunto, string Mensaje, string Rol, int EmpresaId);
    }
}
