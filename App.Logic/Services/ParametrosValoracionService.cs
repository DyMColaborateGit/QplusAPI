
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class ParametrosValoracionService : IParametrosValoracionService
    {
        private readonly IParametrosValoracionRepository _parametrosValoracionRepository;

        public ParametrosValoracionService(IParametrosValoracionRepository parametrosValoracionRepository)
        {
            _parametrosValoracionRepository = parametrosValoracionRepository;
        }

        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion()
        {
            return await _parametrosValoracionRepository.GetListaParametrosValoracion();
        }
    }
}
