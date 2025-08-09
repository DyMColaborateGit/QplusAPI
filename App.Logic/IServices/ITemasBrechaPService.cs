using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface ITemasBrechaPService
    {
        Task<List<Tbl_ghu_TemasBrechaPModels>> GetListaTemasBrechaP(int EmpresaId);
    }
}
