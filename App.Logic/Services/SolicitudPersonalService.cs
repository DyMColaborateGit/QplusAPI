using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class SolicitudPersonalService : ISolicitudPersonalService
    {
        private readonly ISolicitudPersonalRepository _solicitudPersonalRepository;

        public SolicitudPersonalService(ISolicitudPersonalRepository solicitudPersonalRepository)
        {
            _solicitudPersonalRepository = solicitudPersonalRepository;
        }
        public async Task<Tbl_ghu_SolicitudPersonalModels> GetObjSolicitudPersonalById(int SolicitudId)
        {
            return await _solicitudPersonalRepository.GetObjSolicitudPersonalById(SolicitudId);
        }
        public async Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId)
        {
            return await _solicitudPersonalRepository.GetListaSolicitudesPersonal(EmpresaId);
        }
        public async Task<Tbl_ghu_SolicitudPersonalModels> PutSolicitudPById(Tbl_ghu_SolicitudPersonalModels ObjUpdate)
        {
            var ObjResult = await _solicitudPersonalRepository.PutSolicitudPById(ObjUpdate);
            return ObjResult;
        }
    }
}
