using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class RelFuncSolicitudPRepository : IRelFuncSolicitudPRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RelFuncSolicitudPRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RelFuncSolicitudP.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_RelFuncSolicitudPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRelFuncSolicitudP", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
