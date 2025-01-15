using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Models.Models.TblAud;
using AutoMapper;
using Newtonsoft.Json;
using System;
using App.Infraestructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories;

public class EvaAuditoresRepository : IEvaAuditoresRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;


    public EvaAuditoresRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseTBL_aud_EvaAuditoresModels> ObjEncabezadoEvaAuditores(long IdEvaluacion)
    {
        try
        {
            var objResult = await _context.TBL_aud_EvaAuditores.AsNoTracking()
            .Where(x => x.IdEvaluacion == IdEvaluacion)
            .Include(x => x.AuditoriasObj)
            .ThenInclude(y => y.ProcesosObj)
            .Include(x => x.AuditorObj)
            .FirstOrDefaultAsync();
            return _mapper.Map<ResponseTBL_aud_EvaAuditoresModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjDataEvaAuditores", ex, IdEvaluacion.ToString());
            throw;
        }
    }

    public async Task<TBL_aud_EvaAuditoresModels> GetObjEvaAuditores(long IdEvaluacion)
    {
        try
        {
            var objResult = await _context.TBL_aud_EvaAuditores.AsNoTracking()
            .Where(x => x.IdEvaluacion == IdEvaluacion)
            .FirstOrDefaultAsync();
            return _mapper.Map<TBL_aud_EvaAuditoresModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetObjEvaAuditores", ex, IdEvaluacion.ToString());
            throw;
        }
    }

    public async Task<TBL_aud_EvaAuditoresModels> CrearEvaAuditores(TBL_aud_EvaAuditoresModels ObjCreate, int EmpresaId)
    {
        var objResultEvaAuditorias = await _context.TBL_aud_EvaAuditores.FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId);
        ObjCreate.IdEvaluacion = objResultEvaAuditorias.IdEvaluacion;
        ObjCreate.IdAuditoria = objResultEvaAuditorias.IdAuditoria;
        ObjCreate.IdAuditor = objResultEvaAuditorias.IdAuditor;
        ObjCreate.Promedio = objResultEvaAuditorias.Promedio;
        ObjCreate.Observaciones = ObjCreate.Observaciones == "" ? "." : ObjCreate.Observaciones;
        ObjCreate.TotalPreCalificadas = objResultEvaAuditorias.TotalPreCalificadas;
        ObjCreate.TotalPreguntas = objResultEvaAuditorias.TotalPreguntas;
        ObjCreate.Estado = objResultEvaAuditorias.Estado;
        try
        {
            _context.TBL_aud_EvaAuditores.Add(_mapper.Map<tbl_aud_EvaAuditoresEntities>(ObjCreate));
            await _context.SaveChangesAsync();
            var ObjResultEvaAud = await _context.TBL_aud_EvaAuditores.OrderByDescending(e => e.EmpresaId).FirstOrDefaultAsync();
            return _mapper.Map<TBL_aud_EvaAuditoresModels>(ObjResultEvaAud);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CrearAuditorias", ex, JsonConvert.SerializeObject(ObjCreate));
            throw;
        }
    }

    public async Task<TBL_aud_EvaAuditoresModels> UpdateEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate)
    {
        var UpdateRegistro = _context.TBL_aud_EvaAuditores.FirstOrDefault(p => p.IdEvaluacion == ObjUpdate.IdEvaluacion);
        try
        {
            if (UpdateRegistro != null)
            {
                #region Update
                UpdateRegistro.EmpresaId = ObjUpdate.EmpresaId;
                UpdateRegistro.IdAuditoria = ObjUpdate.IdAuditoria;
                UpdateRegistro.IdAuditor = ObjUpdate.IdAuditor;
                UpdateRegistro.Promedio = ObjUpdate.Promedio;
                UpdateRegistro.Observaciones = ObjUpdate.Observaciones;
                UpdateRegistro.TotalPreCalificadas = ObjUpdate.TotalPreCalificadas;
                UpdateRegistro.TotalPreguntas = ObjUpdate.TotalPreguntas;
                UpdateRegistro.Estado = ObjUpdate.Estado;
                #endregion
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateEvaAuditores", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_aud_EvaAuditoresModels>(UpdateRegistro);
    }

    public async Task<TBL_aud_EvaAuditoresModels> UpdateObservacionEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate)
    {
        var UpdateRegistro = _context.TBL_aud_EvaAuditores.FirstOrDefault(p => p.IdEvaluacion == ObjUpdate.IdEvaluacion);
        try
        {
            if (UpdateRegistro != null)
            {
                #region Update
                UpdateRegistro.Observaciones = ObjUpdate.Observaciones;
                #endregion
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateObservacionEvaAuditores", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_aud_EvaAuditoresModels>(UpdateRegistro);
    }

    public async Task<TBL_aud_EvaAuditoresModels> UpdateContadorEvaAuditores(long IdEvaluacion, bool Gest)
    {
        var UpdateRegistro = _context.TBL_aud_EvaAuditores.FirstOrDefault(p => p.IdEvaluacion == IdEvaluacion);
        try
        {
            if (UpdateRegistro != null)
            { 
                #region Update
                if (UpdateRegistro.TotalPreCalificadas < UpdateRegistro.TotalPreguntas)
                {
                    if (Gest)
                    {
                        UpdateRegistro.TotalPreCalificadas = UpdateRegistro.TotalPreCalificadas + 1;
                    }
                    {
                        UpdateRegistro.TotalPreCalificadas = UpdateRegistro.TotalPreCalificadas - 1;
                    }
                }
                #endregion
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateContadorEvaAuditores", ex, IdEvaluacion.ToString());
            throw;
        }
        return _mapper.Map<TBL_aud_EvaAuditoresModels>(UpdateRegistro);
    }

    public async Task<string> DeleteEvaAuditores(int IdEvaluacion)
    {
        try
        {
            var objDelete = await _context.TBL_aud_EvaAuditores.FirstOrDefaultAsync(x => x.IdEvaluacion == IdEvaluacion);
            _context.TBL_aud_EvaAuditores.Remove(objDelete);
            await _context.SaveChangesAsync();
            return "Registro Eliminado";
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("DeleteEvaAuditores", ex, IdEvaluacion.ToString());
            throw;
        }
    }

}
