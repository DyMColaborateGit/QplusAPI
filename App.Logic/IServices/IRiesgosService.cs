
using App.Models.Models;
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface IRiesgosService
    {
        Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos();
        Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int ProcesoId);
    }
}
