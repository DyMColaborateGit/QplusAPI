using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class MatrizdeTalentoRepository: IMatrizdeTalentoRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public MatrizdeTalentoRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TBL_com_MatrizdeTalentosModels> CategoriaMatrizdeTalentos(decimal ValorComp, decimal ValorInd, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_MatrizdeTalentos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId
                              && ValorComp >= x.PorcMinC
                              && ValorComp <= x.PorcMaxC
                              && ValorInd >= x.PorcMinI
                              && ValorInd <= x.PorcMaxI)
                    .FirstOrDefaultAsync();
                return _mapper.Map<TBL_com_MatrizdeTalentosModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("CategoriaMatrizdeTalentos", ex, ValorComp +"/"+ ValorInd + "/" + EmpresaId);
                throw;
            }
        }

        public async Task<List<ResponseTBL_com_MatrizdeTalentosModels>> ListMatrizdeTalentos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_MatrizdeTalentos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<ResponseTBL_com_MatrizdeTalentosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListMatrizdeTalentos", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
