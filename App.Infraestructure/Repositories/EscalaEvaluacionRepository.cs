using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class EscalaEvaluacionRepository : IEscalaEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public EscalaEvaluacionRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Tbl_com_EscalaEvaluacionModels>> ListEscalasByAspectoId(int EmpresaId, long AspectoId)
    {
        try
        {
            var objResult = await _context.TBL_com_EscalaEvaluacion.AsNoTracking()
            .Where(x => x.AspectovaloracionId == AspectoId && x.EmpresaId == EmpresaId && x.Estado == true)
            .OrderBy(y => y.Escala)
            .ToListAsync();
            return _mapper.Map<List<Tbl_com_EscalaEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEscalasByAspectoId", ex, EmpresaId +"/" +AspectoId);
            throw;
        }
    }

    public async Task<List<Tbl_com_EscalaEvaluacionModels>> ListEscalasEvaluacion(int EmpresaId)
    {
        try
        {
            var objResult = await _context.TBL_com_EscalaEvaluacion.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.Estado == true)
            .OrderBy(y => y.Escala)
            .ToListAsync();
            return _mapper.Map<List<Tbl_com_EscalaEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEscalasEvaluacion", ex, EmpresaId.ToString());
            throw;
        }
    }

    public async Task<Tbl_com_EscalaEvaluacionModels> EscalaByEscalaId(int EscalaId)
    {
        try
        {
            var objResult = await _context.TBL_com_EscalaEvaluacion.AsNoTracking()
            .Where(x => x.EscalaId == EscalaId)
            .FirstOrDefaultAsync();
            return _mapper.Map<Tbl_com_EscalaEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("EscalaByEscalaId", ex, EscalaId.ToString());
            throw;
        }
    }
}
