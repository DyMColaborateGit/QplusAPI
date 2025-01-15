using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblMast;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly IZonasService _zonasService;

        public ZonasController(IZonasService zonasService)
        {
            _zonasService = zonasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListZonasByempresaId/{EmpresaId}")]
        public async Task<GetResponse<List<TBL_mast_ZonasModels>>> GetListZonasByempresaId(int EmpresaId)
        {
            GetResponse<List<TBL_mast_ZonasModels>> resultado = new GetResponse<List<TBL_mast_ZonasModels>>();
            try
            {
                resultado.Data = await _zonasService.GetListZonas(EmpresaId);
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
