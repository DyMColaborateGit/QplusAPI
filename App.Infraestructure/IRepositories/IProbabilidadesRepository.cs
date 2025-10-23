
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IProbabilidadesRepository
    {
        Task<List<Tbl_rgp_ProbabilidadesModels>> GetListaProbabilidades(int empresaId);
    }
}
