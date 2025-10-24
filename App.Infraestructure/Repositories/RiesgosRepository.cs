
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models;
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

        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaRiesgos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Riesgos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRiesgos", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_rgp_RiesgosModels>> GetListaCodigoRiesgoByProcesoId(int ProcesoId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Riesgos.AsNoTracking()
                .Where(x => x.ProcesoId == ProcesoId)
                .OrderBy(x => x.Codigo)
                .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_RiesgosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaCodigoRiesgoByProcesoId", ex, ProcesoId.ToString());
                throw;
            }
        }
    }
}
