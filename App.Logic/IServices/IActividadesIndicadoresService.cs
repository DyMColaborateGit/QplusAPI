using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices
{
    public interface IActividadesIndicadoresService
    {
        Task<List<TBL_com_ActividadesIndicadoresModels>> PostCreatenewActividadesIndicadores(List<TBL_com_ActividadesIndicadoresModels> ObjRequest, int ActividadId);
    }
}
