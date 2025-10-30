
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

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

        public async Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Consecuencias.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_rgp_ConsecuenciasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaConsecuencias", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<Tbl_rgp_ConsecuenciasModels> GetObjConsecuenciaByEmpresaIdByValor(int EmpresaId, int Valor)
        {
            try
            {
                var objResult = await _context.TBL_rgp_Consecuencias.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.Valor == Valor)
                    .FirstOrDefaultAsync();
                return _mapper.Map<Tbl_rgp_ConsecuenciasModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjConsecuenciaByEmpresaIdByValor", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
