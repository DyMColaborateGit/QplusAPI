
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class ControlesRepository : IControlesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ControlesRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ControlesModels>> GetListaControlesRiesgos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Controles.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ControlesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaControlesRiesgos", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
