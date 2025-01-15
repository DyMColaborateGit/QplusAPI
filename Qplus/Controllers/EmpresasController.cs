using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresasService _empresasService;
        private readonly IEmpresasTitulosService _empresasTitulosService;

        public EmpresasController(IEmpresasService empresasService, IEmpresasTitulosService empresasTitulosService)
        {
            _empresasService = empresasService;
            _empresasTitulosService = empresasTitulosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetempresaByempresaId/{EmpresaId}")]
        public async Task<GetResponse<SCP_EmpresasModels>> GetempresaByempresaId(int EmpresaId)
        {
            GetResponse<SCP_EmpresasModels> resultado = new GetResponse<SCP_EmpresasModels>();
            try
            {
                resultado.Data = await _empresasService.GetEmpresaByempresaId(EmpresaId);
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
        [HttpGet("GetListEmpresas")]
        public async Task<GetResponse<List<SCP_EmpresasModels>>> GetListEmpresas()
        {
            GetResponse<List<SCP_EmpresasModels>> resultado = new GetResponse<List<SCP_EmpresasModels>>();
            try
            {
                resultado.Data = await _empresasService.GetListEmpresa();
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
        [HttpGet("GetEmpresasTitulosByempresaId/{EmpresaId}")]
        public async Task<GetResponse<SCP_EmpresasTitulosModels>> GetEmpresasTitulosByempresaId(int EmpresaId)
        {
            GetResponse<SCP_EmpresasTitulosModels> resultado = new GetResponse<SCP_EmpresasTitulosModels>();
            try
            {
                resultado.Data = await _empresasTitulosService.GetEmpresasTitulosByempresaId(EmpresaId);
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
