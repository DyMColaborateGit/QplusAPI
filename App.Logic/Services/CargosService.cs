using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.TblDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class CargosService : ICargosService
    {
        private readonly ICargosRepository _cargosRepository;


        public CargosService(ICargosRepository cargosRepository)
        {
            _cargosRepository = cargosRepository;
        }

        public async Task<List<SCP_CargosModels>> GetListaCargos()
        {
            return await _cargosRepository.GetListaCargos();
        }

        public async Task<SCP_CargosModels> GetCargoIdCargo(int CargoId, int EmpresaId)
        {
            return await _cargosRepository.objCargoIdCargo(CargoId, EmpresaId);

        }
        public async Task<List<SCP_CargosModels>> ListaCargosDocElaborado(int EmpresaId)
        {
            return await _cargosRepository.ListaCargosDocElaborado(EmpresaId);
        }

        public async Task<List<SCP_CargosModels>> ListaCargosDocRevisado(int EmpresaId)
        {
            return await _cargosRepository.ListaCargosDocRevisado(EmpresaId);
        }

        public async Task<List<SCP_CargosModels>> ListaCargosDocAprobado(int EmpresaId)
        {
            return await _cargosRepository.ListaCargosDocAprobado(EmpresaId);
        }
    }
}
