using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface ICargosProcesosRepository
    {
        Task<List<SCP_CargosProcesosModels>> GetCargoAutorizadosByProcesoIdCargoId(int IdProceso, int id_cargo, int EmpresaId);

    }
}
