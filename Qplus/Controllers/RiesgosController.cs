using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblRgp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiesgosController
    {
        private readonly IRiesgosService _riesgosService;

        public RiesgosController(IRiesgosService riesgosService)
        {
            _riesgosService = riesgosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaRiesgos")]
        public async Task<GetResponse<List<Tbl_rgp_RiesgosModels>>> GetListaRiesgos()
        {
            GetResponse<List<Tbl_rgp_RiesgosModels>> resultado = new GetResponse<List<Tbl_rgp_RiesgosModels>>();
            try
            {
                resultado.Data = await _riesgosService.GetListaRiesgos();
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
        [HttpGet("GetListaCodigoRiesgoByProcesoId/{ProcesoId}")]
        public async Task<GetResponse<List<Tbl_rgp_RiesgosModels>>> GetListaCodigoRiesgoByProcesoId(int ProcesoId)
        {
            GetResponse<List<Tbl_rgp_RiesgosModels>> resultado = new GetResponse<List<Tbl_rgp_RiesgosModels>>();
            try
            {
                resultado.Data = await _riesgosService.GetListaCodigoRiesgoByProcesoId(ProcesoId);
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
