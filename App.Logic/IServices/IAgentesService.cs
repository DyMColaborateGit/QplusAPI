
using App.Models.Models.TblRgp;

namespace App.logic.IServices
{
    public interface IAgentesService
    {
        Task<List<Tbl_rgp_AgentesModels>> GetListaAgentes();
        Task<List<Tbl_rgp_AgentesModels>> GetListaAgentesByEmpresaByEstado(int EmpresaId, bool Estado);

    }
}
