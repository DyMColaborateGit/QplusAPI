using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Share;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ResultadosEvaluacionController : ControllerBase
    {
        private readonly IResultadosEvaluacionService _competenciasService;
        public ResultadosEvaluacionController(IResultadosEvaluacionService competenciasService) 
        { 
            _competenciasService = competenciasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetCompetenciasByEvaluacionId/{EvaluacionId}")]
        public async Task<GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>> GetCompetenciasByEvaluacionId(long EvaluacionId)
        {
            GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> resultado = new GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>();
            try
            {
                resultado.Data = await _competenciasService.GetListCompetenciasByEvaluacionId(EvaluacionId);
                resultado.StatusCode = (int)HttpCodes.OK;
                resultado.Message = new HttpCodesMessage().OK;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.StatusCode = (int)HttpCodes.INTERNALERROR;
                resultado.Message = new HttpCodesMessage().INTERNALERROR;
                resultado.CathError = ex.Message.ToString();
                return resultado;
            }
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateResultadoObservacionCompetencias/{EvaluacionId}")]
        public async Task<GetResponse<Tbl_com_ResultadosEvaluacionModels>> UpdateResultadoObservacionCompetencias(long EvaluacionId, RequestUpdateObservaciones ObjPut)
        {
            GetResponse<Tbl_com_ResultadosEvaluacionModels> resultado = new GetResponse<Tbl_com_ResultadosEvaluacionModels>();
            try
            {
                resultado.Data = await _competenciasService.PutResultadoEvaluacionObservacion(EvaluacionId, ObjPut);
                resultado.StatusCode = (int)HttpCodes.OK;
                resultado.Message = new HttpCodesMessage().OK;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.StatusCode = (int)HttpCodes.INTERNALERROR;
                resultado.Message = new HttpCodesMessage().INTERNALERROR;
                resultado.CathError = ex.Message.ToString();
                return resultado;
            }
        }
    }
}
