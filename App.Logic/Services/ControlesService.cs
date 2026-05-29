using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;
namespace App.logic.Services
{
    public class ControlesService : IControlesService
    {
        private readonly IControlesRepository _controlesRepository;

        public ControlesService(IControlesRepository controlesRepository)
        {
            _controlesRepository = controlesRepository;
        }

        public async Task<List<Tbl_rgp_ControlesModels>> GetListaControlesRiesgos(int EmpresaId)
        {
            return await _controlesRepository.GetListaControlesRiesgos(EmpresaId);
        }
    }
}
