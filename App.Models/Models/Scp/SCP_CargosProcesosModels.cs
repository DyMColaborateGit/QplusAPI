using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.Scp
{
    public class SCP_CargosProcesosModels
    {
        public int? IdCargoAsoc { get; set; }
        public int EmpresaId { get; set; }
        public int? id_cargo { get; set; }
        public int? IdProceso { get; set; }
        public string? TipoCargo { get; set; }
    }
}
