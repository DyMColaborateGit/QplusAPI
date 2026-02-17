
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class ClasesService : IClasesService
    {
        private readonly IClasesRepository _clasesRepository;

        public ClasesService(IClasesRepository clasesRepository)
        {
            _clasesRepository = clasesRepository;
        }

        public async Task<List<Tbl_rgp_ClasesModels>> GetListaClases()
        {
            return await _clasesRepository.GetListaClases();
        }

        public async Task<List<Tbl_rgp_ClasesModels>> GetListaClasesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            return await _clasesRepository.GetListaClasesByEmpresaByEstado(EmpresaId, Estado);
        }
    }
}
