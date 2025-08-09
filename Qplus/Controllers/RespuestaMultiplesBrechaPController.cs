using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblGhu;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaMultiplesBrechaPController : ControllerBase
    {
        private readonly IRespuestaMultiplesBrechaPService _respuestaMultiplesBrechaPService;

        public RespuestaMultiplesBrechaPController(IRespuestaMultiplesBrechaPService respuestaMultiplesBrechaPService)
        {
            _respuestaMultiplesBrechaPService = respuestaMultiplesBrechaPService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaRespuestasMultiplesBrechaP/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>> GetListaRespuestasMultiplesBrechaP(int EmpresaId)
        {
            GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> resultado = new GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>();
            try
            {
                resultado.Data = await _respuestaMultiplesBrechaPService.GetListaRespuestasMultiplesBrechaP(EmpresaId);
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
        [HttpGet("GetListaRespuestasBrechaPByPreguntaId/{PreguntaId}")]
        public async Task<GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>> GetListaRespuestasBrechaPByPreguntaId(int PreguntaId)
        {
            GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> resultado = new GetResponse<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>();
            try
            {
                resultado.Data = await _respuestaMultiplesBrechaPService.GetListaRespuestasBrechaPByPreguntaId(PreguntaId);
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
