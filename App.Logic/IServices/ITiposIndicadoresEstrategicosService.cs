using App.Models.Models.TblInd;
using System;

namespace App.logic.IServices
{
    public interface ITiposIndicadoresEstrategicosService
    {
        Task<List<TBL_ind_TiposIndicadoresEstrategicosModels>> GetListTiposIndicadoresEstrategicos(int EmpresaId);
    }
}
