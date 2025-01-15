using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProgramacionMasivaEvaluacionesController : ControllerBase
    {
        private readonly IProgramacionMasivaEvaluacionesService _programacionMasivaEvaluacionesService;

        public ProgramacionMasivaEvaluacionesController(IProgramacionMasivaEvaluacionesService programacionMasivaEvaluacionesService)
        {
            _programacionMasivaEvaluacionesService = programacionMasivaEvaluacionesService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetDataProgramacionMasivaEvaluaciones/{IdProgramacion}")]
        public async Task<GetResponse<Tbl_com_ProgramacionMasivaEvaluacionesModels>> GetDataProgramacionMasivaEvaluaciones(long IdProgramacion)
        {
            GetResponse<Tbl_com_ProgramacionMasivaEvaluacionesModels> resultado = new GetResponse<Tbl_com_ProgramacionMasivaEvaluacionesModels>();
            try
            {
                resultado.Data = await _programacionMasivaEvaluacionesService.GetObjProgramacionMasivaEvaluaciones(IdProgramacion);
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
