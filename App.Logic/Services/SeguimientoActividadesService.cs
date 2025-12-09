
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services
{
    public class SeguimientoActividadesService : ISeguimientoActividadesService
    {
        private readonly ISeguimientoActividadesRepository _seguimientoActividadesRepository;

        public SeguimientoActividadesService(ISeguimientoActividadesRepository seguimientoActividadesRepository)
        {
            _seguimientoActividadesRepository = seguimientoActividadesRepository;
        }
        public async Task<List<TBL_com_SeguimientoActividadesModels>> GetListaSeguimientoActividades(int InIdActividadPIM)
        {
            return await _seguimientoActividadesRepository.GetListaSeguimientoActividades(InIdActividadPIM);
        }
    }
}
