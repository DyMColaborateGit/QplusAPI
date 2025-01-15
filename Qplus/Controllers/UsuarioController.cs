using App.logic.IServices;
using App.Models.Global;
using App.Models.Helpers;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService) 
    {
        _usuarioService = usuarioService;
    }


    /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
    /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
    /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("GetUsuarios")]
    public async Task<GetResponse<List<SCP_UsuarioModels>>>GetUsuarios()
    {
        GetResponse<List<SCP_UsuarioModels>> ObjResult = new GetResponse<List<SCP_UsuarioModels>>();
        try
        {
            ObjResult.StatusCode = (int)HttpCodes.OK;
            ObjResult.Data = await _usuarioService.GetListUsuarios();
            ObjResult.Message = new HttpCodesMessage().OK;
        }
        catch(Exception ex)
        {
            ObjResult.StatusCode = (int)HttpCodes.INTERNALERROR;
            ObjResult.Message = new HttpCodesMessage().INTERNALERROR;
            ObjResult.CathError = ex.Message.ToString();
        }

        return ObjResult;
    }

    /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
    /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
    /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("GetUsuariosPaginados")]
    public async Task<GetResponse<PaginacionHelpers<SCP_UsuarioModels>>> GetListUsuariosPaginados([FromQuery]PaginacionParamsHelpers ObjParams)
    {
        GetResponse<PaginacionHelpers<SCP_UsuarioModels>> ObjResult = new GetResponse<PaginacionHelpers<SCP_UsuarioModels>>();
        try
        {
            ObjResult.StatusCode = (int)HttpCodes.OK;
            ObjResult.Data = await _usuarioService.GetUsuariosPaginados(ObjParams);
            ObjResult.Message = new HttpCodesMessage().OK;
        }
        catch (Exception ex)
        {
            ObjResult.StatusCode = (int)HttpCodes.INTERNALERROR;
            ObjResult.Message = new HttpCodesMessage().INTERNALERROR;
            ObjResult.CathError = ex.Message.ToString();
        }

        return ObjResult;
    }

}
