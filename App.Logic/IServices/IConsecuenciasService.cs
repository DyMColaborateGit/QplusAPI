
using App.Models.Models.TblRgp;

namespace App.logic.IServices;
public interface IConsecuenciasService
{
    Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias();
}
