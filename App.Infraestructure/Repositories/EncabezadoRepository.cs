using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class EncabezadoRepository : IEncabezadoRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public EncabezadoRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseEncabezadoEvaModels> ObjEncabezadoEvaluacionByEvaluacionId(long EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_Encabezado.AsNoTracking()
            .Include(p => p.ProgEvaluacionobj)
            .FirstOrDefaultAsync(x => x.InIdEbaluacion == EvaluacionId);
            return _mapper.Map<ResponseEncabezadoEvaModels>(objResult);
           
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjEncabezadoEvaluacionByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }

    public async Task<Tbl_com_EncabezadoEvaModels> ObjConsultEncabezadoEvaluacionByEvaluacionId(long EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_Encabezado.AsNoTracking()
            .FirstOrDefaultAsync(x => x.InIdEbaluacion == EvaluacionId);
            return _mapper.Map<Tbl_com_EncabezadoEvaModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException( "ObjConsultEncabezadoEvaluacionByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }

    }
}
