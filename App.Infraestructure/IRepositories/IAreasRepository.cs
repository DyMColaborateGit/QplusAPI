using App.Models.Models.T;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IAreasRepository
    {
        Task<List<AreasModels>> GetListMacroProcesos(int EmpresaId);
    }
}
