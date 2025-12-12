using App.Models.Models.TblInd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories;

public interface ITiposIndicadoresEstrategicosRepository
{
    Task<TBL_ind_TiposIndicadoresEstrategicosModels> GetDataTiposIndicadoresEstrategicosByTipo(int EmpresaId, int idTipoIndiEstra);
    Task<List<TBL_ind_TiposIndicadoresEstrategicosModels>> ListTiposIndicadoresEstrategicosByEmpresaId(int EmpresaId);
}
