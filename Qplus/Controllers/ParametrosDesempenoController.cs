
using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.Scp;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosDesempenoController : ControllerBase
    {
        private readonly IParametrosDesempenoService _parametrosDesempenoService;

        public ParametrosDesempenoController(IParametrosDesempenoService parametrosDesempenoService)
        {
            _parametrosDesempenoService = parametrosDesempenoService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListParametrosDesempeno/{EmpresaId}")]
        public async Task<GetResponse<List<TBL_com_ParametrosDesempenoModels>>> GetListParametrosDesempeno(int EmpresaId)
        {
            GetResponse<List<TBL_com_ParametrosDesempenoModels>> resultado = new GetResponse<List<TBL_com_ParametrosDesempenoModels>>();
            try
            {
                resultado.Data = await _parametrosDesempenoService.GetListParametrosDesempeno(EmpresaId);
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
