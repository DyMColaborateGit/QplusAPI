using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories
{
    public interface ISeguimientoActividadesRepository
    {
        Task<List<TBL_com_SeguimientoActividadesModels>> GetListaSeguimientoActividades(int InIdActividadPIM);
    }
}
