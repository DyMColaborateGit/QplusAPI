using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface ICargosProcesosService
    {
        Task<List<SCP_CargosProcesosModels>> GetCargoAutorizadosByProcesoIdCargoId(int IdProceso, int id_cargo, int EmpresaId);
    }
}
