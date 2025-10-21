
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IRiesgosRepository
    {
        Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos();

    }
}
