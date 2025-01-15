using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblAud;
using AutoMapper;
using Newtonsoft.Json;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infraestructure.Repositories;

public class EvaPreguntasRepository : IEvaPreguntasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IEvaAuditoresRepository _evaAuditoresRepository;

    public EvaPreguntasRepository(ConnectContext context, IMapper mapper, IEvaAuditoresRepository evaAuditoresRepository)
    {
        _context = context;
        _mapper = mapper;
        _evaAuditoresRepository = evaAuditoresRepository;
    }

    public async Task<List<TBL_aud_EvaPreguntasModels>> ListEvaPreguntas(long IdEvaluacion)
    {
        try
        {
            var evaPreguntas = await _context.TBL_aud_EvaPreguntas
                .Where(a => a.IdEvaluacion == IdEvaluacion)
                .ToListAsync();
            return _mapper.Map<List<TBL_aud_EvaPreguntasModels>>(evaPreguntas);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaPreguntas", ex, IdEvaluacion.ToString());
            throw;
        }
    }

    public async Task<decimal> GetPromedioEvaPreguntas(long IdEvaluacion)
    {
        try
        {
            decimal evaPreguntas = (decimal)(await _context.TBL_aud_EvaPreguntas
                .Where(a => a.IdEvaluacion == IdEvaluacion && a.Calificacion != null)
                .Select(x => x.Calificacion.Value)
                .AverageAsync());
            return evaPreguntas;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetPromedioEvaPreguntas", ex, IdEvaluacion.ToString());
            throw;
        }
    }

    public async Task<TBL_aud_EvaPreguntasModels> CrearEvaPreguntas(TBL_aud_EvaPreguntasModels ObjCreate, int EmpresaId)
    {
        var objResultEvaPreguntas = await _context.TBL_aud_EvaPreguntas.FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId);
        ObjCreate.IdEvaPregunta = objResultEvaPreguntas.IdEvaPregunta;
        ObjCreate.IdPregunta = objResultEvaPreguntas.IdPregunta;
        ObjCreate.IdEvaluacion = objResultEvaPreguntas.IdEvaluacion;
        ObjCreate.Calificacion = objResultEvaPreguntas.Calificacion;
        ObjCreate.TextPregunta = ObjCreate.TextPregunta == "" ? "." : ObjCreate.TextPregunta;
        try
        {
            _context.TBL_aud_EvaPreguntas.Add(_mapper.Map<tbl_aud_EvaPreguntasEntities>(ObjCreate));
            await _context.SaveChangesAsync();
            var ObjResultEvaPre = await _context.TBL_aud_EvaPreguntas.OrderByDescending(e => e.EmpresaId).FirstOrDefaultAsync();
            return _mapper.Map<TBL_aud_EvaPreguntasModels>(ObjResultEvaPre);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CrearEvaPreguntas", ex, JsonConvert.SerializeObject(ObjCreate));
            throw;
        }
    }

    public async Task<TBL_aud_EvaPreguntasModels> PutEvaPreguntasByCalificacion(long IdEvaluacion, int Calificacion, long IdEvaPregunta)
    {
        var UpdateRegistro = _context.TBL_aud_EvaPreguntas.FirstOrDefault(p => p.IdEvaPregunta == IdEvaPregunta);
        try
        {
            if (UpdateRegistro != null)
            {
                if (UpdateRegistro.Calificacion == 0 && Calificacion != 0)
                {
                    await _evaAuditoresRepository.UpdateContadorEvaAuditores(IdEvaluacion, true);
                }
                else if (UpdateRegistro.Calificacion != 0 && Calificacion == 0)
                {
                    await _evaAuditoresRepository.UpdateContadorEvaAuditores(IdEvaluacion, false);
                }
                UpdateRegistro.Calificacion = Calificacion;
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<TBL_aud_EvaPreguntasModels>(UpdateRegistro);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("PutEvaPreguntasByCalificacion", ex, IdEvaluacion +"/"+ Calificacion +"/"+ IdEvaPregunta);
            throw;
        }
    }

    public async Task<string> DeleteEvaPreguntas(int IdEvaPregunta)
    {
        try
        {
            var objDelete = await _context.TBL_aud_EvaPreguntas.FirstOrDefaultAsync(x => x.IdEvaPregunta == IdEvaPregunta);
            _context.TBL_aud_EvaPreguntas.Remove(objDelete);
            await _context.SaveChangesAsync();
            return "Registro Eliminado";
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("DeleteEvaPreguntas", ex, IdEvaPregunta.ToString());
            throw;
        }
    }
}
