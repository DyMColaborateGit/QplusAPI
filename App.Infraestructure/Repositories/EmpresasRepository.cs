using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class EmpresasRepository: IEmpresasRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public EmpresasRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SCP_EmpresasModels>> ListEmpresa()
        {
            try
            {
                var objResult = await _context.SCP_Empresas.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<SCP_EmpresasModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListEmpresa", ex, "");
                throw;
            }
        }

        public async Task<SCP_EmpresasModels> ObjEmpresa(int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_Empresas.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<SCP_EmpresasModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjEmpresa", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
