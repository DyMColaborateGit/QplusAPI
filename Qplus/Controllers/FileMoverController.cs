using App.Models.Models.FileMove;
using App.logic.IServices;
using App.Models.Global;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Qplus.Controllers
{
    public class ProcesarLoteRequest
    {
        public List<FilePdfADIPdiModel> FilePdfs { get; set; }
        public string RutaFinal { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FileMoverController : ControllerBase
    {
        private readonly IFileMoverService _fileMoverService;

        public FileMoverController(IFileMoverService fileMoverService)
        {
            _fileMoverService = fileMoverService;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("PostMoverArchivo")]
        public async Task<GetResponse<FilePdfResultsModel>> PostMoverArchivo(List<FileMoveModels> fileMove)
        {
            GetResponse<FilePdfResultsModel> resultado = new GetResponse<FilePdfResultsModel>();
            try
            {
                Console.WriteLine($"Lista recibida: {fileMove}");

                resultado.Data = await _fileMoverService.PostMoverArchivo(fileMove);
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
        [HttpPost("CheckFileExists")]
        public async Task<GetResponse<FileResultModels>> CheckFileExists(FileMoveModels fileCheck)
        {
            GetResponse<FileResultModels> resultado = new GetResponse<FileResultModels>();
            try
            {
                resultado.Data = await _fileMoverService.CheckFileExists(fileCheck);
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
        [HttpPost("GetGenerarGuardarPdfsPdi")]
        public async Task<GetResponse<FilePdfResultsModel>> GetGenerarGuardarPdfsPdi(List<FilePdfADIPdiModel> FilePdfs)
        {
            GetResponse<FilePdfResultsModel> resultado = new GetResponse<FilePdfResultsModel>();
            try
            {
                Console.WriteLine($"Lista recibida: {FilePdfs}");

                resultado.Data = await _fileMoverService.GetGenerarGuardarPdfsPdi(FilePdfs);
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
        [HttpPost("GetGenerarGuardarPdfsAdi")]
        public async Task<GetResponse<FilePdfResultsModel>> GetGenerarGuardarPdfsAdi(List<FilePdfADIPdiModel> FilePdfs)
        {
            GetResponse<FilePdfResultsModel> resultado = new GetResponse<FilePdfResultsModel>();
            try
            {
                Console.WriteLine($"Lista recibida: {FilePdfs}");

                resultado.Data = await _fileMoverService.GetGenerarGuardarPdfsAdi(FilePdfs);
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
        [HttpPost("PostGuardarPdfDataArchivo/{FilePdfs}")]
        public async Task<GetResponse<FilePdfResultsModel>> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs)
        {
            GetResponse<FilePdfResultsModel> resultado = new GetResponse<FilePdfResultsModel>();
            try
            {
                Console.WriteLine($"Lista recibida: {FilePdfs}");

                resultado.Data = await _fileMoverService.PostGuardarPdfDataArchivo(FilePdfs);
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
        [HttpGet("ObtenerImagenBase64/{nombreArchivo}/{arbolRaiz}")]
        public async Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz)
        {
            GetResponse<FileResultModels> resultado = new GetResponse<FileResultModels>();
            try
            {
                if (resultado.Data == null || (resultado.StatusCode == (int)HttpCodes.NOTFOUND))
                {
                    resultado.StatusCode = (int)HttpCodes.NOTFOUND;
                    resultado.Message = new HttpCodesMessage().NOTFOUND;
                    return NotFound(resultado);
                }

                resultado.StatusCode = (int)HttpCodes.OK;
                resultado.Message = new HttpCodesMessage().OK;

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.StatusCode = (int)HttpCodes.INTERNALERROR;
                resultado.Message = new HttpCodesMessage().INTERNALERROR;
                resultado.CathError = ex.Message;

                return StatusCode(500, resultado);
            }
        }
    }
}