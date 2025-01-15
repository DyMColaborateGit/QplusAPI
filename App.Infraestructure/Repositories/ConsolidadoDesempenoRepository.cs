using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories;

public class ConsolidadoDesempenoRepository: IConsolidadoDesempenoRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ConsolidadoDesempenoRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TBL_com_ConsolidadoDesempenoModels>> ListConsolidadoDesempeno(long EvaluacionId, int TipoId)
    {
        try
        {
            var objResult = await _context.TBL_com_ConsolidadoDesempeno.AsNoTracking()
                .Where(x => x.EvaluacionId == EvaluacionId && x.TipoId == TipoId)
                .ToListAsync();
            return _mapper.Map<List<TBL_com_ConsolidadoDesempenoModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListConsolidadoDesempeno", ex, EvaluacionId + "/" + TipoId);
            throw;
        }
    }

    public async Task<TBL_com_ConsolidadoDesempenoModels> CreateConsolidadoDesempeno(TBL_com_ConsolidadoDesempenoModels objCreate)
    {
        try
        {
            _context.TBL_com_ConsolidadoDesempeno.Add(_mapper.Map<tbl_com_ConsolidadoDesempenoEntities>(objCreate));
            await _context.SaveChangesAsync();
            var ObjResult = await _context.TBL_com_ConsolidadoDesempeno.OrderByDescending(e => e.ConsolidadoId).FirstOrDefaultAsync();
            return _mapper.Map<TBL_com_ConsolidadoDesempenoModels>(ObjResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CreateConsolidadoDesempeno", ex, JsonConvert.SerializeObject(objCreate));
            throw;
        }
    }

    public async Task<TBL_com_ConsolidadoDesempenoModels> UpdateConsolidadoDesempeno(TBL_com_ConsolidadoDesempenoModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_ConsolidadoDesempeno.FirstOrDefault(p => p.ConsolidadoId == ObjUpdate.ConsolidadoId);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.EvaluacionId = ObjUpdate.EvaluacionId;
                updateRegistro.TipoId = ObjUpdate.TipoId;
                updateRegistro.ValorAnalisis = ObjUpdate.ValorAnalisis;
                updateRegistro.Nivel = ObjUpdate.Nivel;
                updateRegistro.Color = ObjUpdate.Color;
            }
            #endregion
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateConsolidadoDesempeno", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_com_ConsolidadoDesempenoModels>(updateRegistro);
    }
}
