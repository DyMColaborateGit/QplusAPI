using App.Infraestructure.IRepositories;
using App.Models.Global;
using App.Models.Models.Scp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qplus.Controllers
{
    /// <summary>
    /// UsuariosRolesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosRolesController : ControllerBase
    {
        private readonly IUsuariosRolesRepository _usuariosRolesRepository;
        /// <summary>
        /// UsuariosRolesController
        /// </summary>
        public UsuariosRolesController(IUsuariosRolesRepository usuariosRolesRepository)
        {
            _usuariosRolesRepository = usuariosRolesRepository;
        }

        /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetListfuncionariosByrolByIdentificacion/{EmpresaId}/{NomRole}")]
        public async Task<GetResponse<List<ResponseSCP_UsuariosRolesModels>>> GetListfuncionariosByrolByIdentificacion(int EmpresaId, string NomRole)
        {
            GetResponse<List<ResponseSCP_UsuariosRolesModels>> resultado = new GetResponse<List<ResponseSCP_UsuariosRolesModels>>();
            try
            {
                resultado.Data = await _usuariosRolesRepository.ListUsuariosRoles(EmpresaId, NomRole);
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
