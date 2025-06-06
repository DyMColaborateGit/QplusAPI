using App.Infraestructure.IRepositories;
using App.logic.IServices;
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

        public async Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId)
        {
            return await _relFuncSolicitudPRepository.GetListaRelFuncSolicitudP(EmpresaId);
        }
    }
}
