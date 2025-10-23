
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories;
public interface IConsecuenciasRepository
{
    Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias(int EmpresaId);
    Task<Tbl_rgp_ConsecuenciasModels> GetObjConsecuenciaByEmpresaIdByValor(int EmpresaId, int Valor);

}
