using App.Models.Models.TblAud;
using App.Models.Models.TblMast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories; 
public interface IAuditoriasRepository
{
    Task<List<AuditoriasModels>> ListAuditorias(int IdAuditoria);
    Task<AuditoriasModels> CrearAuditorias(AuditoriasModels ObjCreate, int InIdEmpresa);
    Task<string> DeleteAuditorias(int IdAuditoria);
}
