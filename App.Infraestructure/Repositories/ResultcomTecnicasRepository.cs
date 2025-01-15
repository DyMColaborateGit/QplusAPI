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

public class ResultcomTecnicasRepository: IResultcomTecnicasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ResultcomTecnicasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TBL_com_ResultcomTecnicasModels>> ListResultcomTecnicasModelsByEvaluacionId(long EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ResultcomTecnicas
            .Where(x => x.EvaluacionId == EvaluacionId)
            .ToListAsync();
            return _mapper.Map<List<TBL_com_ResultcomTecnicasModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListResultcomTecnicasModelsByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }

    public async Task<TBL_com_ResultcomTecnicasModels> CreateResultcomTecnicas(TBL_com_ResultcomTecnicasModels objCreate, int EmpresaId)
    {
        var objResultEscala = _mapper.Map<Tbl_com_EscalaEvaluacionModels>(_context.TBL_com_EscalaEvaluacion
            .FirstOrDefault(x => x.AspectovaloracionId == 3 && x.EmpresaId == EmpresaId && x.Escala == -2));
        objCreate.EscalaId = objResultEscala.EscalaId;
        objCreate.ResEscala = objResultEscala.Escala;
        objCreate.Color = objResultEscala.Color;
        objCreate.EscalaNivel = objResultEscala.Nivel;
        objCreate.FechaEva = DateTime.Now;
        objCreate.Observacion = objCreate.Observacion == "" ? "." : objCreate.Observacion;
        try
        {
            _context.TBL_com_ResultcomTecnicas.Add(_mapper.Map<tbl_com_ResultcomTecnicasEntities>(objCreate));
            await _context.SaveChangesAsync();
            var ObjResult = await _context.TBL_com_ResultcomTecnicas.OrderByDescending(e => e.ResultadoId).FirstOrDefaultAsync();
            return _mapper.Map<TBL_com_ResultcomTecnicasModels>(ObjResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CreateResultcomTecnicas", ex, JsonConvert.SerializeObject(objCreate));
            throw;
        }
    }


    public async Task<TBL_com_ResultcomTecnicasModels> UpdateResultcomTecnicas(TBL_com_ResultcomTecnicasModels ObjUpdate)
    {
        var updateRegistro = _context.TBL_com_ResultcomTecnicas.FirstOrDefault(p => p.ResultadoId == ObjUpdate.ResultadoId);
        try
        {
            #region Update
            if (updateRegistro != null)
            {
                updateRegistro.EvaluacionId = ObjUpdate.EvaluacionId;
                updateRegistro.Descripcion = ObjUpdate.Descripcion;
                updateRegistro.Observacion = ObjUpdate.Observacion;
                updateRegistro.EscalaNivel = ObjUpdate.EscalaNivel;
                updateRegistro.FechaEva = DateTime.Now;
                updateRegistro.EscalaId = ObjUpdate.EscalaId;
                updateRegistro.ResEscala = ObjUpdate.ResEscala;
                updateRegistro.BEstado = ObjUpdate.BEstado;
                updateRegistro.BCerrado = ObjUpdate.BCerrado;
                updateRegistro.Color = ObjUpdate.Color;
            }
            #endregion
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateResultcomTecnicas", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<TBL_com_ResultcomTecnicasModels>(updateRegistro);
    }

    public async Task<string> DeleteResultcomTecnicas(long ResultadoId)
    {
        try
        {

            var objDelete = await _context.TBL_com_ResultcomTecnicas.FirstOrDefaultAsync(x => x.ResultadoId == ResultadoId);
            _context.TBL_com_ResultcomTecnicas.Remove(objDelete);
            await _context.SaveChangesAsync();
            return "Registro Eliminado";
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("DeleteResultcomTecnicas", ex, ResultadoId.ToString());
            throw;
        }
    }

}
