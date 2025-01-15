using App.Models.Models.Scp;

namespace App.logic.IServices;

public interface IParametrosEmpresasService
{
    Task<SCP_ParametrosEmpresasModels> GetParametroEmpresaByParametroId(int EmpresaId, int ParametroId);

    Task<List<SCP_ParametrosEmpresasModels>> GetListParametrosGenerales(int EmpresaId);
}
