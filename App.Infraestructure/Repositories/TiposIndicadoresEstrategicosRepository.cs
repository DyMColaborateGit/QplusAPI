using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class TiposIndicadoresEstrategicosRepository: ITiposIndicadoresEstrategicosRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public TiposIndicadoresEstrategicosRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TBL_ind_TiposIndicadoresEstrategicosModels>> ListTiposIndicadoresEstrategicosByEmpresaId(int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_ind_TiposIndicadoresEstrategicos.AsNoTracking()
                .Where(x => x.EmpresaId == EmpresaId)
                .ToListAsync();
            return _mapper.Map<List<TBL_ind_TiposIndicadoresEstrategicosModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListTiposIndicadoresEstrategicosByEmpresaId", ex, EmpresaId.ToString());
            throw;
        }
    }
}
