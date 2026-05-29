
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface IControlesService
    {
        Task<List<Tbl_rgp_ControlesModels>> GetListaControlesRiesgos(int EmpresaId);
    }
}
