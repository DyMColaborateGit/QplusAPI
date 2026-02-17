using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Entities.Scp
{
    public class scp_CargosProcesosEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int? IdCargoAsoc { get; set; }
        public int EmpresaId { get; set; }

        [ForeignKey(nameof(Id_cargo))]
        public int? Id_cargo { get; set; }
        public scp_CargosEntities? CargosObj { get; set; }

        [ForeignKey(nameof(Id_proceso))]
        public int? Id_proceso { get; set; }
        public scp_ProcesosEntities? ProcesosObj { get; set; }
        public string? TipoCargo { get; set; }
    }

}
