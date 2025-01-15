using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {
        private readonly IProcesoService _procesoService;

        public ProcesoController(IProcesoService procesoService)
        {
            _procesoService = procesoService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListProcesos/{EmpresaId}/{Estado}")]
        public async Task<GetResponse<List<SCP_ProcesosModels>>> GetListProcesosByEmpresaId(int EmpresaId, string Estado)
        {
            GetResponse<List<SCP_ProcesosModels>> resultado = new GetResponse<List<SCP_ProcesosModels>>();
            try
            {
                resultado.Data = await _procesoService.GetListProcesosByEmpresaId(EmpresaId, Estado);
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
        [HttpGet("GetListaProcesosEstadoByEmpresaIdByMacroproId/{EmpresaId}/{Id_Area}/{Estado}")]
        public async Task<GetResponse<List<SCP_ProcesosModels>>> GetListaProcesosEstadoByEmpresaIdByMacroproId(int EmpresaId, int Id_Area, string Estado)
        {
            GetResponse<List<SCP_ProcesosModels>> resultado = new GetResponse<List<SCP_ProcesosModels>>();
            try
            {
                resultado.Data = await _procesoService.GetListaProcesosEstadoByEmpresaIdByMacroproId(EmpresaId, Id_Area, Estado);
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
