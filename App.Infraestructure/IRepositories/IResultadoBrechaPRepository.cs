using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IResultadoBrechaPRepository
    {
        Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId);
        Task<Tbl_ghu_ResultadoBrechaPModels> UpdateResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate);

    }
}
