using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace App.Infraestructure.Repositories
{
    public class TipoAnalisisRepository : ITipoAnalisisRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public TipoAnalisisRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Tbl_rgp_TipoAnalisisModels>> GetListaTipoAnalisis(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_TipoAnalisis.AsNoTracking()
                .Where(x => x.EmpresaId == EmpresaId)
                .OrderBy(x => x.TipoAnalisis)
                .ToListAsync();

                return _mapper.Map<List<Tbl_rgp_TipoAnalisisModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaTipoAnalisis", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
