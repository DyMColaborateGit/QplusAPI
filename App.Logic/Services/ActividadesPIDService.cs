using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class ActividadesPIDService: IActividadesPIDService
    {
        private readonly IActividadesPIDRepository _actividadesPIDRepository;

        public ActividadesPIDService(IActividadesPIDRepository actividadesPIDRepository) 
        {
            _actividadesPIDRepository = actividadesPIDRepository;
        }  

        public async Task<TBL_com_ActividadesPIDModels> PostCreatenewActividadPID(TBL_com_ActividadesPIDModels ObjRequest)
        {
            return await _actividadesPIDRepository.CreateActividadesPID(ObjRequest);
        }
    }
}
