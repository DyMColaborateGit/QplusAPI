using App.logic.IServices;
using App.Models.Models.Share;
using Microsoft.AspNetCore.Mvc;

namespace Webapp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutenticateController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public AutenticateController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // POST: AutenticateUser
    /// <summary>
    /// Obtiene la autenticacion del Usuario.
    /// </summary>
    /// <remarks>
    /// Nos permite crear un script de autenticación para la plataforma.
    /// </remarks>
    /// <param name="KeyUser">Son las credenciales de autenticación del usuario</param>
    /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
    /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
    /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("AutenticateUser")]
    public async Task<ActionResult<LoginModel>> GetAutenticateUser(LoginModel KeyUser)
    {
        var ObjResult = await _usuarioService.GetValueAutenticateUser(KeyUser);
        return ObjResult;
    }
}
