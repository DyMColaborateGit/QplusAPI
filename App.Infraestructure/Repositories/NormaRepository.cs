using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class NormaRepository: INormaRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public NormaRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tbl_com_NormasModels>> ListNormasByEstado(int EmpresaId, bool Estado)
        {
            try
            {
                var objResult = await _context.TBL_com_Normas.AsNoTracking()
                    .Where(x => x.BEstado == Estado && x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_com_NormasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListNormasByEstado", ex, EmpresaId + "/" + Estado);
                throw;
            }
        }
    }
}
