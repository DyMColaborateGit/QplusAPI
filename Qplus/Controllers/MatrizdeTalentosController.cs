using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrizdeTalentosController : ControllerBase
    {
        private IMatrizdeTalentoService _matrizdeTalentoService;
        public MatrizdeTalentosController(IMatrizdeTalentoService matrizdeTalentoService)
        {
            _matrizdeTalentoService = matrizdeTalentoService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListMatrizdeTalentos/{EmpresaId}/{Codmatriz}/{InAnio}/{ZonaId}/{OficinaId}/{ProcesoId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>>> GetListOficinasByempresaIdByzonas(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>> resultado = new GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>>();
            try
            {
                resultado.Data = await _matrizdeTalentoService.GetListConsolidadoMatrizdeTalentos(EmpresaId, Codmatriz, InAnio, ZonaId, OficinaId, ProcesoId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetFiltroListMatrizdeTalentos/{EmpresaId}/{Codmatriz}/{InAnio}/{ZonaId}/{OficinaId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>> GetFiltroListMatrizdeTalentos(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>> resultado = new GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>();
            try
            {
                resultado.Data = await _matrizdeTalentoService.FiltroListConsolidadoMatrizdeTalentos(EmpresaId, Codmatriz, InAnio, ZonaId, OficinaId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetListMatrizdeTalentosM/{EmpresaId}/{Codmatriz}/{InAnio}/{ZonaId}/{OficinaId}/{ProcesoId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>>> GetListMatrizdeTalentosM(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>> resultado = new GetResponse<List<ResponseTBL_com_MatrizdeTalentosModels>>();
            try
            {
                resultado.Data = await _matrizdeTalentoService.GetListConsolidadoMatrizdeTalentosM(EmpresaId, Codmatriz, InAnio, ZonaId, OficinaId, ProcesoId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetFiltroListMatrizdeTalentosM/{EmpresaId}/{NumeroMapaTalentoM}/{InAnio}/{ZonaId}/{OficinaId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>> GetFiltroListMatrizdeTalentosM(int EmpresaId, int NumeroMapaTalentoM, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>> resultado = new GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>();
            try
            {
                resultado.Data = await _matrizdeTalentoService.FiltroListConsolidadoMatrizdeTalentosM(EmpresaId, NumeroMapaTalentoM, InAnio, ZonaId, OficinaId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetFiltroListEvaluacionesAnioEvaluadorId/{InAnio}/{EvaluadorId}")]
        public async Task<GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>> GetFiltroListEvaluacionesAnioEvaluadorId(int InAnio, long EvaluadorId)
        {
            GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>> resultado = new GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>();
            try
            {
                resultado.Data = await _matrizdeTalentoService.FiltroListEvaluacionesAnioEvaluadorId(InAnio, EvaluadorId);
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
        [HttpGet("GestActualizarMatrizdetalentosevaluacion/{Anio}/{EmpresaId}")]
        public async Task<GetResponse<string>> GetListOficinasByempresaIdByzonas(int Anio, int EmpresaId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                int resultadoUpdate = await _matrizdeTalentoService.GestUpdateMatrizdeTalentosFuncionarios(Anio, EmpresaId);
                resultado.Data = "Se actualizaron "+ resultadoUpdate;
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
