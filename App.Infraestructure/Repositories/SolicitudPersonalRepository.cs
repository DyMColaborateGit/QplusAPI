using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class SolicitudPersonalRepository : ISolicitudPersonalRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public SolicitudPersonalRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Tbl_ghu_SolicitudPersonalModels> GetObjSolicitudPersonalById(int SolicitudId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_SolicitudPersonal.AsNoTracking()
                    .Where(x => x.SolicitudId == SolicitudId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<Tbl_ghu_SolicitudPersonalModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjSolicitudPersonalById", ex, SolicitudId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_SolicitudPersonal.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_SolicitudPersonalModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaSolicitudesPersonal", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
