using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models;
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
    public async Task<SCP_FuncionariosModels> GetObjFuncionarioByIdentificacion(long Identificacion)
    {
        return await _funcionariosRepository.GetObjFuncionarioByIdentificacion(Identificacion);
    }
    public async Task<SCP_FuncionariosModels> GetObjFuncionarioByIdentificacion(int EmpresaId, long Identificacion)
    {
        return await _funcionariosRepository.ObjFuncionarioByEmpresaIdByIdentificacion(EmpresaId, Identificacion);
    }
    public async Task<List<SCP_FuncionariosModels>> GetListfuncionariosByEmpresaId(int EmpresaId)
    {
        return await _funcionariosRepository.GetListfuncionariosByEmpresaId(EmpresaId);
    }

    public async Task<JOINSCP_FuncionariosModels> GetJoinFuncionarioByIdentificacion(int EmpresaId, long Identificacion)
    {
        return await _funcionariosRepository.ObjJoinFuncionarioByEmpresaIdByIdentificacion(EmpresaId, Identificacion);
    }
}
