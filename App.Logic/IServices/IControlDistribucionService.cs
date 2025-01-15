using App.Models.Models;
using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IControlDistribucionService
    {
        Task<List<Control_distribucionModels>> GetControlDistDocumentoByDocumentoId(int IdDocumento, int EmpresaId);
    }
}
