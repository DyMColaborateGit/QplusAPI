using App.Models.Models.Scp;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface IProcesoRepository
    {
        Task<List<SCP_ProcesosModels>> ListProcesosByempresaIdByEstado(int EmpresaId, string Estado);
        Task<List<SCP_ProcesosModels>> GetListaProcesosEstadoByEmpresaIdByMacroproId(int EmpresaId, int Id_Area, string Estado);
    }
}
