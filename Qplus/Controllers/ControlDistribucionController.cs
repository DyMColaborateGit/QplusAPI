using App.logic.IServices;
using App.Models.Global;
using App.Models.Models;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlDistribucionController : ControllerBase
    {
        private readonly IControlDistribucionService _control_distribucionService;

        public ControlDistribucionController(IControlDistribucionService control_distribucionService)
        {
            _control_distribucionService = control_distribucionService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetControlDistDocumentoByDocumentoId/{IdDocumento}/{EmpresaId}")]
        public async Task<GetResponse<List<Control_distribucionModels>>> GetControlDistDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            GetResponse<List<Control_distribucionModels>> resultado = new GetResponse<List<Control_distribucionModels>>();
            try
            {
                resultado.Data = await _control_distribucionService.GetControlDistDocumentoByDocumentoId(IdDocumento, EmpresaId);
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
