using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class ActividadesCompetenciasService: IActividadesCompetenciasService
    {
        private readonly IActividadesCompetenciasRepository _actividadesCompetenciasRepository;

        public ActividadesCompetenciasService(IActividadesCompetenciasRepository actividadesCompetenciasRepository)
        {
            _actividadesCompetenciasRepository = actividadesCompetenciasRepository;
        }

        public async Task<List<TBL_com_ActividadesCompetenciasModels>> PostCreatenewActividadesCompetencias(List<TBL_com_ActividadesCompetenciasModels> ObjRequest, int ActividadId)
        {
            foreach (var item in ObjRequest)
            {
                item.ActividadId = ActividadId;
            }
            return await _actividadesCompetenciasRepository.CreateActividadesCompetenciasList(ObjRequest);
        }
    }
}
