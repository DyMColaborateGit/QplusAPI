using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories;

public class AuditoriasRepository : IAuditoriasRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;


    public AuditoriasRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AuditoriasModels>> ListAuditorias(int IdAuditoria)
    {
        try
        {

            var auditorias = await _context.Auditorias
                .Where(a => a.IdAuditoria == IdAuditoria)
                .ToListAsync();
            return _mapper.Map<List<AuditoriasModels>>(auditorias);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListAuditorias", ex, IdAuditoria.ToString());
            throw;
        }


    }

    public async Task<AuditoriasModels> CrearAuditorias(AuditoriasModels ObjCreate, int InIdEmpresa)
    {
        var objResultAuditorias = await _context.Auditorias.FirstOrDefaultAsync(x => x.InIdEmpresa == InIdEmpresa);
        ObjCreate.IdAuditoria = objResultAuditorias.IdAuditoria;
        ObjCreate.ZonaId = objResultAuditorias.ZonaId;
        ObjCreate.OficinaId = objResultAuditorias.OficinaId;
        ObjCreate.Consecutivo = objResultAuditorias.Consecutivo;
        ObjCreate.CodigoAuditoria = objResultAuditorias.CodigoAuditoria;
        ObjCreate.Proceso = objResultAuditorias.Proceso;
        ObjCreate.Auditor1 = objResultAuditorias.Auditor1;
        ObjCreate.Auditor2 = objResultAuditorias.Auditor2;
        ObjCreate.FechaProg = DateTime.Now;
        ObjCreate.FechaReal = DateTime.Now;
        ObjCreate.FechaProgInforme = DateTime.Now;
        ObjCreate.FechaInfoDefinitivo = DateTime.Now;
        ObjCreate.FechaProgCierre = DateTime.Now;
        ObjCreate.FechaRealCierre = DateTime.Now;
        ObjCreate.FechaProgEvaluacion = DateTime.Now;
        ObjCreate.FechaRealEvaluacion = DateTime.Now;
        ObjCreate.Mes = objResultAuditorias.Mes;
        ObjCreate.Anio = objResultAuditorias.Anio;
        ObjCreate.Estado = objResultAuditorias.Estado;
        ObjCreate.Requisitos = objResultAuditorias.Requisitos;
        ObjCreate.Hora = objResultAuditorias.Hora;
        ObjCreate.Auditados = objResultAuditorias.Auditados;
        ObjCreate.FlIndicadorInforme = objResultAuditorias.FlIndicadorInforme;
        ObjCreate.InDiasRetInforme = objResultAuditorias.InDiasRetInforme;
        ObjCreate.FlIndicadorCierre = objResultAuditorias.FlIndicadorCierre;
        ObjCreate.InDiasRetCierre = objResultAuditorias.InDiasRetCierre;
        ObjCreate.FlIndicadorEvaluacion = objResultAuditorias.FlIndicadorEvaluacion;
        ObjCreate.InDiasRetEvaluacion = objResultAuditorias.InDiasRetEvaluacion;
        ObjCreate.InIdSistema = objResultAuditorias.InIdSistema;
        ObjCreate.AprobadorId = objResultAuditorias.AprobadorId;
        ObjCreate.OtrosAuditores = objResultAuditorias.OtrosAuditores;
        ObjCreate.Identiauditor1 = objResultAuditorias.Identiauditor1;
        ObjCreate.Identiauditor2 = objResultAuditorias.Identiauditor2;
        try
        {
            _context.Auditorias.Add(_mapper.Map<auditoriasEntities>(ObjCreate));
            await _context.SaveChangesAsync();
            var ObjResultAud = await _context.Auditorias.OrderByDescending(e => e.InIdEmpresa).FirstOrDefaultAsync();
            return _mapper.Map<AuditoriasModels>(ObjResultAud);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CrearAuditorias", ex, JsonConvert.SerializeObject(ObjCreate));
            throw;
        }
    }

    public async Task<string> DeleteAuditorias(int IdAuditoria)
    {

        try
        {

            var objDelete = await _context.Auditorias.FirstOrDefaultAsync(x => x.IdAuditoria == IdAuditoria);
            _context.Auditorias.Remove(objDelete);
            await _context.SaveChangesAsync();
            return "Registro Eliminado";
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("DeleteAuditorias", ex, IdAuditoria.ToString());
            throw;
        }
    }

}
