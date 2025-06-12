using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IRelFuncSolicitudPRepository
    {
        Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId);
        Task<Tbl_ghu_RelFuncSolicitudPModels> GetObjRelFuncSolicitudPById(int RelFuncSolicitudPId);
        Task<Tbl_ghu_RelFuncSolicitudPModels> PutRelFuncSolicitudP(Tbl_ghu_RelFuncSolicitudPModels ObjUpdate);

    }
}
