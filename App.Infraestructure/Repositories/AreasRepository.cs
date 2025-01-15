using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.T;
using App.Models.Models.TblDoc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class AreasRepository : IAreasRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public AreasRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AreasModels>> GetListMacroProcesos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.Areas.AsNoTracking()
                .Where(x => x.Estado == 1 && x.EmpresaId == EmpresaId)
                .ToListAsync();

                return _mapper.Map<List<AreasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListMacroProcesos", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
