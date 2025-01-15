using App.Models.Models.Scp;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEmpresasRepository
{
    Task<List<SCP_EmpresasModels>> ListEmpresa();

    Task<SCP_EmpresasModels> ObjEmpresa(int EmpresaId);
}
