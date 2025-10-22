using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblRgp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentesController
    {
        private readonly IAgentesService _agentesService;

        public AgentesController(IAgentesService agentesService)
        {
            _agentesService = agentesService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaAgentes")]
        public async Task<GetResponse<List<Tbl_rgp_AgentesModels>>> GetListaAgentes()
        {
            GetResponse<List<Tbl_rgp_AgentesModels>> resultado = new GetResponse<List<Tbl_rgp_AgentesModels>>();
            try
            {
                resultado.Data = await _agentesService.GetListaAgentes();
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
        [HttpGet("GetListaAgentesByEmpresaByEstado/{EmpresaId}/{Estado}")]
        public async Task<GetResponse<List<Tbl_rgp_AgentesModels>>> GetListaAgentesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            GetResponse<List<Tbl_rgp_AgentesModels>> resultado = new GetResponse<List<Tbl_rgp_AgentesModels>>();
            try
            {
                resultado.Data = await _agentesService.GetListaAgentesByEmpresaByEstado(EmpresaId, Estado);
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
