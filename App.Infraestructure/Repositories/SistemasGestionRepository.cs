using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblMast;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class SistemasGestionRepository : ISistemasGestionRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public SistemasGestionRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TBL_mast_SistemasGestionModels>> GetListaSistemasGestionByEmpresaId(int EmpresaId)
        {
            try
            {
                var query = _context.TBL_mast_SistemasGestion.AsNoTracking()
                    .Where(x => x.InEstado == 1 && x.Principal != 100);


                if (EmpresaId != -1)
                {
                    query = query.Where(p => p.EmpresaId == EmpresaId);
                }

                var orderedQuery = query.OrderBy(x => x.VcSistema);

                var objResult = await orderedQuery.ToListAsync();

                return _mapper.Map<List<TBL_mast_SistemasGestionModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaSistemasGestionByEmpresaId", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
