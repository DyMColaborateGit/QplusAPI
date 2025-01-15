using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblMast;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinasController : ControllerBase
    {
        private readonly IOficinasService _oficinasService;

        public OficinasController(IOficinasService oficinasService)
        {
            _oficinasService = oficinasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListOficinasByempresaIdByzonas/{EmpresaId}/{ZonaId}")]
        public async Task<GetResponse<List<TBL_mast_OficinasModels>>> GetListOficinasByempresaIdByzonas(int EmpresaId, int ZonaId)
        {
            GetResponse<List<TBL_mast_OficinasModels>> resultado = new GetResponse<List<TBL_mast_OficinasModels>>();
            try
            {
                resultado.Data = await _oficinasService.GetListOficinasZonaId(EmpresaId, ZonaId);
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
