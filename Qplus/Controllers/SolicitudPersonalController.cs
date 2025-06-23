using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblGhu;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudPersonalController : ControllerBase
    {
        private readonly ISolicitudPersonalService _solicitudPersonalService;

        public SolicitudPersonalController(ISolicitudPersonalService solicitudPersonalService)
        {
            _solicitudPersonalService = solicitudPersonalService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetObjSolicitudPersonalById/{SolicitudId}")]
        public async Task<GetResponse<Tbl_ghu_SolicitudPersonalModels>> GetObjSolicitudPersonalById(int SolicitudId)
        {
            GetResponse<Tbl_ghu_SolicitudPersonalModels> resultado = new GetResponse<Tbl_ghu_SolicitudPersonalModels>();
            try
            {
                resultado.Data = await _solicitudPersonalService.GetObjSolicitudPersonalById(SolicitudId);
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
        [HttpGet("GetListaSolicitudesPersonal/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ghu_SolicitudPersonalModels>>> GetListaSolicitudesPersonal(int EmpresaId)
        {
            GetResponse<List<Tbl_ghu_SolicitudPersonalModels>> resultado = new GetResponse<List<Tbl_ghu_SolicitudPersonalModels>>();
            try
            {
                resultado.Data = await _solicitudPersonalService.GetListaSolicitudesPersonal(EmpresaId);
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
        [HttpPut("PutSolicitudPById")]
        public async Task<GetResponse<Tbl_ghu_SolicitudPersonalModels>> PutSolicitudPById(Tbl_ghu_SolicitudPersonalModels ObjUpdate)
        {
            GetResponse<Tbl_ghu_SolicitudPersonalModels> resultado = new GetResponse<Tbl_ghu_SolicitudPersonalModels>();
            try
            {
                resultado.Data = await _solicitudPersonalService.PutSolicitudPById(ObjUpdate);
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
