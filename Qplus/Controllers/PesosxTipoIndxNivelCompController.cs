using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesosxTipoIndxNivelCompController : ControllerBase
    {
        private readonly IPesosxTipoIndxNivelCompService _pesosxTipoIndxNivelCompService;

        public PesosxTipoIndxNivelCompController(IPesosxTipoIndxNivelCompService pesosxTipoIndxNivelCompService)
        {
            _pesosxTipoIndxNivelCompService = pesosxTipoIndxNivelCompService;
        }


        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetPesosxTipoIndxNivelComp/{EmpresaId}/{Nivel}/{IdTipoIndicador}")]
        public async Task<GetResponse<Tbl_ind_PesosxTipoIndxNivelCompModels>> GetPesosxTipoIndxNivelComp(int EmpresaId, int Nivel, int IdTipoIndicador)
        {
            GetResponse<Tbl_ind_PesosxTipoIndxNivelCompModels> resultado = new GetResponse<Tbl_ind_PesosxTipoIndxNivelCompModels>();
            try
            {
                resultado.Data = await _pesosxTipoIndxNivelCompService.GetPesosxTipoIndxNivelComp(EmpresaId, Nivel, IdTipoIndicador);
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
