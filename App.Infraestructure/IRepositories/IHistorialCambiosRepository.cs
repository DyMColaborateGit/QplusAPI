using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IHistorialCambiosRepository
    {
        Task<List<Historial_cambiosModels>> GetHistorialesDocumentoByDocumentoId(int IdDocumento, int EmpresaId);
    }
}
