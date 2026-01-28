using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalAnalisisIndiADIController : ControllerBase
    {
        private readonly ITotalAnalisisIndiADIService _totalAnalisisIndiADIService;

        public TotalAnalisisIndiADIController(ITotalAnalisisIndiADIService TotalAnalisisIndiADIService)
        {
            _totalAnalisisIndiADIService = TotalAnalisisIndiADIService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTotalAnalisisIndicadoresEstrategicosADI/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>>> TotalAnalisisIndicadoresEstrategicosADI(long EvaluacionId, int EmpresaId)
        {
            GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>> resultado = new GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>>();
            try
            {
                resultado.Data = await _totalAnalisisIndiADIService.TotalAnalisisIndicadoresEstrategicosADI(EvaluacionId, EmpresaId);
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
