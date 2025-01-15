using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivosCalidadController : ControllerBase
    {

        private readonly IGestEvaluacionService _gestEvaluacionService;

        public ObjetivosCalidadController(IGestEvaluacionService gestEvaluacionService)
        {
            _gestEvaluacionService = gestEvaluacionService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListObjetivosDecalidad/{EmpresaId}")]
        public async Task<GetResponse<List<Tbl_ind_ObjetivosCalidadModels>>> GetListObjetivosDecalidad(int EmpresaId)
        {
            GetResponse<List<Tbl_ind_ObjetivosCalidadModels>> resultado = new GetResponse<List<Tbl_ind_ObjetivosCalidadModels>>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetListObjetivosCalidad(EmpresaId);
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
