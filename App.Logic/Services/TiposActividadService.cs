using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
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
        public async Task<TBL_com_TiposActividadModels> GetDataTiposActividadById(int InIdTipoActividad)
        {
            return await _tiposActividadRepository.GetDataTiposActividadById(InIdTipoActividad);
        }
        public async Task<List<TBL_com_TiposActividadModels>> GetListTiposActividadByCtegoriaIdEstado(int EmpresaId, int CategoriaId, bool Estado)
        {
            return await _tiposActividadRepository.ListTiposActividadByCtegoriaIdEstado(EmpresaId, CategoriaId, Estado);
        }
        public async Task<List<TBL_com_TiposActividadModels>> GetLisTiposActividadesByEmpresaId(int EmpresaId)
        {
            return await _tiposActividadRepository.GetLisTiposActividadesByEmpresaId(EmpresaId);
        }
    }
}
