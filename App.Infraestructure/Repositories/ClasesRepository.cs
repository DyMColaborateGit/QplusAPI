
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class ClasesRepository : IClasesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ClasesRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_rgp_ClasesModels>> GetListaClases()
        {
            try
            {
                var objResult = await _context.TBL_rgp_Clases.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ClasesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaClases", ex, "");
                throw;
            }
        }
        public async Task<List<Tbl_rgp_ClasesModels>> GetListaClasesByEmpresaByEstado(int EmpresaId, bool Estado)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Clases.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Estado == Estado)
                    .OrderBy(x => x.Clase)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ClasesModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaClasesByEmpresaByEstado", ex, EmpresaId + "/" + Estado);
                throw;
            }
        }
    }
}
