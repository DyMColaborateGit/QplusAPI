
using App.Models.Models.TblRgp;

namespace App.logic.IServices;
public interface IParametrosValoracionService
{
    Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion();
}
