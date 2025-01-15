using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogodeDesarrolloController : ControllerBase
    {
        private readonly IDialogodeDesarrolloService _dialogodeDesarrolloService;

        public DialogodeDesarrolloController(IDialogodeDesarrolloService dialogodeDesarrolloService)
        {
            _dialogodeDesarrolloService = dialogodeDesarrolloService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListdialogodedesarrolloByevaluacionId/{IdEvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<List<TBL_com_DialogodeDesarrolloModels>>> GetListTiposIndicadoresEstrategicos(long IdEvaluacionId, int EmpresaId)
        {
            GetResponse<List<TBL_com_DialogodeDesarrolloModels>> resultado = new GetResponse<List<TBL_com_DialogodeDesarrolloModels>>();
            try
            {
                resultado.Data = await _dialogodeDesarrolloService.GetListDialogodedesarrolloByevaluacionId(EmpresaId, IdEvaluacionId);
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
        [HttpGet("GetObjDialogodeDesarrollo/{IdDialogo}")]
        public async Task<GetResponse<TBL_com_DialogodeDesarrolloModels>> ObjDialogodeDesarrolloById(int IdDialogo)
        {
            GetResponse<TBL_com_DialogodeDesarrolloModels> resultado = new GetResponse<TBL_com_DialogodeDesarrolloModels>();
            try
            {
                resultado.Data = await _dialogodeDesarrolloService.GetObjDialogodeDesarrolloById(IdDialogo);
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
