
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class EvaluacionRiesgoRepository : IEvaluacionRiesgoRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public EvaluacionRiesgoRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_EvaluacionRiesgoModels>> GetListaEvaluacionRiesgo()
        {
            try
            {
                var objResult = await _context.TBL_rgp_EvaluacionRiesgo.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_EvaluacionRiesgoModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaEvaluacionRiesgo", ex, "");
                throw;
            }
        }
    }
}
