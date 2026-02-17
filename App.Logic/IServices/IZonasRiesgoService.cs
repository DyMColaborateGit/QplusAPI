
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface IZonasRiesgoService
    {
        Task<List<Tbl_rgp_ZonasModels>> GetListaZonasRiesgo();
    }
}
