using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblAud;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        private readonly IEvaAuditoresService _evaAuditoresService;
        private readonly IEvaPreguntasService _evaPreguntasService;

        public AuditoriasController(IEvaAuditoresService evaAuditoresService, IEvaPreguntasService evaPreguntasService)
        {
            _evaAuditoresService = evaAuditoresService;
            _evaPreguntasService = evaPreguntasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetEncabezadoEvaluacionAuditores/{IdEvaluacion}")]
        public async Task<GetResponse<ResponseTBL_aud_EvaAuditoresModels>> GetEncabezadoEvaluacionAuditores(long IdEvaluacion)
        {
            GetResponse<ResponseTBL_aud_EvaAuditoresModels> resultado = new GetResponse<ResponseTBL_aud_EvaAuditoresModels>();
            try
            {
                resultado.Data = await _evaAuditoresService.GetEncabezadoEvaAuditorias(IdEvaluacion);
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
        [HttpGet("GetPreguntasEvaluacionAuditores/{IdEvaluacion}")]
        public async Task<GetResponse<List<TBL_aud_EvaPreguntasModels>>> GetPreguntasEvaluacionAuditores(long IdEvaluacion)
        {
            GetResponse<List<TBL_aud_EvaPreguntasModels>> resultado = new GetResponse<List<TBL_aud_EvaPreguntasModels>>();
            try
            {
                resultado.Data = await _evaPreguntasService.GetListEvaPreguntas(IdEvaluacion);
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
        [HttpGet("GetGesEstadoEvaluacionAuditores/{IdEvaluacion}")]
        public async Task<GetResponse<TBL_aud_EvaAuditoresModels>> GetGesEstadoEvaluacionAuditores(long IdEvaluacion)
        {
            GetResponse<TBL_aud_EvaAuditoresModels> resultado = new GetResponse<TBL_aud_EvaAuditoresModels>();
            try
            {
                resultado.Data = await _evaAuditoresService.PutEstadoEvaAuditores(IdEvaluacion);
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
        [HttpPut("UpdatePreguntasEvaluacionAuditores/{IdEvaluacion}/{Calificacion}/{IdEvaPregunta}")]
        public async Task<GetResponse<TBL_aud_EvaPreguntasModels>> UpdatePreguntasEvaluacionAuditores(long IdEvaluacion,int Calificacion, long IdEvaPregunta)
        {
            GetResponse<TBL_aud_EvaPreguntasModels> resultado = new GetResponse<TBL_aud_EvaPreguntasModels>();
            try
            {
                resultado.Data = await _evaPreguntasService.UpdateEvaPreguntas(IdEvaluacion,Calificacion, IdEvaPregunta);
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
        [HttpPut("UpdateObservacionEvAuditores")]
        public async Task<GetResponse<TBL_aud_EvaAuditoresModels>> UpdateObservacionEvAuditores(TBL_aud_EvaAuditoresModels ObjEvaluacion)
        {
            GetResponse<TBL_aud_EvaAuditoresModels> resultado = new GetResponse<TBL_aud_EvaAuditoresModels>();
            try
            {
                resultado.Data = await _evaAuditoresService.PutObservacionEvaAuditores(ObjEvaluacion);
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
