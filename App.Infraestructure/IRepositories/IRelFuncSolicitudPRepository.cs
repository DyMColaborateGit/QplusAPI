using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IRelFuncSolicitudPRepository
    {
        Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId);
    }
}
