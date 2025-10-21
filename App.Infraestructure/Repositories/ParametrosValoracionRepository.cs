
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

        public async Task<List<Tbl_rgp_ParametrosValoracionModels>> GetListaParametrosValoracion()
        {
            try
            {
                var objResult = await _context.TBL_rgp_ParametrosValoracion.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ParametrosValoracionModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaParametrosValoracion", ex, "");
                throw;
            }
        }
    }
}
