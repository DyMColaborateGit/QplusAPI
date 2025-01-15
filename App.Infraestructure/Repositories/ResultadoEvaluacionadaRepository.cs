using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Infraestructure.Repositories;

public class ResultadoEvaluacionadaRepository: IResultadoEvaluacionadaRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ResultadoEvaluacionadaRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_ResultadoEvaluacionADAModels> ObjResultadoEvaluacionada(long IdResultado)
    {
        try
        {
            var updateRegistro = await _context.TBL_com_ResultadoEvaluacionada.FirstOrDefaultAsync(p => p.IdResultado == IdResultado);
            return _mapper.Map<TBL_com_ResultadoEvaluacionADAModels>(updateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjResultadoEvaluacionada", ex, IdResultado.ToString());
            throw;
        }

    }

    public async Task<List<TBL_com_ResultadoEvaluacionADAModels>> ListResultadoEvaluacionadaByEvaluacionId(long EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ResultadoEvaluacionada.AsNoTracking()
                .Where(x => x.IdEvaluacion == EvaluacionId)
                .ToListAsync();
            return _mapper.Map<List<TBL_com_ResultadoEvaluacionADAModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListResultadoEvaluacionadaByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }

    public async Task<List<TBL_com_ResultadoEvaluacionADAModels>> ListResultadoEvaluacionadaByIdHijoByEvaluacionId(long EvaluacionId, int IdHijo)
    {
        try
        {
            var objResult = await _context.TBL_com_ResultadoEvaluacionada.AsNoTracking()
                .Where(x => x.IdEvaluacion == EvaluacionId && x.IdHijo == IdHijo)
                .ToListAsync();
            return _mapper.Map<List<TBL_com_ResultadoEvaluacionADAModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListResultadoEvaluacionadaByIdHijoByEvaluacionId", ex, EvaluacionId.ToString()+"/"+ IdHijo.ToString());
            throw;
        }
    }

    public async Task<List<TBL_com_ResultadoEvaluacionADAModels>> UpdateListResultadoEvaluacionada(List<TBL_com_ResultadoEvaluacionADAModels> ObjUpdate)
    {
        List<TBL_com_ResultadoEvaluacionADAModels> Result = new List<TBL_com_ResultadoEvaluacionADAModels>();
        try
        {
            foreach (var item in ObjUpdate)
            {
                var updateResult = await UpdateResultadoEvaluacionada(item);
                Result.Add(updateResult);
            }
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateListResultadoEvaluacionada", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }

        return Result;
    }

    public async Task<TBL_com_ResultadoEvaluacionADAModels> UpdateResultadoEvaluacionada(TBL_com_ResultadoEvaluacionADAModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_ResultadoEvaluacionada.FirstOrDefault(p => p.IdResultado == ObjUpdate.IdResultado);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.IdEvaluacion = ObjUpdate.IdEvaluacion;
                updateRegistro.IdPadre = ObjUpdate.IdPadre;
                updateRegistro.IdHijo = ObjUpdate.IdHijo;
                updateRegistro.TextoPregunta = ObjUpdate.TextoPregunta;
                updateRegistro.TextoRespuesta = ObjUpdate.TextoRespuesta;
                updateRegistro.ResultadoTxt = ObjUpdate.ResultadoTxt;
                updateRegistro.Resultado = ObjUpdate.Resultado;
                updateRegistro.Tipo = ObjUpdate.Tipo;
                updateRegistro.Orden = ObjUpdate.Orden;
            }
            #endregion
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateResultadoEvaluacionada", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_com_ResultadoEvaluacionADAModels>(updateRegistro);
    }
}
