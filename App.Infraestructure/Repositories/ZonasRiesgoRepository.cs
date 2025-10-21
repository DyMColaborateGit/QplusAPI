using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace App.Infraestructure.Repositories
{
    public class ZonasRiesgoRepository : IZonasRiesgoRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ZonasRiesgoRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ZonasModels>> GetListaZonasRiesgo()
        {
            try
            {
                var objResult = await _context.TBL_rgp_Zonas.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ZonasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaZonasRiesgo", ex, "");
                throw;
            }
        }
    }
}
