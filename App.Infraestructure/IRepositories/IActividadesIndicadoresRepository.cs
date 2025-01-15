using App.Models.Models.TblCom;
using System;


namespace App.Infraestructure.IRepositories
{
    public interface IActividadesIndicadoresRepository
    {
        Task<List<TBL_com_ActividadesIndicadoresModels>> CreateActividadesIndicadoresList(List<TBL_com_ActividadesIndicadoresModels> objCreate);
    }
}
