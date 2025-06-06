using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class ResultadoBrechaPService : IResultadoBrechaPService
    {
        private readonly IResultadoBrechaPRepository _resultadoBrechaPRepository;

        public ResultadoBrechaPService(IResultadoBrechaPRepository resultadoBrechaPRepository)
        {
            _resultadoBrechaPRepository = resultadoBrechaPRepository;
        }

        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId)
        {
            return await _resultadoBrechaPRepository.GetListaResultadoBrechaP(EmpresaId);
        }

        public async Task<Tbl_ghu_ResultadoBrechaPModels> UpdateResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            var ObjResult = await _resultadoBrechaPRepository.UpdateResultadoBrechaP(ObjUpdate);
            return ObjResult;
        }
    }
}
