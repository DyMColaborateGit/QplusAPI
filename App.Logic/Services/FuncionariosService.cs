using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;

namespace App.logic.Services;

public class FuncionariosService: IFuncionariosService
{
    private readonly IFuncionariosRepository _funcionariosRepository;

    public FuncionariosService(IFuncionariosRepository funcionariosRepository)
    {
        _funcionariosRepository = funcionariosRepository;
    }

    public async Task<SCP_FuncionariosModels> GetObjFuncionarioByIdentificacion(int EmpresaId, long Identificacion)
    {
        return await _funcionariosRepository.ObjFuncionarioByEmpresaIdByIdentificacion(EmpresaId, Identificacion);
    }

    public async Task<JOINSCP_FuncionariosModels> GetJoinFuncionarioByIdentificacion(int EmpresaId, long Identificacion)
    {
        return await _funcionariosRepository.ObjJoinFuncionarioByEmpresaIdByIdentificacion(EmpresaId, Identificacion);
    }
}
