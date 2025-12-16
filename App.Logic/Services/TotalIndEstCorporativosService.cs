
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblInd;

namespace App.logic.Services
{
    public class TotalIndEstCorporativosService : ITotalIndEstCorporativosService
    {
        private readonly ITotalIndEstCorporativosRepository _totalIndEstCorporativosRepository;

        public TotalIndEstCorporativosService(ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository)
        {
            _totalIndEstCorporativosRepository = totalIndEstCorporativosRepository;
        }
        public async Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(int EvaluacionId, int EmpresaId)
        {
            return await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(EvaluacionId, EmpresaId);
        }
    }
}
