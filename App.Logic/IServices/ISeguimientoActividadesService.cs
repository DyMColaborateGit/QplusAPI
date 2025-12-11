using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface ISeguimientoActividadesService
    {
        Task<List<TBL_com_SeguimientoActividadesModels>> GetListaSeguimientoActividades(int InIdActividadPIM);
    }
}
