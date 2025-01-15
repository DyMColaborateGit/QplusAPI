using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class NivelesCargoCompRepository: INivelesCargoCompRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public NivelesCargoCompRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JOINTBL_com_NivelesCargoCompModels>> ListNivelesCargoCompByCargoId(int EmpresaId, int CargoId)
        {
            try
            {
                var objResult = await _context.TBL_com_NivelesCargoComp.AsNoTracking()
                    .Include(x => x.Normaobj)
                    .Where(x => x.CodigoCargo == CargoId && x.EmpresaId == EmpresaId && x.Normaobj.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<JOINTBL_com_NivelesCargoCompModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListNivelesCargoCompByCargoId", ex, EmpresaId + "/" + CargoId);
                throw;
            }
        }

    }
}
