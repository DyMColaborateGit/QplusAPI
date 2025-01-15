using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    /// <summary>
    /// FuncionarioController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionariosService _funcionariosService;
        /// <summary>
        /// FuncionarioController
        /// </summary>
        public FuncionarioController(IFuncionariosService funcionariosService)
        {
            _funcionariosService = funcionariosService;
        }


        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetObjfuncionarioByempresaIdByIdentificacion/{EmpresaId}/{Identificacion}")]
        public async Task<GetResponse<SCP_FuncionariosModels>> GetFormInitEvaluacion(int EmpresaId, long Identificacion)
        {
            GetResponse<SCP_FuncionariosModels> resultado = new GetResponse<SCP_FuncionariosModels>();
            try
            {
                resultado.Data = await _funcionariosService.GetObjFuncionarioByIdentificacion(EmpresaId, Identificacion);
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
        [HttpGet("GetJoinfuncionarioByempresaIdByIdentificacion/{EmpresaId}/{Identificacion}")]
        public async Task<GetResponse<JOINSCP_FuncionariosModels>> GetJoinfuncionarioByempresaIdByIdentificacion(int EmpresaId, long Identificacion)
        {
            GetResponse<JOINSCP_FuncionariosModels> resultado = new GetResponse<JOINSCP_FuncionariosModels>();
            try
            {
                resultado.Data = await _funcionariosService.GetJoinFuncionarioByIdentificacion(EmpresaId, Identificacion);
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
