
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface IAgentesRepository
    {
        Task<List<Tbl_rgp_AgentesModels>> GetListaAgentes();
        Task<List<Tbl_rgp_AgentesModels>> GetListaAgentesByEmpresaByEstado(int EmpresaId, bool Estado);

    }
}
