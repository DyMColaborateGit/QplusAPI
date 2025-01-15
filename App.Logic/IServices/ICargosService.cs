using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface ICargosService
    {
        Task<List<SCP_CargosModels>> GetListaCargos();
        Task<SCP_CargosModels> GetCargoIdCargo(int CargoId, int EmpresaId);
        Task<List<SCP_CargosModels>> ListaCargosDocElaborado(int EmpresaId);
        Task<List<SCP_CargosModels>> ListaCargosDocRevisado(int EmpresaId);
        Task<List<SCP_CargosModels>> ListaCargosDocAprobado(int EmpresaId);
    }
}
