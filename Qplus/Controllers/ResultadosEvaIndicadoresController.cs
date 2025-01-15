using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.Share;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosEvaIndicadoresController : ControllerBase
    {
        private readonly IResultadosEvaIndicadoresService _resultadosEvaIndicadoresService;
        private readonly IGestEvaluacionService _gestEvaluacionService;

        public ResultadosEvaIndicadoresController(IResultadosEvaIndicadoresService resultadosEvaIndicadoresService, IGestEvaluacionService gestEvaluacionService)
        {
            _resultadosEvaIndicadoresService = resultadosEvaIndicadoresService;
            _gestEvaluacionService = gestEvaluacionService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListResultadosIndicadores/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>> GetListResultadosIndicadores(long EvaluacionId, int EmpresaId)
        {
            GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> resultado = new GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>();
            try
            {
                resultado.Data = await _resultadosEvaIndicadoresService.GetListResultadosIndicadores(EvaluacionId, new int[] { 6, 5 }, EmpresaId);
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
        [HttpGet("GetListResultadoIndicadoresEstrategicos/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>> GetListResultadoIndicadoresEstrategicos(long EvaluacionId, int EmpresaId)
        {
            GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> resultado = new GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>();
            try
            {
                resultado.Data = await _resultadosEvaIndicadoresService.GetListResultadosIndicadoresByClaseId(EvaluacionId, new int[] { 6 }, EmpresaId);
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
        [HttpGet("GetListaIndicadoresEstrategisco/{EvaluacionId}/{Tipo}/{Nivel}/{EmpresaId}")]
        public async Task<GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>> GetListaIndicadoresEstrategisco(long EvaluacionId, int Tipo, int Nivel, int EmpresaId)
        {
            GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> resultado = new GetResponse<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>();
            try
            {
                resultado.Data = await _resultadosEvaIndicadoresService.GetListaIndicadoreEstrategicos(EvaluacionId, Tipo, Nivel, EmpresaId);
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
        [HttpPut("PutResultadosIndicadoresgestion")]
        public async Task<GetResponse<string>> PutResultadosIndicadoresgestion(RequestIndicadores ObjRequest)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _gestEvaluacionService.PutConsolidarIndicador(ObjRequest);
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
        [HttpPost("GestionresultadoIndicadores/{EmpresaId}")]
        public async Task<GetResponse<string>> PostGestionresultadoIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjRequest, int EmpresaId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _gestEvaluacionService.PostGestionResultadoIndicadores(ObjRequest, EmpresaId);
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
