using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidadoDesempenosController : ControllerBase
    {
        private readonly IConsolidadoDesempenoService _consolidadoDesempenoService;

        public ConsolidadoDesempenosController(IConsolidadoDesempenoService consolidadoDesempenoService)
        {
            _consolidadoDesempenoService = consolidadoDesempenoService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetConsolidadoCompetenciasByEvaluacionId/{EvaluacionId}/{Tipo}")]
        public async Task<GetResponse<List<TBL_com_ConsolidadoDesempenoModels>>> GetListConsolidadoDesempeno(long EvaluacionId, int Tipo)
        {
            GetResponse<List<TBL_com_ConsolidadoDesempenoModels>> resultado = new GetResponse<List<TBL_com_ConsolidadoDesempenoModels>>();
            try
            {
                resultado.Data = await _consolidadoDesempenoService.GetListConsolidadoDesempeno(EvaluacionId, Tipo);
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
