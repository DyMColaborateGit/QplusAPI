using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class TxtFormEvaluacionRepository: ITxtFormEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public TxtFormEvaluacionRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Tbl_com_TxtFormEvaluacionModels> ObjTxtFormEvaluacion(int EmpresaId, int Tipotexto, int Tipovaloracion, int Anio)
    {
        try
        {
            var objResult = await _context.TBL_com_TxtFormEvaluacion.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.Tipotxt == Tipotexto && x.TipovaloracionId == Tipovaloracion && x.Anio == Anio)
            .FirstOrDefaultAsync();
            return _mapper.Map<Tbl_com_TxtFormEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjTxtFormEvaluacion", ex, EmpresaId + "/" + Tipotexto + "/" +Tipovaloracion + "/" + Anio);
            throw;
        }
    }

    public async Task<List<Tbl_com_TxtFormEvaluacionModels>> ListTxtFormEvaluacion(int EmpresaId, int Anio)
    {
        try
        {
            var objResult = await _context.TBL_com_TxtFormEvaluacion.AsNoTracking()
            .Where(x => x.EmpresaId == EmpresaId && x.Anio == Anio)
            .ToListAsync();
            return _mapper.Map<List<Tbl_com_TxtFormEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListTxtFormEvaluacion", ex, EmpresaId+ "/" + Anio);
            throw;
        }
    }
}
