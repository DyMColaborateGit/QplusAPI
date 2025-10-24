
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class EvaluacionRiesgoService : IEvaluacionRiesgoService
    {
        private readonly IEvaluacionRiesgoRepository _evaluacionRiesgoRepository;

        public EvaluacionRiesgoService(IEvaluacionRiesgoRepository evaluacionRiesgoRepository)
        {
            _evaluacionRiesgoRepository = evaluacionRiesgoRepository;
        }

        public async Task<List<Tbl_rgp_EvaluacionRiesgoModels>> GetListaEvaluacionRiesgo(int EmpresaId)
        {
            return await _evaluacionRiesgoRepository.GetListaEvaluacionRiesgo(EmpresaId);
        }
    }
}
