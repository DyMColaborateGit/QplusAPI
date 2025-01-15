using App.Models.Models.Scp;
using System;

namespace App.logic.IServices
{
    public interface IEmpresasService
    {
        Task<List<SCP_EmpresasModels>> GetListEmpresa();

        Task<SCP_EmpresasModels> GetEmpresaByempresaId(int EmpresaId);
    }
}
