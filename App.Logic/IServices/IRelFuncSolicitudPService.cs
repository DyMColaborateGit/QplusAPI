using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface IRelFuncSolicitudPService
    {
        Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId);
    }
}
