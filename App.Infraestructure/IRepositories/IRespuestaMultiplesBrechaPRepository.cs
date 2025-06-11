using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IRespuestaMultiplesBrechaPRepository
    {
        Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasMultiplesBrechaP(int EmpresaId);
        Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasBrechaPByPreguntaId(int PreguntaId);
    }
}
