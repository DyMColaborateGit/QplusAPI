using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.Share;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GetGestFormEvaluacionController : ControllerBase
    {
        private readonly IGestEvaluacionService _gestEvaluacionService;

        public GetGestFormEvaluacionController(IGestEvaluacionService gestEvaluacionService)
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
        [HttpGet("GetFormInitEvaluacion/{EmpresaId}/{EvaluacionId}")]
        public async Task<GetResponse<GetGestEvaluacionModels>> GetFormInitEvaluacion(int EmpresaId, long EvaluacionId)
        {
            GetResponse<GetGestEvaluacionModels> resultado = new GetResponse<GetGestEvaluacionModels>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetGestEvaluacion(EvaluacionId, EmpresaId);
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
        [HttpGet("GetFormIndicadoresEvaluacion/{EmpresaId}/{EvaluacionId}/{Anio}")]
        public async Task<GetResponse<GetGestIndicadoresEvaluacionModels>> GetFormIndicadoresEvaluacion(int EmpresaId, long EvaluacionId, int Anio)
        {
            GetResponse<GetGestIndicadoresEvaluacionModels> resultado = new GetResponse<GetGestIndicadoresEvaluacionModels>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetGestIndicadoresEvaluacion(EvaluacionId, EmpresaId, Anio);
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
        [HttpGet("GetTotalAnalisisIndicadoresGestion/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<TBL_com_TotalesConsolidadoDesempenoModels>> GetTotalAnalisisIndicadoresGestion(long EvaluacionId, int EmpresaId)
        {
            GetResponse<TBL_com_TotalesConsolidadoDesempenoModels> resultado = new GetResponse<TBL_com_TotalesConsolidadoDesempenoModels>();
            try
            {
                resultado.Data = await _gestEvaluacionService.TotalAnalisisIndicadoresGestion(EvaluacionId, EmpresaId);
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
        [HttpGet("GetComportamientosByEvaluacionId/{EvaluacionId}")]
        public async Task<GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>> GetComportamientosByEvaluacionId(long EvaluacionId)
        {
            GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> resultado = new GetResponse<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetListComportamientos(EvaluacionId);
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
        [HttpPost("PutComportamientosByEvaluacionId")]
        public async Task<GetResponse<string>> PutComportamientosByEvaluacionId(RequestUpdateComportamiento ObjRequest)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _gestEvaluacionService.PutActualizarComportamientoEvaluacion(ObjRequest, ObjRequest.BCerrado);
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
        [HttpPost("PutUpdateComportamientosByEvaluacionId")]
        public async Task<GetResponse<string>> PutUpdateComportamientosByEvaluacionId(RequestUpdateComportamiento ObjRequest)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _gestEvaluacionService.PutActualizarComportamientoEvaluacion(ObjRequest,1);
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
        [HttpGet("PutGestValidarAnalisisDesarrollo/{EvaluacionId}/{UserName}/{EmpresaId}/{Bestado}")]
        public async Task<GetResponse<string>> GetDataEvaluacionByevaluacionId(long EvaluacionId, string UserName, int EmpresaId, bool Bestado)
        {
            GetResponse<string> resultado = new GetResponse<string>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GestValidarAnalisisDesarrollo(EvaluacionId, UserName, Bestado, EmpresaId);
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
        [HttpGet("GeTotalAnalisisIndicadoresEstrategicos/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>>> GeTotalAnalisisIndicadoresEstrategicos(long EvaluacionId, int EmpresaId)
        {
            GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>> resultado = new GetResponse<List<TBL_com_TotalesConsolidadoDesempenoModels>>();
            try
            {
                resultado.Data = await _gestEvaluacionService.TotalAnalisisIndicadoresEstrategicos(EvaluacionId, EmpresaId);
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
        [HttpGet("GetTotalIndicadoreCorpoportaivos/{EmpresaId}/{Anio}/{TipoNivelEst}")]
        public async Task<GetResponse<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetTotalIndicadoreCorpoportaivos(int EmpresaId, int Anio, int TipoNivelEst)
        {
            GetResponse<GeneralTBL_ind_TotalIndEstCorporativosModels> resultado = new GetResponse<GeneralTBL_ind_TotalIndEstCorporativosModels>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetTotalIndicadoresCorporativos(EmpresaId, Anio, TipoNivelEst, 1);
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
        [HttpGet("GeTotalAnalisisUesOne/{EvaluacionId}/{EmpresaId}/{Tipo}/{Nivel}")]
        public async Task<GetResponse<GeneralTotalUES>> TotalAnalisisUesOne(long EvaluacionId, int EmpresaId, int Tipo, int Nivel)
        {
            GetResponse<GeneralTotalUES> resultado = new GetResponse<GeneralTotalUES>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GeTotalAnalisisUesOne(EvaluacionId, EmpresaId, Tipo, Nivel);
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
        [HttpGet("GeTotalAnalisisuesTwo/{EvaluacionId}/{EmpresaId}")]
        public async Task<GetResponse<GeneralTotalUES>> TotalAnalisisuesTwo(long EvaluacionId, int EmpresaId)
        {
            GetResponse<GeneralTotalUES> resultado = new GetResponse<GeneralTotalUES>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GeTotalAnalisisuesTwo(EvaluacionId, EmpresaId);
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
        [HttpGet("GeTotalesEvaluacion/{EmpresaId}/{EvaluacionId}/{TipoId}/{Nivel}")]
        public async Task<GetResponse<GetGestVerEvaluacionModels>> GeTotalesEvaluacion(int EmpresaId, long EvaluacionId, int TipoId, int Nivel)
        {
            GetResponse<GetGestVerEvaluacionModels> resultado = new GetResponse<GetGestVerEvaluacionModels>();
            try
            {
                resultado.Data = await _gestEvaluacionService.GetVerEvaluacion(EmpresaId,EvaluacionId, TipoId, Nivel);
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
