using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class UsuariosRolesRepository: IUsuariosRolesRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public UsuariosRolesRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ResponseSCP_UsuariosRolesModels>> ListUsuariosRoles(int EmpresaId, string NomRole)
    {
        try
        {
            var objResult = await _context.SCP_UsuariosRoles.AsNoTracking()
                .Include(x => x.Usuariobj)
                .Include(x => x.Roleobj)
                .Where(x => x.Usuariobj.EmpresaId == EmpresaId && x.Roleobj.Role == NomRole)
                .OrderBy(x => x.Usuariobj.Nombre)
                .ToListAsync();
            return _mapper.Map<List<ResponseSCP_UsuariosRolesModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListUsuariosRoles", ex, EmpresaId.ToString()+ "/" + NomRole);
            throw;
        }
    }
}
