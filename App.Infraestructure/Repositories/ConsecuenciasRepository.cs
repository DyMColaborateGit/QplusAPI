
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class ConsecuenciasRepository : IConsecuenciasRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ConsecuenciasRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias()
        {
            try
            {
                var objResult = await _context.TBL_rgp_Consecuencias.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ConsecuenciasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaConsecuencias", ex, "");
                throw;
            }
        }
    }
}
