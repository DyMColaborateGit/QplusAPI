using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblInd;
using System;

namespace App.logic.Services
{
    public class ResultIndiCoporpService: IResultIndiCoporpService
    {
        private readonly IResultIndiCoporpRepository _resultIndiCoporpRepository;

        public ResultIndiCoporpService(IResultIndiCoporpRepository resultIndiCoporpRepository)
        {
            _resultIndiCoporpRepository = resultIndiCoporpRepository;
        }

        public async Task<JOINTBL_ind_ResultIndiCoporpModels> GetresultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
        {
            return await _resultIndiCoporpRepository.ResultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, InAnio);
        }

        public async Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResutIndiCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
        {
            return await _resultIndiCoporpRepository.ListResultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, InAnio);
        }
    }
}
