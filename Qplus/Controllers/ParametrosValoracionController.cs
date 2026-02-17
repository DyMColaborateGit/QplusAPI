using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblRgp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosValoracionController
    {
        private readonly IParametrosValoracionService _parametrosValoracionService;

        public ParametrosValoracionController(IParametrosValoracionService parametrosValoracionService)
        {
            _parametrosValoracionService = parametrosValoracionService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaParametrosValoracion/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_rgp_ParametrosValoracionModels>>> GetListaParametrosValoracion(int EmpresaId)
        {
            GetResponse<List<Tbl_rgp_ParametrosValoracionModels>> resultado = new GetResponse<List<Tbl_rgp_ParametrosValoracionModels>>();
            try
            {
                resultado.Data = await _parametrosValoracionService.GetListaParametrosValoracion(EmpresaId);
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
        [HttpGet("GetListaColoresZonas/{IdZona}")]
        public async Task<GetResponse<List<Tbl_rgp_ParametrosValoracionModels>>> GetListaColoresZonas(int IdZona)
        {
            GetResponse<List<Tbl_rgp_ParametrosValoracionModels>> resultado = new GetResponse<List<Tbl_rgp_ParametrosValoracionModels>>();
            try
            {
                resultado.Data = await _parametrosValoracionService.GetListaColoresZonas(IdZona);
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
