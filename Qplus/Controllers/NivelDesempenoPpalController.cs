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
        //[HttpGet("GetListNivelDesempenoPpal/{EmpresaId}/{InAnio}")]
        //public async Task<GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>> GetListNivelDesempenoPpal(int EmpresaId, int InAnio)
        //{
        //    GetResponse<List<TBL_com_NivelesDesempenoPpalModels>> resultado = new GetResponse<List<TBL_com_NivelesDesempenoPpalModels>>();
        //    try
        //    {
        //        resultado.Data = await _nivelDesempenoPpalService.GetListNivelDesempenoPpal(EmpresaId, InAnio);
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
    }
}
