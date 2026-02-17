
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IZonasRiesgoRepository
    {
        Task<List<Tbl_rgp_ZonasModels>> GetListaZonasRiesgo();
    }
}
