using App.Models.Helpers;
using App.Models.Models.Scp;
using App.Models.Models.Share;

namespace App.Infraestructure.IRepositories;

public interface IUsuarioRepository
{
    Task<List<SCP_UsuarioModels>> GetUsuarios();
    Task<PaginacionHelpers<SCP_UsuarioModels>> GetUsuariosPageList(PaginacionParamsHelpers objParams);
    Task<SCP_UsuarioModels> GetAutenticateUser(LoginModel keyUser);
}
