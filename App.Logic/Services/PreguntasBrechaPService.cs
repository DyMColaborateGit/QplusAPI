using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class PreguntasBrechaPService : IPreguntasBrechaPService
    {
        private readonly IPreguntasBrechaPRepository _preguntasBrechaPRepository;

        public PreguntasBrechaPService(IPreguntasBrechaPRepository preguntasBrechaPRepository)
        {
            _preguntasBrechaPRepository = preguntasBrechaPRepository;
        }

        public async Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaP(int EmpresaId)
        {
            return await _preguntasBrechaPRepository.GetListaPreguntasBrechaP(EmpresaId);
        }
    }
}
