using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Repositories
{
    public class CargosProcesosRepository : ICargosProcesosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public CargosProcesosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SCP_CargosProcesosModels>> GetCargoAutorizadosByProcesoIdCargoId(int IdProceso, int id_cargo, int EmpresaId)
        {
            try
            {
                var objResult = await _context.SCP_CargosProcesos.AsNoTracking()
                    .Where(x => x.TipoCargo != "A" && x.IdProceso == IdProceso && x.CargosObj.Codigo == id_cargo && x.EmpresaId == EmpresaId)
                    .Include(x => x.CargosObj)
                    .FirstOrDefaultAsync();
                return _mapper.Map <List<SCP_CargosProcesosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetCargoAutorizadosByProcesoIdCargoId", ex, IdProceso.ToString() + "/" + id_cargo.ToString() + "/" + EmpresaId.ToString());
                throw;
            }
        }
    }
}
