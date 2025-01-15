using App.Models.Models.TblInd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IPesosxTipoIndEstxTipoNivelEstRepository
    {
        Task<TBL_ind_PesosxTipoIndEstxTipoNivelEstModels> ObjPesosxTipoIndEstxTipoNivelEst(int EmpresaId, int TipoNivelEst, int IdtipoIndicadorEst);
    }
}
