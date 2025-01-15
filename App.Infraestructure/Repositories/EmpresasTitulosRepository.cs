using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class EmpresasTitulosRepository: IEmpresasTitulosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public EmpresasTitulosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SCP_EmpresasTitulosModels>> ListEmpresasTitulos()
        {
            try
            {
                var objResult = await _context.SCP_EmpresasTitulos.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<SCP_EmpresasTitulosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListEmpresasTitulos", ex, "");
                throw;
            }
        }


        public async Task<SCP_EmpresasTitulosModels> ObjEmpresasTitulos(int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_EmpresasTitulos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<SCP_EmpresasTitulosModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjEmpresasTitulos", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
