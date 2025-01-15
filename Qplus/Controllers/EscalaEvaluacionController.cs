using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EscalaEvaluacionController : ControllerBase
    {
        private readonly IEscalaEvaluacionService _escalaEvaluacionService;

        public EscalaEvaluacionController(
            IEscalaEvaluacionService escalaEvaluacionService)
        {
            _escalaEvaluacionService = escalaEvaluacionService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetEscalasEvaluacion/{EmpresaId}/{AspectoId}")]
        public async Task<GetResponse<List<Tbl_com_EscalaEvaluacionModels>>> GetEscalasEvaluacion(int EmpresaId, long AspectoId)
        {
            GetResponse<List<Tbl_com_EscalaEvaluacionModels>> resultado = new GetResponse<List<Tbl_com_EscalaEvaluacionModels>>();
            try
            {
                resultado.Data = await _escalaEvaluacionService.GetListEscalasByAspectoId(EmpresaId, AspectoId);
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
        [HttpGet("GetListEscalasEvaluacion/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_com_EscalaEvaluacionModels>>> GetListEscalasEvaluacion(int EmpresaId)
        {
            GetResponse<List<Tbl_com_EscalaEvaluacionModels>> resultado = new GetResponse<List<Tbl_com_EscalaEvaluacionModels>>();
            try
            {
                resultado.Data = await _escalaEvaluacionService.GetListEscalasEvaluacion(EmpresaId);
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
