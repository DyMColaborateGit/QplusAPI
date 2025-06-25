using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class PreguntasBrechaPRepository : IPreguntasBrechaPRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public PreguntasBrechaPRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaP(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_PreguntasBrechaP.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_PreguntasBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaPreguntasBrechaP", ex, EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaPByTemaId(int TemaBrechaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_PreguntasBrechaP.AsNoTracking()
                    .Where(x => x.TemaBrechaId == TemaBrechaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_PreguntasBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaPreguntasBrechaPByTemaId", ex, TemaBrechaId.ToString());
                throw;
            }
        }
    }
}
