using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class ActividadesIndicadoresService: IActividadesIndicadoresService
    {
        private readonly IActividadesIndicadoresRepository _actividadesIndicadoresRepository;

        public ActividadesIndicadoresService(IActividadesIndicadoresRepository actividadesIndicadoresRepository)
        {
            _actividadesIndicadoresRepository = actividadesIndicadoresRepository;
        }

        public async Task<List<TBL_com_ActividadesIndicadoresModels>> PostCreatenewActividadesIndicadores(List<TBL_com_ActividadesIndicadoresModels> ObjRequest, int ActividadId)
        {
            foreach (var item in ObjRequest)
            {
                item.ActividadId = ActividadId;
            }
            return await _actividadesIndicadoresRepository.CreateActividadesIndicadoresList(ObjRequest);
        }
    }
}
