using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController : ControllerBase
    {
        private readonly IResultadosService _resultadosService;

        public ResultadosController(IResultadosService resultadosService)
        {
            _resultadosService = resultadosService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetResultadosEvaluacionListaByEvaluacionId/{EvaluacionId}/{NormaId}")]
        public async Task<GetResponse<List<Tbl_com_ResultadosModels>>> GetResultadosEvaluacionListaByEvaluacionId(int EvaluacionId, int NormaId)
        {
            GetResponse<List<Tbl_com_ResultadosModels>> resultado = new GetResponse<List<Tbl_com_ResultadosModels>>();
            try
            {
                resultado.Data = await _resultadosService.GetResultadosEvaluacionListaByEvaluacionId(EvaluacionId, NormaId);
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
