using App.Infraestructure.IRepositories;
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

        public async Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId)
        {
            return await _solicitudPersonalRepository.GetListaSolicitudesPersonal(EmpresaId);
        }
    }
}
