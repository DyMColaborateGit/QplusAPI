using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories;

public class NivelesCompetenciasRepository: INivelesCompetenciasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public NivelesCompetenciasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_NivelesCompetenciasModels> ObjNivelesCompetencias(double ValorComp, double ValorInd)
    {
        try
        {
            var objResult = await _context.TBL_com_NivelesCompetencias.AsNoTracking()
            .FirstOrDefaultAsync(x => x.ValorMinComp <= ValorComp && x.ValorMaxComp >= ValorComp && x.ValorMaxInd <= ValorInd && x.ValorMinInd >= ValorInd);
            return _mapper.Map<TBL_com_NivelesCompetenciasModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjNivelesCompetencias", ex, ValorComp + "/" + ValorInd);
            throw;
        }
    }
}
