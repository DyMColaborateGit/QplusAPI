
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

        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion(int EmpresaId)
        {
            return await _parametrosValoracionRepository.GetListaParametrosValoracion(EmpresaId);
        }
        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaColoresZonas(int IdZona)
        {
            return await _parametrosValoracionRepository.GetListaColoresZonas(IdZona);
        }
    }
}
