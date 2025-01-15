using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosProcesosController
    {
        private readonly ICargosProcesosService _cargosProcesosService;

        public CargosProcesosController(ICargosProcesosService cargosProcesosService)
        {
            _cargosProcesosService = cargosProcesosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetCargoAutorizadosByProcesoIdCargoId/{IdProceso}/{id_cargo}/{EmpresaId}")]
        public async Task<GetResponse<List<SCP_CargosProcesosModels>>> GetCargoAutorizadosByProcesoIdCargoId(int IdProceso, int id_cargo, int EmpresaId)
        {
            GetResponse<List<SCP_CargosProcesosModels>> resultado = new GetResponse<List<SCP_CargosProcesosModels>>();
            try
            {
                resultado.Data = await _cargosProcesosService.GetCargoAutorizadosByProcesoIdCargoId(IdProceso, id_cargo, EmpresaId);
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
