using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using Microsoft.EntityFrameworkCore;


namespace App.logic.Services
{
    public class TiposActividadService: ITiposActividadService
    {
        private readonly ITiposActividadRepository _tiposActividadRepository;

        public TiposActividadService(ITiposActividadRepository tiposActividadRepository)
        {
            _tiposActividadRepository = tiposActividadRepository;
        }

        public async Task<List<TBL_com_TiposActividadModels>> GetListTiposActividadByCtegoriaIdEstado(int EmpresaId, int CategoriaId, bool Estado)
        {
            return await _tiposActividadRepository.ListTiposActividadByCtegoriaIdEstado(EmpresaId, CategoriaId, Estado);
        }

    }
}
