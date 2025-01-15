using App.Models.Models;
using App.Models.Models.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IHistorialCambiosService
    {
        Task<List<Historial_cambiosModels>> GetHistorialesDocumentoByDocumentoId(int IdDocumento, int EmpresaId);
    }
}
