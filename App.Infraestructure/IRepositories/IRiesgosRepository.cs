
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IRiesgosRepository
    {
        Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos(int EmpresaId);
        Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int EmpresaId, int ProcesoId, string EstadoProceso);
        Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgosFiltros(int EmpresaId, DateTime? FechaInicio, DateTime? FechaFin, int ProcesoId, string Codigo, int SubprocesoId, int ClaseId, int IdAgente);
    }
}
