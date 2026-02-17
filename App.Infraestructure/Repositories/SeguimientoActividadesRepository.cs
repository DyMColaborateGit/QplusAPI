using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class SeguimientoActividadesRepository : ISeguimientoActividadesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public SeguimientoActividadesRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TBL_com_SeguimientoActividadesModels>> GetListaSeguimientoActividades(int InIdActividadPIM)
        {
            try
            {
                var objResult = await _context.TBL_com_SeguimientoActividades.AsNoTracking()
                    .Where(x => x.InIdActividadPIM == InIdActividadPIM)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_SeguimientoActividadesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaSeguimientoActividades", ex, InIdActividadPIM.ToString());
                throw;
            }
        }
    }
}
