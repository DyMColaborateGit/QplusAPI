using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models;
using App.Models.Models.TblDoc;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialCambiosController : ControllerBase
    {
        private readonly IHistorialCambiosService _historialCambiosService;

        public HistorialCambiosController(IHistorialCambiosService historialCambiosService)
        {
            _historialCambiosService = historialCambiosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetHistorialesDocumentoByDocumentoId/{IdDocumento}/{EmpresaId}")]
        public async Task<GetResponse<List<Historial_cambiosModels>>> GetHistorialesDocumentoByDocumentoId(int IdDocumento, int EmpresaId)
        {
            GetResponse<List<Historial_cambiosModels>> resultado = new GetResponse<List<Historial_cambiosModels>>();
            try
            {
                resultado.Data = await _historialCambiosService.GetHistorialesDocumentoByDocumentoId(IdDocumento, EmpresaId);
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
