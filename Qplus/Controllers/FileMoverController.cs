using App.logic.IServices;
using App.Models.Global;
using App.Models.Models.FileMove;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Qplus.Controllers
{
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
        public async Task<GetResponse<FileResultModels>> PostMoverArchivo(List<FileMoveModels> fileMove)
        {
            GetResponse<FileResultModels> resultado = new GetResponse<FileResultModels>();
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
    }
}