
using App.Models.Models;
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface ITipoAnalisisService
    {
        Task<List<Tbl_rgp_TipoAnalisisModels>> GetListaTipoAnalisis(int EmpresaId);

    }
}
