using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services;

public class AuditoriasService : IAuditoriasService
{

    private readonly IAuditoriasRepository _auditoriasRepository;

    public AuditoriasService(IAuditoriasRepository auditoriasRepository)
    {
        _auditoriasRepository = auditoriasRepository;
    }

    public async Task<List<AuditoriasModels>> GetListAuditorias(int IdAuditoria)
    {
        var ListResult = await _auditoriasRepository.ListAuditorias(IdAuditoria);
        return ListResult;
    }

    public async Task<AuditoriasModels> PostCrearAuditorias(AuditoriasModels ObjCreate, int InIdEmpresa)
    {
        var ListResult = await _auditoriasRepository.CrearAuditorias(ObjCreate, InIdEmpresa);
        return ListResult;
    }

    public async Task<string> DeleteAuditorias(AuditoriasModels ObjModificar)
    {
        var ListResult = await _auditoriasRepository.DeleteAuditorias(ObjModificar.IdAuditoria);
        return ListResult;
    }
}
