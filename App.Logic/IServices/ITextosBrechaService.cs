using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface ITextosBrechaService
    {
        Task<List<Tbl_ghu_TextosBrechaModels>> GetListaTextosBrecha(int EmpresaId);
    }
}
