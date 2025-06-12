using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using App.Models.Models.TblGhu;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelFuncSolicitudPController : ControllerBase
    {
        private readonly IRelFuncSolicitudPService _relFuncSolicitudPService;

        public RelFuncSolicitudPController(IRelFuncSolicitudPService relFuncSolicitudPService)
        {
            _relFuncSolicitudPService = relFuncSolicitudPService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetObjRelFuncSolicitudPById/{RelFuncSolicitudPId}")]
        public async Task<GetResponse<Tbl_ghu_RelFuncSolicitudPModels>> GetObjRelFuncSolicitudPById(int RelFuncSolicitudPId)
        {
            GetResponse<Tbl_ghu_RelFuncSolicitudPModels> resultado = new GetResponse<Tbl_ghu_RelFuncSolicitudPModels>();
            try
            {
                resultado.Data = await _relFuncSolicitudPService.GetObjRelFuncSolicitudPById(RelFuncSolicitudPId);
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
        [HttpGet("GetListaRelFuncSolicitudP/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ghu_RelFuncSolicitudPModels>>> GetListaRelFuncSolicitudP(int EmpresaId)
        {
            GetResponse<List<Tbl_ghu_RelFuncSolicitudPModels>> resultado = new GetResponse<List<Tbl_ghu_RelFuncSolicitudPModels>>();
            try
            {
                resultado.Data = await _relFuncSolicitudPService.GetListaRelFuncSolicitudP(EmpresaId);
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
        [HttpPut("PutRelFuncSolicitudP")]
        public async Task<GetResponse<Tbl_ghu_RelFuncSolicitudPModels>> PutRelFuncSolicitudP(Tbl_ghu_RelFuncSolicitudPModels ObjUpdate)
        {
            GetResponse<Tbl_ghu_RelFuncSolicitudPModels> resultado = new GetResponse<Tbl_ghu_RelFuncSolicitudPModels>();
            try
            {
                resultado.Data = await _relFuncSolicitudPService.PutRelFuncSolicitudP(ObjUpdate);
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
