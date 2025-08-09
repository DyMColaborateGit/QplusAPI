using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblGhu;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemasBrechaPController : ControllerBase
    {
        private readonly ITemasBrechaPService _temasBrechaPService;

        public TemasBrechaPController(ITemasBrechaPService temasBrechaPService)
        {
            _temasBrechaPService = temasBrechaPService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListaTemasBrechaP/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ghu_TemasBrechaPModels>>> GetListaTemasBrechaP(int EmpresaId)
        {
            GetResponse<List<Tbl_ghu_TemasBrechaPModels>> resultado = new GetResponse<List<Tbl_ghu_TemasBrechaPModels>>();
            try
            {
                resultado.Data = await _temasBrechaPService.GetListaTemasBrechaP(EmpresaId);
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
