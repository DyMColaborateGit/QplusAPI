using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.TblDoc;
using Microsoft.AspNetCore.Mvc;
using static App.Infraestructure.Repositories.DocumentosControladosRepository;

namespace Qplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly IDocumentosControladosService _documentosControladosService;

        public DocumentosController(IDocumentosControladosService documentosControladosService)
        {
            _documentosControladosService = documentosControladosService;
        }


        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListDocumentos/{EmpresaId}/")]
        public async Task<GetResponse<List<TBL_doc_DocumentosModels>>> GetListDocumentos(int EmpresaId)
        {
            GetResponse<List<TBL_doc_DocumentosModels>> resultado = new GetResponse<List<TBL_doc_DocumentosModels>>();
            try
            {
                resultado.Data = await _documentosControladosService.GetListDocumentos(EmpresaId);
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
        /// <response code="500">ServerError. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListadoDocumentosFiltrosVista/{IdArea}/{proceso_doc}/{CodigoDoc}/{IdProducto}/{IdTipo}/{Estado}/{NivelSeguridad}/{EmpresaId}/{InIdSistema}/{Usuario}/{NombreDoc}/{userId}/{ElaboradoPor}/{RevisadoPor}/{AprobadoPor}/{EstadoProceso}/{Pagina}/{pageSize}/{codigoCargo}")]
        public async Task<GetResponse<PagedResult<ResponseTBL_doc_DocumentosModels>>> GetListadoDocumentosFiltrosVista(int IdArea, int proceso_doc, string CodigoDoc, int IdProducto, int IdTipo, string Estado,
            int NivelSeguridad, int EmpresaId, int InIdSistema, int Usuario, string NombreDoc, int userId, int ElaboradoPor, int RevisadoPor, int AprobadoPor, string EstadoProceso, int Pagina, int pageSize, int codigoCargo)
        {
            GetResponse<PagedResult<ResponseTBL_doc_DocumentosModels>> resultado = new GetResponse<PagedResult<ResponseTBL_doc_DocumentosModels>>();
            try
            {
                resultado.Data = await _documentosControladosService.GetListadoDocumentosFiltrosVista(IdArea, proceso_doc, CodigoDoc, IdProducto, IdTipo, Estado,
                NivelSeguridad, EmpresaId, InIdSistema, Usuario, NombreDoc, userId, ElaboradoPor, RevisadoPor, AprobadoPor, EstadoProceso, Pagina, pageSize, codigoCargo);
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
