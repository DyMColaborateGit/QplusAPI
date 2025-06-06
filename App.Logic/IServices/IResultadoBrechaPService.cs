using App.Models.Models.TblAud;
using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IResultadoBrechaPService
    {
        Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId);
        Task<Tbl_ghu_ResultadoBrechaPModels> UpdateResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate);
    }
}
