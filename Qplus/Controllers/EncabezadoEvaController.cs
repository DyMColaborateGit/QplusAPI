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
    public class EncabezadoEvaController : ControllerBase
    {
        private readonly IEncabezadoEvaService _encabezadoEvaService;

        public EncabezadoEvaController(IEncabezadoEvaService encabezadoEvaService)
        {
            _encabezadoEvaService = encabezadoEvaService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetEncabezadoEvaluacion/{EvaluacionId}")]
        public async Task<GetResponse<ResponseEncabezadoEvaModels>> GetEncabezadoEvaluacion(long EvaluacionId)
        {
            GetResponse<ResponseEncabezadoEvaModels> resultado = new GetResponse<ResponseEncabezadoEvaModels>();
            try
            {
                resultado.Data = await _encabezadoEvaService.GetObjEncabezadoEvaluacionByEvaluacionId(EvaluacionId);
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
