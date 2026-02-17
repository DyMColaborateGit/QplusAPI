using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class TipoAnalisisService : ITipoAnalisisService
    {
        private readonly ITipoAnalisisRepository _tipoAnalisisRepository;
        public TipoAnalisisService(ITipoAnalisisRepository tipoAnalisisRepository)
        {
            _tipoAnalisisRepository = tipoAnalisisRepository;
        }
        public async Task<List<Tbl_rgp_TipoAnalisisModels>> GetListaTipoAnalisis(int EmpresaId)
        {
            return await _tipoAnalisisRepository.GetListaTipoAnalisis(EmpresaId);
        }
    }
}
