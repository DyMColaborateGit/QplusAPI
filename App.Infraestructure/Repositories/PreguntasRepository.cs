using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace App.Infraestructure.Repositories;

public class PreguntasRepository : IPreguntasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public PreguntasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TBL_aud_preguntasModels>> ListPreguntas(int IdPregunta)
    {
        try
        {

            var preguntas = await _context.TBL_aud_preguntas
                .Where(a => a.IdPregunta == IdPregunta)
                .ToListAsync();
            return _mapper.Map<List<TBL_aud_preguntasModels>>(preguntas);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListPreguntas", ex, IdPregunta.ToString());
            throw;
        }


    }
    public async Task<TBL_aud_preguntasModels> CrearPreguntas(TBL_aud_preguntasModels ObjCreate, int EmpresaId)
    {
        var objResultPreguntas = await _context.TBL_aud_preguntas.FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId);
        ObjCreate.IdPregunta = objResultPreguntas.IdPregunta;
        ObjCreate.PreguntaTexto = objResultPreguntas.PreguntaTexto;
        ObjCreate.Estado = objResultPreguntas.Estado;
        try
        {
            _context.TBL_aud_preguntas.Add(_mapper.Map<tbl_aud_preguntasEntities>(ObjCreate));
            await _context.SaveChangesAsync();
            var ObjResultAud = await _context.TBL_aud_preguntas.OrderByDescending(e => e.EmpresaId).FirstOrDefaultAsync();
            return _mapper.Map<TBL_aud_preguntasModels>(ObjResultAud);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CrearPreguntas", ex, JsonConvert.SerializeObject(ObjCreate));
            throw;
        }
    }

    public async Task<string> DeletePreguntas(int IdPregunta)
    {
        try
        {

            var objDelete = await _context.TBL_aud_preguntas.FirstOrDefaultAsync(x => x.IdPregunta == IdPregunta);
            _context.TBL_aud_preguntas.Remove(objDelete);
            await _context.SaveChangesAsync();
            return "Registro Eliminado";
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("DeletePreguntas", ex, IdPregunta.ToString());
            throw;
        }
    }
}
