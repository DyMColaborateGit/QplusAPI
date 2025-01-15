using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using App.Models.Models.Tipo;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDocumentoController : ControllerBase
    {
        private ITipos_DocumentoService _tipos_DocumentoService;
        public TiposDocumentoController(ITipos_DocumentoService tipos_DocumentoService)
        {
            _tipos_DocumentoService = tipos_DocumentoService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListadoTiposDocumentoEmpresaId/{EmpresaId}")]

        public async Task<GetResponse<List<tipos_documentoModels>>> GetListadoTiposDocumentoEmpresaId(int EmpresaId)
        {
            GetResponse<List<tipos_documentoModels>> resultado = new GetResponse<List<tipos_documentoModels>>();
            try
            {
                resultado.Data = await _tipos_DocumentoService.GetListadoTiposDocumentoEmpresaId(EmpresaId);
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
