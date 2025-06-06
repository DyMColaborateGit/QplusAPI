using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface ISolicitudPersonalRepository
    {
        Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId);
    }
}
