using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories;

public class ResultIndiCoporpRepository: IResultIndiCoporpRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ResultIndiCoporpRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<JOINTBL_ind_ResultIndiCoporpModels> ResultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
    {
        try
        {
            var objResult = await _context.TBL_ind_ResultIndiCoporp
                .Where(x => x.Anio == InAnio && x.EmpresaId == EmpresaId)
                .FirstAsync();

            var ListResultIndiCoporp = _mapper.Map<JOINTBL_ind_ResultIndiCoporpModels>(objResult);
            ListResultIndiCoporp.MastIndicadoresobj = _mapper.Map<Tbl_ind_MastIndicadoresModels>(await _context.TBL_ind_MastIndicadores.AsNoTracking().FirstOrDefaultAsync(x => x.ClaseId == 7 && x.CodIndicador == ListResultIndiCoporp.CodigoIndi));
            return ListResultIndiCoporp;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ResultadoTotalIndicadoreCorporativos", ex, EvaluacionId + "/"+ EmpresaId+"/"+ InAnio);
            throw;
        }
    }

    public async Task<List<JOINTBL_ind_ResultIndiCoporpModels>> ListResultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio)
    {
        try
        {
            var objResult = await _context.TBL_ind_ResultIndiCoporp.AsNoTracking()
                .Where(x => x.Anio == InAnio && x.EmpresaId == EmpresaId)
                .ToListAsync();
            var ListResultIndiCoporp = _mapper.Map<List<JOINTBL_ind_ResultIndiCoporpModels>>(objResult);
            foreach (var item in ListResultIndiCoporp)
            {
                item.MastIndicadoresobj = _mapper.Map<Tbl_ind_MastIndicadoresModels>(await _context.TBL_ind_MastIndicadores.AsNoTracking().FirstOrDefaultAsync(x => x.ClaseId == 7 && x.CodIndicador == item.CodigoIndi));
            }
            return ListResultIndiCoporp;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListResultadoTotalIndicadoreCorporativos", ex, EvaluacionId + "/" + EmpresaId + "/" + InAnio);
            throw;
        }
    }
}
