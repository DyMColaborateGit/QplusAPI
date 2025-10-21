
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IParametrosValoracionRepository
    {
        Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion();
    }
}
