using App.logic.IServices;
using App.logic.Services;
using App.Models.Global;
using App.Models.Models.TblCom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesPIDController : ControllerBase
    {
        private readonly IActividadesPIDService _actividadesPIDService;
        private readonly IActividadesCompetenciasService _actividadesCompetenciasService;
        private readonly IActividadesIndicadoresService _actividadesIndicadoresService;

        public ActividadesPIDController(IActividadesPIDService actividadesPIDService, IActividadesCompetenciasService actividadesCompetenciasService, IActividadesIndicadoresService actividadesIndicadoresService)
        {
            _actividadesPIDService = actividadesPIDService;
            _actividadesCompetenciasService = actividadesCompetenciasService;
            _actividadesIndicadoresService = actividadesIndicadoresService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("PostCreatenewActividadPID")]
        public async Task<GetResponse<TBL_com_ActividadesPIDModels>> PostCreatenewActividadPID(TBL_com_ActividadesPIDModels ObjRequest)
        {
            GetResponse<TBL_com_ActividadesPIDModels> resultado = new GetResponse<TBL_com_ActividadesPIDModels>();
            try
            {
                resultado.Data = await _actividadesPIDService.PostCreatenewActividadPID(ObjRequest);
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
        [HttpPost("PostCreatenewActividadesCompetencias/{ActividadId}")]
        public async Task<GetResponse<List<TBL_com_ActividadesCompetenciasModels>>> PostCreatenewActividadesCompetencias(List<TBL_com_ActividadesCompetenciasModels> ObjRequest, int ActividadId)
        {
            GetResponse< List < TBL_com_ActividadesCompetenciasModels >> resultado = new GetResponse<List<TBL_com_ActividadesCompetenciasModels>>();
            try
            {
                resultado.Data = await _actividadesCompetenciasService.PostCreatenewActividadesCompetencias(ObjRequest, ActividadId);
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
        [HttpPost("PostCreatenewActividadesIndicadores/{ActividadId}")]
        public async Task<GetResponse<List<TBL_com_ActividadesIndicadoresModels>>> PostCreatenewActividadesIndicadores(List<TBL_com_ActividadesIndicadoresModels> ObjRequest, int ActividadId)
        {
            GetResponse<List<TBL_com_ActividadesIndicadoresModels>> resultado = new GetResponse<List<TBL_com_ActividadesIndicadoresModels>>();
            try
            {
                resultado.Data = await _actividadesIndicadoresService.PostCreatenewActividadesIndicadores(ObjRequest, ActividadId);
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
