using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelDesempenoPpalController : ControllerBase
    {
        private INivelDesempenoPpalService _nivelDesempenoPpalService;
        public NivelDesempenoPpalController(INivelDesempenoPpalService nivelDesempenoPpalService)
        {
            _nivelDesempenoPpalService = nivelDesempenoPpalService;
        }

        ///// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        ///// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpGet("GetDataNivelesdeDesempenoPpalByEmpresaIdNivel/{EvaluacionId}")]
        //public async Task<GetResponse<TBL_com_NivelesDesempenoPpalModels>> GetDataNivelesdeDesempenoPpalByEmpresaIdNivel(int EmpresaId, string Nivel)
        //{
        //    GetResponse<TBL_com_NivelesDesempenoPpalModels> resultado = new GetResponse<TBL_com_NivelesDesempenoPpalModels>();
        //    try
        //    {
        //        resultado.Data = await _nivelDesempenoPpalService.GetObjNivelDesempenoPpal(EmpresaId, Nivel);
        //        resultado.StatusCode = (int)HttpCodes.OK;
        //        resultado.Message = new HttpCodesMessage().OK;
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.StatusCode = (int)HttpCodes.INTERNALERROR;
        //        resultado.Message = new HttpCodesMessage().INTERNALERROR;
        //        resultado.CathError = ex.Message.ToString();
        //        return resultado;
        //    }
        //}

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListNivelDesempenoPpal/{EmpresaId}/{InAnio}/{ZonaId}/{OficinaId}/{ProcesoId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>> GetListNivelDesempenoPpal(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<TBL_com_NivelesDesempenoPpalModels>> resultado = new GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>();
            try
            {
                resultado.Data = await _nivelDesempenoPpalService.GetListConsolidadoNivelDesempeno(EmpresaId, InAnio, ZonaId, OficinaId, ProcesoId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetListNivelDesempenoPpalM/{EmpresaId}/{InAnio}/{ZonaId}/{OficinaId}/{ProcesoId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>> GetListNivelDesempenoPpalM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<TBL_com_NivelesDesempenoPpalModels>> resultado = new GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>();
            try
            {
                resultado.Data = await _nivelDesempenoPpalService.GetListConsolidadoNivelDesempenoM(EmpresaId, InAnio, ZonaId, OficinaId, ProcesoId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetFiltrosNivelesDesempenoPpal/{EmpresaId}/{UbicacionMD}/{InAnio}/{ZonaId}/{OficinaId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>> GetFiltrosNivelesDesempenoPpal(int EmpresaId, int UbicacionMD, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>> resultado = new GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>();
            try
            {
                resultado.Data = await _nivelDesempenoPpalService.FiltroListConsolidadoNivelesDesempenoPpal(EmpresaId, UbicacionMD, InAnio, ZonaId, OficinaId, EvaluadorId, EvaluadoId);
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
        [HttpGet("GetFiltrosNivelesDesempenoPpalM/{EmpresaId}/{UbicacionMD_M}/{InAnio}/{ZonaId}/{OficinaId}/{EvaluadorId}/{EvaluadoId}")]
        public async Task<GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>> GetFiltrosNivelesDesempenoPpalM(int EmpresaId, int UbicacionMD_M, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>> resultado = new GetResponse<List<ResponseTbl_com_ProgEvaluacionModels>>();
            try
            {
                resultado.Data = await _nivelDesempenoPpalService.FiltroListConsolidadoNivelesDesempenoPpalM(EmpresaId, UbicacionMD_M, InAnio, ZonaId, OficinaId, EvaluadorId, EvaluadoId);
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
