using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;

namespace App.logic.Services;

public class ParametrosEmpresasService : IParametrosEmpresasService
{
    private readonly IParametrosEmpresasRepository _parametrosEmpresasRepository;


    public ParametrosEmpresasService(IParametrosEmpresasRepository parametrosEmpresasRepository)
    {
        _parametrosEmpresasRepository = parametrosEmpresasRepository;
    }

    public async Task<SCP_ParametrosEmpresasModels> GetParametroEmpresaByParametroId(int EmpresaId, int ParametroId)
    {
        return await _parametrosEmpresasRepository.ObjGetParametroEmpresaByParametroId(EmpresaId, ParametroId);
    }

    public async Task<List<SCP_ParametrosEmpresasModels>> GetListParametrosGenerales(int EmpresaId)
    {
        return await _parametrosEmpresasRepository.ListParametrosGenerales(EmpresaId);
    }
}
