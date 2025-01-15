using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;

namespace App.logic.Services
{
    public class ProcesoService : IProcesoService
    {
        private readonly IProcesoRepository _procesoRepository;

        public ProcesoService(IProcesoRepository procesoRepository)
        {
            _procesoRepository = procesoRepository;
        }

        public async Task<List<SCP_ProcesosModels>> GetListProcesosByEmpresaId(int EmpresaId, string Estado)
        {
            return await _procesoRepository.ListProcesosByempresaIdByEstado(EmpresaId, Estado);
        }

        public async Task<List<SCP_ProcesosModels>> GetListaProcesosEstadoByEmpresaIdByMacroproId(int EmpresaId, int Id_Area, string Estado)
        {
            return await _procesoRepository.GetListaProcesosEstadoByEmpresaIdByMacroproId(EmpresaId, Id_Area, Estado);
        }
    }
}
