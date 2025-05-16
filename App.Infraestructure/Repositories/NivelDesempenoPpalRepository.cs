using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class NivelDesempenoPpalRepository : INivelDesempenoPpalRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public NivelDesempenoPpalRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TBL_com_NivelesDesempenoPpalModels> GetObjNivelDesempenoPpal(int EmpresaId, string Nivel)
        {
            try
            {
                var objResult = await _context.TBL_Com_NivelesDesempenoPpal.AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmpresaId == EmpresaId && x.Nivel == Nivel);
                return _mapper.Map<TBL_com_NivelesDesempenoPpalModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjNivelDesempenoPpal", ex, EmpresaId.ToString() + "/" + Nivel);
                throw;
            }
        }
        public async Task<List<TBL_com_NivelesDesempenoPpalModels>>ListNivelDesempenoPpal(int EmpresaId, int InAnio)
        {
            try
            {
                var objResult = await _context.TBL_Com_NivelesDesempenoPpal.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.InAnio == InAnio)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_NivelesDesempenoPpalModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListNivelDesempenoPpal", ex, EmpresaId.ToString() + "/" + InAnio);
                throw;
            }
        }
    }
}
