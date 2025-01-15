using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblMast;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class ZonasRepository: IZonasRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ZonasRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TBL_mast_ZonasModels> ObjZonas(int CodigoZo, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_mast_Zonas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CodigoZO == CodigoZo && x.EmpresaId == EmpresaId);
                return _mapper.Map<TBL_mast_ZonasModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjZonas", ex, CodigoZo.ToString() + "/" + EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<TBL_mast_ZonasModels>> ListZonas(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_mast_Zonas.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Estado == true)
                    .OrderBy(x => x.Zona)
                    .ToListAsync();
                return _mapper.Map<List<TBL_mast_ZonasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListZonas", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
