using App.logic.IServices;
using App.Models.Global;
using App.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        private readonly INormaService _normaService;
        public NormasController(INormaService normaService)
        {
            _normaService = normaService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetCompetenciasActividadesPDIByCargoBytipo/{EmpresaId}/{CargoId}/{TipoAna}")]
        public async Task<GetResponse<List<object>>> GetCompetenciasActividadesPDIByCargoBytipo(int EmpresaId, int CargoId, int TipoAna)
        {
            GetResponse<List<object>> resultado = new GetResponse<List<object>>();
            try
            {
                List<object> commonList = new List<object>();
                if (TipoAna == 1)
                {
                    var ResultadoList = await _normaService.GetListNormasJoinNivelesCargoComp(EmpresaId,CargoId);
                    commonList.AddRange(ResultadoList);
                }
                else
                {
                    var ResultadoList = await _normaService.GetListNormasByEstado(EmpresaId, true);
                    commonList.AddRange(ResultadoList);
                }
                resultado.Data = commonList;
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
