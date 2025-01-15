using App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IControlDistribucionRepository
    {
        Task<List<Control_distribucionModels>> GetControlDistDocumentoByDocumentoId(int IdDocumento, int EmpresaId);
    }
}
