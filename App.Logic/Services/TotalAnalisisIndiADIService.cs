using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services
{
    public class TotalAnalisisIndiADIService : ITotalAnalisisIndiADIService
    {
        private readonly ITotalAnalisisIndiADIRepository _totalAnalisisIndiADIRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;
        public TotalAnalisisIndiADIService(ITotalAnalisisIndiADIRepository totalAnalisisIndiADIRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _totalAnalisisIndiADIRepository = totalAnalisisIndiADIRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }

        public async Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicosADI(long EvaluacionId, int EmpresaId)
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            return await _totalAnalisisIndiADIRepository.TotalAnalisisIndicadoresEstrategicosADI(progEva, EmpresaId);
        }
    }
}
