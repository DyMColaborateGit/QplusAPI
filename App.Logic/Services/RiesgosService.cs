using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models;
using App.Models.Models.TblRgp;
namespace App.logic.Services
{
    public class RiesgosService : IRiesgosService
    {
        private readonly IRiesgosRepository _riesgosRepository;

        public RiesgosService(IRiesgosRepository riesgosRepository)
        {
            _riesgosRepository = riesgosRepository;
        }

        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos()
        {
            return await _riesgosRepository.GetListaRiesgos();
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int ProcesoId)
        {
            return await _riesgosRepository.GetListaCodigoRiesgoByProcesoId(ProcesoId);
        }
    }
}
