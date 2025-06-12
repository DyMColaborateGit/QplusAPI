using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class RelFuncSolicitudPService : IRelFuncSolicitudPService
    {
        private readonly IRelFuncSolicitudPRepository _relFuncSolicitudPRepository;

        public RelFuncSolicitudPService(IRelFuncSolicitudPRepository relFuncSolicitudPRepository)
        {
            _relFuncSolicitudPRepository = relFuncSolicitudPRepository;
        }
        public async Task<Tbl_ghu_RelFuncSolicitudPModels> GetObjRelFuncSolicitudPById(int RelFuncSolicitudPId)
        {
            return await _relFuncSolicitudPRepository.GetObjRelFuncSolicitudPById(RelFuncSolicitudPId);
        }
        public async Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId)
        {
            return await _relFuncSolicitudPRepository.GetListaRelFuncSolicitudP(EmpresaId);
        }
        public async Task<Tbl_ghu_RelFuncSolicitudPModels> PutRelFuncSolicitudP(Tbl_ghu_RelFuncSolicitudPModels ObjUpdate)
        {
            var ObjResult = await _relFuncSolicitudPRepository.PutRelFuncSolicitudP(ObjUpdate);
            return ObjResult;
        }
    }
}
