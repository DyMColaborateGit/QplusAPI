using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.T;

namespace App.logic.Services
{
    public class AreasService : IAreasService
    {
        private readonly IAreasRepository _areasRepository;


        public AreasService(IAreasRepository areasRepository)
        {
            _areasRepository = areasRepository;
        }

        public async Task<List<AreasModels>> GetListMacroProcesos(int EmpresaId)
        {
            return await _areasRepository.GetListMacroProcesos(EmpresaId);
        }
    }
}
