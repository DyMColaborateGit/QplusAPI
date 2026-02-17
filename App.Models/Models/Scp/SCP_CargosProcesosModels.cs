using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.Scp
{
    public class SCP_CargosProcesosModels
    {
        public int? IdCargoAsoc { get; set; }
        public int EmpresaId { get; set; }
        public int? Id_cargo { get; set; }
        [ForeignKey(nameof(Id_proceso))]
        public int? Id_proceso { get; set; }
        public SCP_ProcesosModels? ProcesosObj { get; set; }
        public string? TipoCargo { get; set; }
    }
}
