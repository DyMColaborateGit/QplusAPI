
using App.Models.Models.TblRgp;

namespace App.logic.IServices;
public interface IParametrosValoracionService
{
    Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion(int EmpresaId);
    Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaColoresZonas(int IdZona);
}
