using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastIndicadoresController : ControllerBase
    {
        private readonly IMastIndicadoresService _mastIndicadoresService;

        public MastIndicadoresController(IMastIndicadoresService mastIndicadoresService)
        {
            _mastIndicadoresService = mastIndicadoresService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetExistIndicadoresform/{EmpresaId}/{EvaluacionId}")]
        public async Task<GetResponse<string>> GetEncabezadoEvaluacion(int EmpresaId, long EvaluacionId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _mastIndicadoresService.GetValueTiposdeindicadores(EmpresaId, EvaluacionId);
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
        [HttpGet("GetListIndicadoresFuncionario/{EvaluacionId}/{EmpresaId}/{Identificacion}/{CodigoCargo}")]
        public async Task<GetResponse<List<Tbl_ind_MastIndicadoresModels>>> GetListIndicadoresFuncionario(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo)
        {
            GetResponse<List<Tbl_ind_MastIndicadoresModels>> resultado = new GetResponse<List<Tbl_ind_MastIndicadoresModels>>();
            try
            {
                resultado.Data = await _mastIndicadoresService.GetIndicadoresFuncionarioEstrategicos(EvaluacionId, EmpresaId, Identificacion, CodigoCargo);
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
        [HttpGet("GetListIndicadoresPIM/{EvaluacionId}/{EmpresaId}/{Identificacion}/{CodigoCargo}")]
        public async Task<GetResponse<List<Tbl_ind_MastIndicadoresModels>>> GetListIndicadoresPIM(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo)
        {
            GetResponse<List<Tbl_ind_MastIndicadoresModels>> resultado = new GetResponse<List<Tbl_ind_MastIndicadoresModels>>();
            try
            {
                resultado.Data = await _mastIndicadoresService.GetListIndicadoresFuncionarioDifClass(EvaluacionId, EmpresaId, Identificacion, CodigoCargo);
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
        [HttpPost("PostCrearIndicador/{EvaluacionId}")]
        public async Task<GetResponse<Tbl_ind_MastIndicadoresModels>> PostCrearIndicador(long EvaluacionId, Tbl_ind_MastIndicadoresModels objCreate)
        {
            GetResponse<Tbl_ind_MastIndicadoresModels> resultado = new GetResponse<Tbl_ind_MastIndicadoresModels>();
            try
            {
                resultado.Data = await _mastIndicadoresService.PostIndicadorFuncionarioByEvaluacionId(objCreate, EvaluacionId);
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
