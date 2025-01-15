using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class CargosProcesosService : ICargosProcesosService
    {
        private readonly ICargosProcesosRepository _cargosProcesosRepository;


        public CargosProcesosService(ICargosProcesosRepository cargosProcesosRepository)
        {
            _cargosProcesosRepository = cargosProcesosRepository;
        }

        public async Task<List<SCP_CargosProcesosModels>> GetCargoAutorizadosByProcesoIdCargoId(int IdProceso, int id_cargo, int EmpresaId)
        {
            return await _cargosProcesosRepository.GetCargoAutorizadosByProcesoIdCargoId(IdProceso, id_cargo, EmpresaId);
        }
    }
}
