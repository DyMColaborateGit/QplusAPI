using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaPreguntaController : ControllerBase
    {
        private readonly IEncuestaPreguntaService _encuestaPreguntaService;

        public EncuestaPreguntaController(IEncuestaPreguntaService encuestaPreguntaService)
        {
            _encuestaPreguntaService = encuestaPreguntaService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListEncuestaPregunta/{EmpresaId}/{IdEncuesta}")]
        public async Task<GetResponse<List<JOIN_tbl_com_EncuestaPreguntaModels>>> ListEncuestaPregunta(int EmpresaId, int IdEncuesta)
        {
            GetResponse<List<JOIN_tbl_com_EncuestaPreguntaModels>> resultado = new GetResponse<List<JOIN_tbl_com_EncuestaPreguntaModels>>();
            try
            {
                resultado.Data = await _encuestaPreguntaService.GetListEncuestaPregunta(EmpresaId, IdEncuesta);
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
        [HttpPut("PutUpdateEncuestaPregunta")]
        public async Task<GetResponse<TBL_com_EncuestaPreguntaModels>> tUpdateEncuestaPregunta(TBL_com_EncuestaPreguntaModels ObjRequest)
        {
            GetResponse<TBL_com_EncuestaPreguntaModels> resultado = new GetResponse<TBL_com_EncuestaPreguntaModels>();
            try
            {
                resultado.Data = await _encuestaPreguntaService.PutUpdateEncuestaPregunta(ObjRequest);
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
        [HttpGet("GetValueEncuestaPregunta/{EmpresaId}/{IdEncuesta}")]
        public async Task<GetResponse<string>> GetValueEncuestaPregunta(int EmpresaId, int IdEncuesta)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _encuestaPreguntaService.GetValidateEstadoEncuesta(EmpresaId, IdEncuesta);
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
