using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.Share;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalUESController : ControllerBase
    {
        private readonly ITotalUESService _totalUESService;

        public TotalUESController(ITotalUESService totalUESService)
        {
            _totalUESService = totalUESService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTotalAnalisisUES1/{EvaluacionId}/{EmpresaId}/{Tipo}/{Nivel}")]
        public async Task<GetResponse<GeneralTotalUES>> GetTotalAnalisisUES1(long EvaluacionId, int EmpresaId, int Tipo, int Nivel)
        {
            GetResponse<GeneralTotalUES> resultado = new GetResponse<GeneralTotalUES>();
            try
            {
                resultado.Data = await _totalUESService.GetTotalAnalisisUES1(EvaluacionId, EmpresaId, Tipo, Nivel);
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
        [HttpGet("GetTotalAnalisisUES1/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<GeneralTotalUES>> GetTotalAnalisisUES2(long EvaluacionId, int EmpresaId)
        {
            GetResponse<GeneralTotalUES> resultado = new GetResponse<GeneralTotalUES>();
            try
            {
                resultado.Data = await _totalUESService.GetTotalAnalisisUES2(EvaluacionId, EmpresaId);
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
