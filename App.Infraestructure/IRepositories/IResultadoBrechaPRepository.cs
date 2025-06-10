using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IResultadoBrechaPRepository
    {
        Task<Tbl_ghu_ResultadoBrechaPModels> ObjResultadoBrechaP(int ResultadoBrechaId);
        Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId);
        Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjRequest);
        Task<Tbl_ghu_ResultadoBrechaPModels> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate);

    }
}
