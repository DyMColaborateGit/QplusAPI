using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class AspectosValoracionRepository: IAspectosValoracionRepository
{
    private readonly ConnectContext _context;

    public AspectosValoracionRepository(ConnectContext context)
    {
        _context = context;
    }


    /// <summary>
    /// ExisteAspectosValoracion
    /// </summary>
    public async Task<bool> ExisteAspectosValoracion(int EmpresaId, int AspectoValoracionId, bool Estado)
    {
        try
        {
            return _context.TBL_com_AspectosValoracion.AsNoTracking()
                  .Any(x => x.AspectoValoracionId == AspectoValoracionId && x.EmpresaId == EmpresaId && x.Estado == Estado);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ExisteAspectosValoracion", ex, EmpresaId + "/" + AspectoValoracionId + "/" + Estado);
            throw;
        }
    }

}
