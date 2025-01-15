using App.Models.Models.TblAud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface IAuditoriasService
{
    Task<List<AuditoriasModels>> GetListAuditorias(int IdAuditoria);
    Task<AuditoriasModels> PostCrearAuditorias(AuditoriasModels ObjCreate, int InIdEmpresa);
    Task<string> DeleteAuditorias(AuditoriasModels ObjModificar);

}
