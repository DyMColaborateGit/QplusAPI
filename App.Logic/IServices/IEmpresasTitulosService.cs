using App.Models.Models.Scp;
using System;

namespace App.logic.IServices;

public interface IEmpresasTitulosService
{
    Task<List<SCP_EmpresasTitulosModels>> GetListEmpresasTitulos();

    Task<SCP_EmpresasTitulosModels> GetEmpresasTitulosByempresaId(int EmpresaId);
}
