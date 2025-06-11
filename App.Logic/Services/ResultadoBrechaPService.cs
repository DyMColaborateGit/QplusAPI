using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
using App.Models.Models.TblInd;

namespace App.logic.Services
{
    public class ResultadoBrechaPService : IResultadoBrechaPService
    {
        private readonly IResultadoBrechaPRepository _resultadoBrechaPRepository;

        public ResultadoBrechaPService(IResultadoBrechaPRepository resultadoBrechaPRepository)
        {
            _resultadoBrechaPRepository = resultadoBrechaPRepository;
        }
        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaPById(int RelFuncSolicitudPId)
        {
            return await _resultadoBrechaPRepository.GetListaResultadoBrechaPById(RelFuncSolicitudPId);
        }
        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId)
        {
            return await _resultadoBrechaPRepository.GetListaResultadoBrechaP(EmpresaId);
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels objCreate)
        {
            return await _resultadoBrechaPRepository.PostResultadosBrechaP(objCreate);
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            var ObjResult = await _resultadoBrechaPRepository.PutResultadoBrechaP(ObjUpdate);
            return ObjResult;
        }
    }
}
