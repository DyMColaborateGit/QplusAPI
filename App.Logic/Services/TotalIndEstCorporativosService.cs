
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;

namespace App.logic.Services
{
    public class TotalIndEstCorporativosService : ITotalIndEstCorporativosService
    {
        private readonly ITotalIndEstCorporativosRepository _totalIndEstCorporativosRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;

        public TotalIndEstCorporativosService(ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _totalIndEstCorporativosRepository = totalIndEstCorporativosRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }
        public async Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(int EvaluacionId, int EmpresaId)
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            return await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(progEva, EmpresaId);
            //return await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(EvaluacionId, EmpresaId);
        }
    }
}
