using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IPreguntasBrechaPService
    {
        Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaP(int EmpresaId);
    }
}
