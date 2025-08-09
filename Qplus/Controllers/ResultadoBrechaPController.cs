using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoBrechaPController : ControllerBase
    {
        private readonly IResultadoBrechaPService _resultadoBrechaPService;

        public ResultadoBrechaPController(IResultadoBrechaPService resultadoBrechaPService)
        {
            _resultadoBrechaPService = resultadoBrechaPService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaResultadoBrechaPById/{RelFuncSolicitudPId}")]
        public async Task<GetResponse<List<Tbl_ghu_ResultadoBrechaPModels>>> GetListaResultadoBrechaPById(int RelFuncSolicitudPId)
        {
            GetResponse <List<Tbl_ghu_ResultadoBrechaPModels>> resultado = new GetResponse<List<Tbl_ghu_ResultadoBrechaPModels>>();
            try
            {
                resultado.Data = await _resultadoBrechaPService.GetListaResultadoBrechaPById(RelFuncSolicitudPId);
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
        [HttpGet("GetListaResultadoBrechaP/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ghu_ResultadoBrechaPModels>>> GetListaResultadoBrechaP(int EmpresaId)
        {
            GetResponse<List<Tbl_ghu_ResultadoBrechaPModels>> resultado = new GetResponse<List<Tbl_ghu_ResultadoBrechaPModels>>();
            try
            {
                resultado.Data = await _resultadoBrechaPService.GetListaResultadoBrechaP(EmpresaId);
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
        [HttpPost("PostResultadosBrechaP")]
        public async Task<GetResponse<Tbl_ghu_ResultadoBrechaPModels>> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels objCreate)
        {
            GetResponse<Tbl_ghu_ResultadoBrechaPModels> resultado = new GetResponse<Tbl_ghu_ResultadoBrechaPModels>();
            try
            {
                resultado.Data = await _resultadoBrechaPService.PostResultadosBrechaP(objCreate);
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
        [HttpPut("PutResultadoBrechaP")]
        public async Task<GetResponse<Tbl_ghu_ResultadoBrechaPModels>> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            GetResponse<Tbl_ghu_ResultadoBrechaPModels> resultado = new GetResponse<Tbl_ghu_ResultadoBrechaPModels>();
            try
            {
                resultado.Data = await _resultadoBrechaPService.PutResultadoBrechaP(ObjUpdate);
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
