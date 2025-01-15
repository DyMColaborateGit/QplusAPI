
using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosEmpresasController : ControllerBase
    {
        private readonly IParametrosEmpresasService _parametrosEmpresasService;

        public ParametrosEmpresasController(IParametrosEmpresasService parametrosEmpresasService)
        {
            _parametrosEmpresasService = parametrosEmpresasService;
        }


        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetParametroEmpresaByParametroId/{EmpresaId}/{ParametroId}")]

        public async Task<GetResponse<SCP_ParametrosEmpresasModels>> GetParametroEmpresaByParametroId(int EmpresaId, int ParametroId)
        {
            GetResponse<SCP_ParametrosEmpresasModels> resultado = new GetResponse<SCP_ParametrosEmpresasModels>();
            try
            {
                resultado.Data = await _parametrosEmpresasService.GetParametroEmpresaByParametroId(EmpresaId, ParametroId);
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
        [HttpGet("GetListParametrosGenerales/{EmpresaId}")]
        public async Task<GetResponse<List<SCP_ParametrosEmpresasModels>>> GetListParametrosGenerales(int EmpresaId)
        {
            GetResponse<List<SCP_ParametrosEmpresasModels>> resultado = new GetResponse<List<SCP_ParametrosEmpresasModels>>();
            try
            {
                resultado.Data = await _parametrosEmpresasService.GetListParametrosGenerales(EmpresaId);
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
