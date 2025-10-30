
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IClasesRepository
    {
        Task<List<Tbl_rgp_ClasesModels>> GetListaClases();
        Task<List<Tbl_rgp_ClasesModels>> GetListaClasesByEmpresaByEstado(int EmpresaId, bool Estado);
    }
}
