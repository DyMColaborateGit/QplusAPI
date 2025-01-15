using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblMast;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class CargosRepository : ICargosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public CargosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SCP_CargosModels>> GetListaCargos()
        {
            try
            {
                var objResult = await _context.SCP_Cargos.AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<SCP_CargosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaCargos", ex, "");
                throw;
            }
        }

        public async Task<SCP_CargosModels> objCargoIdCargo(int CargoId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_Cargos.AsNoTracking()
                    .Where(x => x.Codigo == CargoId && x.EmpresaId == EmpresaId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<SCP_CargosModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("objCargoIdCargo", ex, CargoId.ToString() + "/" + EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<SCP_CargosModels>> ListaCargosDocElaborado(int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_Cargos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .OrderBy(x => x.VcNombre)
                    .ToListAsync();
                return _mapper.Map<List<SCP_CargosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListaCargosDocElaborado", ex, EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<SCP_CargosModels>> ListaCargosDocRevisado(int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_Cargos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .OrderBy(x => x.VcNombre)
                    .ToListAsync();
                return _mapper.Map<List<SCP_CargosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListaCargosDocRevisado", ex, EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<SCP_CargosModels>> ListaCargosDocAprobado(int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_Cargos.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .OrderBy(x => x.VcNombre)
                    .ToListAsync();
                return _mapper.Map<List<SCP_CargosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListaCargosDocAprobado", ex, EmpresaId.ToString());
                throw;
            }
        }
    }
}
