using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultcomTecnicasController : ControllerBase
    {
        private readonly IResultcomTecnicasService _resultcomTecnicasService;

        public ResultcomTecnicasController(IResultcomTecnicasService resultcomTecnicasService)
        {
            _resultcomTecnicasService = resultcomTecnicasService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetCompetenciastecnicas/{EvaluacionId}")]
        public async Task<GetResponse<List<TBL_com_ResultcomTecnicasModels>>> GetCompetenciastecnicas(long EvaluacionId)
        {
            GetResponse<List<TBL_com_ResultcomTecnicasModels>> resultado = new GetResponse<List<TBL_com_ResultcomTecnicasModels>>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.GetListResultcomTecnicasModelsByEvaluacionId(EvaluacionId);
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
        [HttpGet("Verificarcomptecnicas/{EvaluacionId}")]
        public async Task<GetResponse<string>> Verificarcomptecnicas(long EvaluacionId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.GetVerificarcomptecnicas(EvaluacionId);
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
        [HttpGet("VerificarcomptecnicasCerradas/{EvaluacionId}")]
        public async Task<GetResponse<string>> VerificarcomptecnicasCerradas(long EvaluacionId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.GetVerificarcomptecnicasCerradas(EvaluacionId);
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
        [HttpGet("VerificarVerFormularioTecnicas/{EmpresaId}")]
        public async Task<GetResponse<string>> VerificarVerFormularioTecnicas(int EmpresaId)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.GetVerificarVerFormularioTecnicas(EmpresaId);
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
        [HttpPost("Crearcompetenciastecnicas/{EmpresaId}")]
        public async Task<GetResponse<TBL_com_ResultcomTecnicasModels>> PostCrearcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjRequest, int EmpresaId)
        {
            GetResponse<TBL_com_ResultcomTecnicasModels> resultado = new GetResponse<TBL_com_ResultcomTecnicasModels>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.PostCrearcompetenciastecnicas(ObjRequest, EmpresaId);
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
        [HttpPut("Modificarcompetenciastecnicas")]
        public async Task<GetResponse<TBL_com_ResultcomTecnicasModels>> PutModificarcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjRequest)
        {
            GetResponse<TBL_com_ResultcomTecnicasModels> resultado = new GetResponse<TBL_com_ResultcomTecnicasModels>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.PutModificarcompetenciastecnicas(ObjRequest);
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
        [HttpDelete("EliminarcompetenciaTecnica")]
        public async Task<GetResponse<string>> Eliminarcompetenciatecnica(TBL_com_ResultcomTecnicasModels ObjRequest)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _resultcomTecnicasService.DeleteResultcomTecnicas(ObjRequest);
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
