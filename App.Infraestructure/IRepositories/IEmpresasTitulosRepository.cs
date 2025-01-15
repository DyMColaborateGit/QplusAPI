using App.Models.Models.Scp;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEmpresasTitulosRepository
{
    Task<List<SCP_EmpresasTitulosModels>> ListEmpresasTitulos();

    Task<SCP_EmpresasTitulosModels> ObjEmpresasTitulos(int EmpresaId);
}
