using App.Models.Models;
using App.Models.Models.TblDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IProductosRepository
    {
        Task<List<ProductosModels>> GetListaSubProcesosByIdProcesoActivos(int IdProceso);
    }
}
