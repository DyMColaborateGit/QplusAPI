using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsecuenciasController : Controller
    {
        private readonly IConsecuenciasService _consecuenciasService;

        public ConsecuenciasController(IConsecuenciasService consecuenciasService)
        {
            _consecuenciasService = consecuenciasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaConsecuencias/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_rgp_ConsecuenciasModels>>> GetListaConsecuencias(int EmpresaId)
        {
            GetResponse<List<Tbl_rgp_ConsecuenciasModels>> resultado = new GetResponse<List<Tbl_rgp_ConsecuenciasModels>>();
            try
            {
                resultado.Data = await _consecuenciasService.GetListaConsecuencias(EmpresaId);
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
        [HttpGet("GetObjConsecuenciaByEmpresaIdByValor/{EmpresaId}/{Valor}")]
        public async Task<GetResponse<Tbl_rgp_ConsecuenciasModels>> GetObjConsecuenciaByEmpresaIdByValor(int EmpresaId, int Valor)
        {
            GetResponse<Tbl_rgp_ConsecuenciasModels> resultado = new GetResponse<Tbl_rgp_ConsecuenciasModels>();
            try
            {
                resultado.Data = await _consecuenciasService.GetObjConsecuenciaByEmpresaIdByValor(EmpresaId, Valor);
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
