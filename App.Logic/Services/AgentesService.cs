using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class AgentesService : IAgentesService
    {
        private readonly IAgentesRepository _agentesRepository;

        public AgentesService(IAgentesRepository agentesRepository)
        {
            _agentesRepository = agentesRepository;
        }

        public async Task<List<Tbl_rgp_AgentesModels>> GetListaAgentes()
        {
            return await _agentesRepository.GetListaAgentes();
        }
        public async Task<List<Tbl_rgp_AgentesModels>> GetListaAgentesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            return await _agentesRepository.GetListaAgentesByEmpresaByEstado(EmpresaId, Estado);
        }
    }
}
