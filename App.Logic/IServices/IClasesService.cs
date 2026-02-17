
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface IClasesService
    {
        Task<List<Tbl_rgp_ClasesModels>> GetListaClases();
        Task<List<Tbl_rgp_ClasesModels>> GetListaClasesByEmpresaByEstado(int EmpresaId, bool Estado);
    }
}
