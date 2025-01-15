using App.Models.Models.Scp;
using System;


namespace App.Infraestructure.IRepositories;

public interface IFuncionariosRepository
{
    Task<SCP_FuncionariosModels> ObjFuncionarioByIdentificacion(long Identificacion);

    Task<SCP_FuncionariosModels> ObjFuncionarioByEmpresaIdByIdentificacion(int EmpresaId, long Identificacion);

    Task<JOINSCP_FuncionariosModels> ObjJoinFuncionarioByEmpresaIdByIdentificacion(int EmpresaId, long Identificacion);

    Task<List<SCP_FuncionariosModels>> ListFuncionarioByEmpresaIdByCargoId(int EmpresaId, int CargoId, bool Estado);
}
