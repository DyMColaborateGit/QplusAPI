using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class RespuestaMultiplesBrechaPRepository : IRespuestaMultiplesBrechaPRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RespuestaMultiplesBrechaPRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasMultiplesBrechaP(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RespuestasMultiplesBrechaP.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRespuestasMultiplesBrechaP", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>> GetListaRespuestasBrechaPByPreguntaId(int PreguntaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RespuestasMultiplesBrechaP.AsNoTracking()
                    .Where(x => x.PreguntaId == PreguntaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_RespuestasMultiplesBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRespuestasBrechaPByPreguntaId", ex, PreguntaId.ToString());
                throw;
            }
        }
    }
}
