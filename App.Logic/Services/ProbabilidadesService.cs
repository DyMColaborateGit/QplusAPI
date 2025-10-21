
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class ProbabilidadesService : IProbabilidadesService
    {
        private readonly IProbabilidadesRepository _probabilidadesRepository;

        public ProbabilidadesService(IProbabilidadesRepository probabilidadesRepository)
        {
            _probabilidadesRepository = probabilidadesRepository;
        }

        public async Task<List<Tbl_rgp_ProbabilidadesModels>> GetListaProbabilidades()
        {
            return await _probabilidadesRepository.GetListaProbabilidades();
        }
    }
}
