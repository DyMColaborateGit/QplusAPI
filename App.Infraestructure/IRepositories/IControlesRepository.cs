
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IControlesRepository
    {
        Task<List<Tbl_rgp_ControlesModels>> GetListaControlesRiesgos(int EmpresaId);
    }
}
