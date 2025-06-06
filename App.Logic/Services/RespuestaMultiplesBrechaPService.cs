using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class RespuestaMultiplesBrechaPService : IRespuestaMultiplesBrechaPService
    {
        private readonly IRespuestaMultiplesBrechaPRepository _respuestaMultiplesBrechaPRepository;

        public RespuestaMultiplesBrechaPService(IRespuestaMultiplesBrechaPRepository respuestaMultiplesBrechaPRepository)
        {
            _respuestaMultiplesBrechaPRepository = respuestaMultiplesBrechaPRepository;
        }

        public async Task<List<Tbl_ghu_RespuestaMultiplesBrechaPModels>> GetListaRespuestaMultiplesBrechaP(int EmpresaId)
        {
            return await _respuestaMultiplesBrechaPRepository.GetListaRespuestaMultiplesBrechaP(EmpresaId);
        }
    }
}
