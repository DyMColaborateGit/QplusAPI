using App.Models.Helpers;
using App.Infraestructure.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Models.Models.Scp;
using App.Models.Models.Share;

namespace App.logic.IServices;

public class UsuarioService : IUsuarioService
{
    private readonly JWTHelpers _lwtHelpers;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<SCP_UsuarioModels> _passwordHasher;

    public UsuarioService(IUsuarioRepository usuarioRepository, IOptions<JWTHelpers> jwt, IPasswordHasher<SCP_UsuarioModels> passwordHasher) 
    {
        _lwtHelpers = jwt.Value;
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<SCP_UsuarioModels>> GetListUsuarios()
    {
        var objResult = await _usuarioRepository.GetUsuarios();

        return objResult;
    }

    public async Task<PaginacionHelpers<SCP_UsuarioModels>> GetUsuariosPaginados(PaginacionParamsHelpers objParams)
    {
        var ObjResult = await _usuarioRepository.GetUsuariosPageList(objParams);
        return ObjResult;
    }

    public async Task<LoginModel> GetValueAutenticateUser(LoginModel keyUser)
    {
        LoginModel gestAutenticate = new LoginModel();
        var objUsuario = await _usuarioRepository.GetAutenticateUser(keyUser);

        gestAutenticate.EstaAutenticado = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(objUsuario);
        gestAutenticate.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return gestAutenticate;
    }
    private JwtSecurityToken CreateJwtToken(SCP_UsuarioModels usuario)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.WWID.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("uid", usuario.WWID.ToString())
        };
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_lwtHelpers.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _lwtHelpers.Issuer,
            audience: _lwtHelpers.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_lwtHelpers.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
