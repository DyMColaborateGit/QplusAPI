
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class AgentesRepository : IAgentesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public AgentesRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_AgentesModels>> GetListaAgentes()
        {
            try
            {
                var objResult = await _context.TBL_rgp_Agentes.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_AgentesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaAgentes", ex, "");
                throw;
            }
        }
        public async Task<List<Tbl_rgp_AgentesModels>> GetListaAgentesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Agentes.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Estado == Estado)
                    .OrderBy(x => x.Agente)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_AgentesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaAgentesByEmpresaByEstado", ex, EmpresaId + "/" + Estado);
                throw;
            }
        }
    }
}
