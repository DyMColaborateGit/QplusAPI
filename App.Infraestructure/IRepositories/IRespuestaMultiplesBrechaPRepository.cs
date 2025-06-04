using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IRespuestaMultiplesBrechaPRepository
    {
        Task<List<Tbl_ghu_RespuestaMultiplesBrechaPModels>> GetListaRespuestaMultiplesBrechaP(int EmpresaId);
    }
}
