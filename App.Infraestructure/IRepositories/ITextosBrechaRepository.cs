using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface ITextosBrechaRepository
    {
        Task<List<Tbl_ghu_TextosBrechaModels>> GetListaTextosBrecha(int EmpresaId);
    }
}
