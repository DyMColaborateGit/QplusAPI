using App.Models.Models.TblMast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface ISistemasGestionRepository
    {
        Task<List<TBL_mast_SistemasGestionModels>> GetListaSistemasGestionByEmpresaId(int EmpresaId);

    }
}
