using App.Models.Helpers;
using AutoMapper;
using App.Infraestructure.Connect;
using App.Infraestructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using App.Models.Models.Scp;
using App.Models.Models.Share;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public UsuarioRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SCP_UsuarioModels> GetAutenticateUser(LoginModel keyUser)
    {
        var objResult = await _context.SCP_Usuario.FirstOrDefaultAsync(x => x.WWID == keyUser.Id);
        return _mapper.Map<SCP_UsuarioModels>(objResult);
    }

    public async Task<List<SCP_UsuarioModels>> GetUsuarios()
    {
        var objResult = await  _context.SCP_Usuario.ToListAsync();
        return _mapper.Map<List<SCP_UsuarioModels>>(objResult);
    }

    public async Task<PaginacionHelpers<SCP_UsuarioModels>> GetUsuariosPageList(PaginacionParamsHelpers objParams)
    {
        int total = await _context.SCP_Usuario.CountAsync();
        var objResult = await _context.SCP_Usuario
            .Skip((objParams.PageIndex - 1) * objParams.PageSize)
            .Take(objParams.PageSize)
            .ToListAsync();
        var resuList = _mapper.Map<List<SCP_UsuarioModels>>(objResult);

        return new PaginacionHelpers<SCP_UsuarioModels>(resuList, total, objParams.PageIndex, objParams.PageSize, objParams.Search);
    }

    public async Task<string> CrearUsuario(scp_UsuariosEntities objUsuario)
    {
         _context.SCP_Usuario.Add(objUsuario);
        await _context.SaveChangesAsync();
        return "PruebaResult";
    }

    public async Task<string> UpdateUsuario(scp_UsuariosEntities objUsuario)
    {
        _context.SCP_Usuario.Update(objUsuario);
        await _context.SaveChangesAsync();
        return "PruebaResult";
    }

    public async Task<string> DeleteUsuario(int id)
    {
        var objUsuario = await _context.SCP_Usuario.FindAsync(id);
        _context.SCP_Usuario.Remove(objUsuario);
        await _context.SaveChangesAsync();
        return "PruebaResult";
    }
}
