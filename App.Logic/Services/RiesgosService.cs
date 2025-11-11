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

        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos(int EmpresaId)
        {
            return await _riesgosRepository.GetListaRiesgos(EmpresaId);
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int EmpresaId, int ProcesoId, string EstadoProceso)
        {
            return await _riesgosRepository.GetListaCodigoRiesgoByProcesoId(EmpresaId, ProcesoId, EstadoProceso);
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgosFiltros(int EmpresaId, DateTime? FechaInicio, DateTime? FechaFin, int ProcesoId, string Codigo, int SubprocesoId, int ClaseId, int IdAgente)
        {
            return await _riesgosRepository.GetListaRiesgosFiltros(EmpresaId, FechaInicio, FechaFin, ProcesoId, Codigo, SubprocesoId, ClaseId, IdAgente);
        }
    }
}
