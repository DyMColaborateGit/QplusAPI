using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultIndiCoporpController : ControllerBase
    {
        private readonly IResultIndiCoporpService _resultIndiCoporpService;

        public ResultIndiCoporpController(IResultIndiCoporpService resultIndiCoporpService)
        {
            _resultIndiCoporpService = resultIndiCoporpService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetresultadoTotalIndicadoreCorporativos/{EvaluacionId}/{EmpresaId}/{Anio}")]
        public async Task<GetResponse<JOINTBL_ind_ResultIndiCoporpModels>> GetresultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int Anio)
        {
            GetResponse<JOINTBL_ind_ResultIndiCoporpModels> resultado = new GetResponse<JOINTBL_ind_ResultIndiCoporpModels>();
            try
            {
                resultado.Data = await _resultIndiCoporpService.GetresultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, Anio);
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
        [HttpGet("GetListaResutIndiCorporativos/{EvaluacionId}/{EmpresaId}/{Anio}")]
        public async Task<GetResponse<List<JOINTBL_ind_ResultIndiCoporpModels>>> GetListaResutIndiCorporativos(long EvaluacionId, int EmpresaId, int Anio)
        {
            GetResponse<List<JOINTBL_ind_ResultIndiCoporpModels>> resultado = new GetResponse<List<JOINTBL_ind_ResultIndiCoporpModels>>();
            try
            {
                resultado.Data = await _resultIndiCoporpService.GetListaResutIndiCorporativos(EvaluacionId, EmpresaId, Anio);
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
