using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories
{
    public class TextosBrechaRepository : ITextosBrechaRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public TextosBrechaRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_ghu_TextosBrechaModels>> GetListaTextosBrecha(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_TextosBrecha.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_TextosBrechaModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaTextosBrecha", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
