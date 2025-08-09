using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class TemasBrechaPService : ITemasBrechaPService
    {
        private readonly ITemasBrechaPRepository _temasBrechaPRepository;

        public TemasBrechaPService(ITemasBrechaPRepository temasBrechaPRepository)
        {
            _temasBrechaPRepository = temasBrechaPRepository;
        }

        public async Task<List<Tbl_ghu_TemasBrechaPModels>> GetListaTemasBrechaP(int EmpresaId)
        {
            return await _temasBrechaPRepository.GetListaTemasBrechaP(EmpresaId);
        }
    }
}
