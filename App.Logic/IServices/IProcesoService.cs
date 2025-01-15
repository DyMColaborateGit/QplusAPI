using App.Models.Models.Scp;
using System;

namespace App.logic.IServices
{
    public interface IProcesoService
    {
        Task<List<SCP_ProcesosModels>> GetListProcesosByEmpresaId(int EmpresaId, string Estado);
        Task<List<SCP_ProcesosModels>> GetListaProcesosEstadoByEmpresaIdByMacroproId(int EmpresaId, int Id_Area, string Estado);
    }
}
