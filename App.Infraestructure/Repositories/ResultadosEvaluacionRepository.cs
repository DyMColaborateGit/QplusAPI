using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories;

public class ResultadosEvaluacionRepository : IResultadosEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ResultadosEvaluacionRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Tbl_com_ResultadosEvaluacionModels> ObjResultadosEvaluacion(long ResultadoId)
    {
        try
        {
            var updateRegistro = await _context.TBL_com_ResultadosEvaluacion.FirstOrDefaultAsync(p => p.ResultadoId == ResultadoId);
            return _mapper.Map<Tbl_com_ResultadosEvaluacionModels>(updateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjResultadosEvaluacion", ex, ResultadoId.ToString());
            throw;
        }
    }

    public async Task<Tbl_com_ResultadosEvaluacionModels> ObjResultadosEvaluacionByEvaluacionIdByNormaId(long EvaluacionId, int NormaId)
    {
        try
        {
            var updateRegistro = await _context.TBL_com_ResultadosEvaluacion.FirstOrDefaultAsync(p => p.EvaluacionId == EvaluacionId && p.NormaId == NormaId);
            return _mapper.Map<Tbl_com_ResultadosEvaluacionModels>(updateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjResultadosEvaluacionByEvaluacionIdByNormaId", ex, EvaluacionId.ToString()+"/"+ NormaId.ToString());
            throw;
        }
    }

    public async Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> ListCompetenciasByEvaluacionId(long EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ResultadosEvaluacion
            .Include(p => p.Normasobj)
            .Where(x => x.EvaluacionId == EvaluacionId)
            .ToListAsync();
            return _mapper.Map<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListCompetenciasByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }

    public async Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> ListFormEvaluacionByEvaluacionId(long EvaluacionId)
    {
        try
        {
            List<ResponseJoinTbl_com_ResultadosEvaluacionModels> objResult = _mapper.Map<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>>(await _context.TBL_com_ResultadosEvaluacion.AsNoTracking()
            .Include(p => p.Normasobj)
            .Where(x => x.EvaluacionId == EvaluacionId)
            .ToListAsync());

            foreach (var resultado in objResult)
            {
                resultado.Comportamientos = _mapper.Map<List<Tbl_com_ResultadosModels>>(_context.TBL_com_Resultados.AsNoTracking()
                    .Where(y => y.NormaId == resultado.NormaId && y.EvaluacionId == EvaluacionId)
                    .ToList());
            }
            return objResult;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListFormEvaluacionByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }

    public async Task<Tbl_com_ResultadosEvaluacionModels> UpdateResultadosEvaluacion(Tbl_com_ResultadosEvaluacionModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_ResultadosEvaluacion.FirstOrDefault(p => p.ResultadoId == ObjUpdate.ResultadoId);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.EvaluacionId = ObjUpdate.EvaluacionId;
                updateRegistro.NormaId = ObjUpdate.NormaId;
                updateRegistro.Resultado = ObjUpdate.Resultado;
                updateRegistro.Porcentaje = ObjUpdate.Porcentaje;
                updateRegistro.Nivel = ObjUpdate.Nivel;
                updateRegistro.Color = ObjUpdate.Color;
                updateRegistro.Observaciones = ObjUpdate.Observaciones;
            }
            #endregion
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateResultadosEvaluacion", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<Tbl_com_ResultadosEvaluacionModels>(updateRegistro);
    }

    public async Task<Tbl_com_ResultadosEvaluacionModels> CreaResultadosEvaluacion(Tbl_com_ResultadosEvaluacionModels objCreate)
    {
        try
        {
            _context.TBL_com_ResultadosEvaluacion.Add(_mapper.Map<tbl_com_ResultadosEvaluacionEntities>(objCreate));
            await _context.SaveChangesAsync();
            var ObjResult = await _context.TBL_com_ResultadosEvaluacion.OrderByDescending(e => e.ResultadoId).FirstOrDefaultAsync();
            return _mapper.Map<Tbl_com_ResultadosEvaluacionModels>(ObjResult);
        }
         catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CreaResultadosEvaluacion", ex, JsonConvert.SerializeObject(objCreate));
            throw;
        }
    }

}
