
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class ParametrosValoracionRepository : IParametrosValoracionRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ParametrosValoracionRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_ParametrosValoracion.AsNoTracking()
                    .Include(x => x.ZonaObj)
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ParametrosValoracionModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaParametrosValoracion", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaColoresZonas(int IdZona)
        {
            try
            {
                var objResult = await _context.TBL_rgp_ParametrosValoracion
                    .AsNoTracking()
                    .Include(x => x.ZonaObj)
                    .Where(x => x.ZonaObj.IdZona == IdZona)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ParametrosValoracionModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaColoresZonas", ex, IdZona.ToString());
                throw;
            }
        }
    }
}
