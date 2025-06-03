using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface ITemasBrechaPRepository
    {
        Task<List<Tbl_ghu_TemasBrechaPModels>> GetListaTemasBrechaP(int EmpresaId);
    }
}
