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
        public async Task<Tbl_ghu_ResultadoBrechaPModels> GetObjResultadoBrechaP(int ResultadoBrechaId)
        {
            var getResult = await _resultadoBrechaPRepository.ObjResultadoBrechaP(ResultadoBrechaId);
            return getResult;
        }
        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId)
        {
            return await _resultadoBrechaPRepository.GetListaResultadoBrechaP(EmpresaId);
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjRequest)
        {
            Tbl_ghu_ResultadoBrechaPModels ObjResultadoBrecha = await _resultadoBrechaPRepository.ObjResultadoBrechaP(ObjRequest.ResultadoBrechaId);

            ObjRequest.ResultadoBrechaId = ObjResultadoBrecha.ResultadoBrechaId;
            ObjRequest.EmpresaId = ObjResultadoBrecha.EmpresaId;
            ObjRequest.PreguntaId = ObjResultadoBrecha.PreguntaId;
            ObjRequest.UsuarioAnalisisBrecha = ObjResultadoBrecha.UsuarioAnalisisBrecha;
            ObjRequest.TipoPregunta = ObjResultadoBrecha.TipoPregunta;
            ObjRequest.TemaBrecha = ObjResultadoBrecha.TemaBrecha;
            ObjRequest.RelFuncSolicitudPId = ObjResultadoBrecha.RelFuncSolicitudPId;
            ObjRequest.PadreId = ObjResultadoBrecha.PadreId;
            ObjRequest.HijoId = ObjResultadoBrecha.HijoId;
            ObjRequest.TextoPregunta = ObjResultadoBrecha.TextoPregunta;
            ObjRequest.TextoSMultiple = ObjResultadoBrecha.TextoSMultiple;
            ObjRequest.RespuestaAbierta = ObjResultadoBrecha.RespuestaAbierta;
            ObjRequest.ResultadoSMultiple = ObjResultadoBrecha.ResultadoSMultiple;

            await _resultadoBrechaPRepository.PostResultadosBrechaP(ObjRequest);

            return ObjRequest;
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            var ObjResult = await _resultadoBrechaPRepository.PutResultadoBrechaP(ObjUpdate);
            return ObjResult;
        }
    }
}
