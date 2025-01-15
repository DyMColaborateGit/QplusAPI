using App.Models.Models.TblCom;
using System;


namespace App.Infraestructure.IRepositories
{
    public interface IActividadesCompetenciasRepository
    {
        Task<List<TBL_com_ActividadesCompetenciasModels>> CreateActividadesCompetenciasList(List<TBL_com_ActividadesCompetenciasModels> objCreate);
    }
}
