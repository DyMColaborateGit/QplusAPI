using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IPreguntasBrechaPService
    {
        Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaP(int EmpresaId);
        Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaPByTemaId(int TemaBrechaId);

    }
}
