using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
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
        public async Task<TBL_com_ActividadesPIDModels> GetObjActividadesPDI(int EmpresaId)
        {
            return await _actividadesPIDRepository.GetObjActividadesPDI(EmpresaId);
        }
        public async Task<List<TBL_com_ActividadesPIDModels>> GetListaActividadesPDI(int EmpresaId)
        {
            return await _actividadesPIDRepository.GetListaActividadesPDI(EmpresaId);
        }
        public async Task<List<TBL_com_ActividadesPIDModels>> GetListaActividadesPDIByEvaluadoIdByAnio(int EmpresaId, long EvaluadoId, int InAnio)
        {
            return await _actividadesPIDRepository.GetListaActividadesPDIByEvaluadoIdByAnio(EmpresaId, EvaluadoId, InAnio);
        }
        public async Task<TBL_com_ActividadesPIDModels> PostCreatenewActividadPID(TBL_com_ActividadesPIDModels ObjRequest)
        {
            return await _actividadesPIDRepository.CreateActividadesPID(ObjRequest);
        }
    }
}
