using App.Models.Models.TblGhu;

namespace App.logic.IServices
{
    public interface ISolicitudPersonalService
    {
        Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId);
    }
}
