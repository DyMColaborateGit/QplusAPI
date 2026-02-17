
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;
using System.Drawing;

namespace App.logic.IServices;
public interface IConsecuenciasService
{
    Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias(int EmpresaId);
    Task<Tbl_rgp_ConsecuenciasModels> GetObjConsecuenciaByEmpresaIdByValor(int EmpresaId, int Valor);

}
