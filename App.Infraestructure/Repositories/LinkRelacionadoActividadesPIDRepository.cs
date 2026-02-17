using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories 
{
    public class LinkRelacionadoActividadesPIDRepository : ILinkRelacionadoActividadesPIDRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public LinkRelacionadoActividadesPIDRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<LinkRelacionadoActividadesPIDModels>> GetListaLinkRelacionadoActividadesPID(int EmpresaId, int InIdActividadPID)
        {
            try
            {
                var objResult = await _context.LinkRelacionadoActividadesPID.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.InIdActividadPID == InIdActividadPID)
                    .ToListAsync();
                return _mapper.Map<List<LinkRelacionadoActividadesPIDModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaLinkRelacionadoActividadesPID", ex, EmpresaId.ToString() + "/" + InIdActividadPID.ToString());
                throw;
            }
        }
    }
}
