using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class ObjetivosCalidadRepository: IObjetivosCalidadRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ObjetivosCalidadRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Tbl_ind_ObjetivosCalidadModels>> ListObjetivosCalidadByEmpresaId(int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_ind_ObjetivosCalidad.AsNoTracking()
                .Where(x => x.EmpresaId == EmpresaId)
                .ToListAsync();
            return _mapper.Map<List<Tbl_ind_ObjetivosCalidadModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListObjetivosCalidadByEmpresaId", ex, EmpresaId.ToString());
            throw;
        }
    }
}
