using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories;

public interface IParametrosEmpresasRepository
{
    Task<SCP_ParametrosEmpresasModels> ObjGetParametroEmpresaByParametroId(int EmpresaId, int ParametroId);
    Task<List<SCP_ParametrosEmpresasModels>> ListParametrosGenerales(int EmpresaId);
}
