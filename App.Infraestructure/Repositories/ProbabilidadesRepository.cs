using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class ProbabilidadesRepository : IProbabilidadesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ProbabilidadesRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ProbabilidadesModels>> GetListaProbabilidades(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Probabilidades.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .OrderByDescending(x => x.Varlor)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ProbabilidadesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaProbabilidades", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
