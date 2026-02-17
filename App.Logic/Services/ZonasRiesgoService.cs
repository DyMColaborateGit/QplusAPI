
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class ZonasRiesgoService : IZonasRiesgoService
    {
        private readonly IZonasRiesgoRepository _zonasRiesgoRepository;

        public ZonasRiesgoService(IZonasRiesgoRepository zonasRiesgoRepository)
        {
            _zonasRiesgoRepository = zonasRiesgoRepository;
        }

        public async Task<List<Tbl_rgp_ZonasModels>> GetListaZonasRiesgo()
        {
            return await _zonasRiesgoRepository.GetListaZonasRiesgo();
        }
    }
}
