using App.logic.IServices;
using App.Models.Global;
using App.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaSubProcesosByIdProcesoActivos/{IdProceso}")]
        public async Task<GetResponse<List<ProductosModels>>> GetListaSubProcesosByIdProcesoActivos(int IdProceso)
        {
            GetResponse<List<ProductosModels>> resultado = new GetResponse<List<ProductosModels>>();
            try
            {
                resultado.Data = await _productosService.GetListaSubProcesosByIdProcesoActivos(IdProceso);
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
