using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IRespuestaMultiplesBrechaPService
    {
        Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasMultiplesBrechaP(int EmpresaId);
        Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasBrechaPByPreguntaId(int PreguntaId);
    }
}
