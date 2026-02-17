using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblInd;
using System;

namespace App.logic.Services
{
    public class ResultIndiCoporpService: IResultIndiCoporpService
    {
        private readonly IResultIndiCoporpRepository _resultIndiCoporpRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;

        public ResultIndiCoporpService(IResultIndiCoporpRepository resultIndiCoporpRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _resultIndiCoporpRepository = resultIndiCoporpRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }

        public async Task<JOINTBL_ind_ResultIndiCoporpModels> GetresultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
        {
            return await _resultIndiCoporpRepository.ResultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, InAnio);
        }

        public async Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResutIndiCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
        {
            return await _resultIndiCoporpRepository.ListResultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, InAnio);
        }
        public async Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResultadoIndicadoresCorporativos(int EvaluacionId, int EmpresaId)
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            return await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(progEva, EmpresaId);
            //return await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(EvaluacionId, EmpresaId);
        }
    }
}
