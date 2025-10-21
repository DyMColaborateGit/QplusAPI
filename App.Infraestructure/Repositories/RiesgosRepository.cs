
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class RiesgosRepository : IRiesgosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RiesgosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos()
        {
            try
            {
                var objResult = await _context.TBL_rgp_Riesgos.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRiesgos", ex, "");
                throw;
            }
        }
    }
}
