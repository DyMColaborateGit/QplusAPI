using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IRespuestaMultiplesBrechaPService
    {
        Task<List<Tbl_ghu_RespuestaMultiplesBrechaPModels>> GetListaRespuestaMultiplesBrechaP(int EmpresaId);
    }
}
