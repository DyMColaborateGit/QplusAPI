using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
using App.Models.Models.TblInd;

namespace App.logic.IServices
{
    public interface IResultadoBrechaPService
    {
        Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaPById(int RelFuncSolicitudPId);
        Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId);
        Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels objCreate);
        Task<Tbl_ghu_ResultadoBrechaPModels> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate);
    }
}
