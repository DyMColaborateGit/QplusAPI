using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoEvaluacionadaController : ControllerBase
    {
        private readonly IResultadoEvaluacionadaService _resultadoEvaluacionadaService;

        public ResultadoEvaluacionadaController(IResultadoEvaluacionadaService resultadoEvaluacionadaService)
        {
            _resultadoEvaluacionadaService = resultadoEvaluacionadaService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetDataPreguntasAda/{EvaluacionId}")]
        public async Task<GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>>> GetDataPreguntasAdaByEvaluaciones(long EvaluacionId)
        {
            GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>> resultado = new GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>>();
            try
            {
                resultado.Data = await _resultadoEvaluacionadaService.GetListResultadoEvaluacionadaByEvaluacionId(EvaluacionId);
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
        [HttpGet("PutResultadosEvaADAPreguntasMult/{EvaluacionId}/{IdResultado}/{IdHijo}")]
        public async Task<GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>>> PutResultadosEvaADAPreguntasMult(long EvaluacionId, long IdResultado, int IdHijo)
        {
            GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>> resultado = new GetResponse<List<TBL_com_ResultadoEvaluacionADAModels>>();
            try
            {
                resultado.Data = await _resultadoEvaluacionadaService.PutResultadoEvaluacionadaByEvaluacionId(EvaluacionId, IdHijo, IdResultado);
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
        [HttpPost("PostResultadosEvaadaPreguntas")]
        public async Task<GetResponse<TBL_com_ResultadoEvaluacionADAModels>> PutResultadosEvaadaPreguntas(TBL_com_ResultadoEvaluacionADAModels ObjPut)
        {
            GetResponse<TBL_com_ResultadoEvaluacionADAModels> resultado = new GetResponse<TBL_com_ResultadoEvaluacionADAModels>();
            try
            {
                resultado.Data = await _resultadoEvaluacionadaService.PutResultadoEvaluacionadaTxt(ObjPut);
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
