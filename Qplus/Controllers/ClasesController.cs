using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblRgp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController
    {
        private readonly IClasesService _clasesService;

        public ClasesController(IClasesService clasesService)
        {
            _clasesService = clasesService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaClases")]
        public async Task<GetResponse<List<Tbl_rgp_ClasesModels>>> GetListaClases()
        {
            GetResponse<List<Tbl_rgp_ClasesModels>> resultado = new GetResponse<List<Tbl_rgp_ClasesModels>>();
            try
            {
                resultado.Data = await _clasesService.GetListaClases();
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
        [HttpGet("GetListaClasesByEmpresaByEstado/{EmpresaId}/{Estado}")]
        public async Task<GetResponse<List<Tbl_rgp_ClasesModels>>> GetListaClasesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            GetResponse<List<Tbl_rgp_ClasesModels>> resultado = new GetResponse<List<Tbl_rgp_ClasesModels>>();
            try
            {
                resultado.Data = await _clasesService.GetListaClasesByEmpresaByEstado(EmpresaId, Estado);
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
