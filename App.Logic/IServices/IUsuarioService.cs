using App.Models.Helpers;
using App.Models.Models.Scp;
using App.Models.Models.Share;

namespace App.logic.IServices;

public interface IUsuarioService
{
    Task<List<SCP_UsuarioModels>> GetListUsuarios();
    Task<PaginacionHelpers<SCP_UsuarioModels>> GetUsuariosPaginados(PaginacionParamsHelpers objParams);
    Task<LoginModel> GetValueAutenticateUser(LoginModel keyUser);
}
