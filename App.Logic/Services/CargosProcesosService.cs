using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
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
        public async Task<List<SCP_CargosProcesosModels>> GetCargoAutorizadosByProcesoIdCargoId(int Id_proceso, int Id_cargo, int EmpresaId)
        {
            return await _cargosProcesosRepository.GetCargoAutorizadosByProcesoIdCargoId(Id_proceso, Id_cargo, EmpresaId);
        }
        public async Task<SCP_CargosProcesosModels> GetProcesoPerteneceByIdCargo(int Id_cargo, int EmpresaId)
        {
            return await _cargosProcesosRepository.GetProcesoPerteneceByIdCargo(Id_cargo, EmpresaId);
        }
    }
}
