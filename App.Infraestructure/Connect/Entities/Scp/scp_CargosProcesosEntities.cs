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

        [ForeignKey(nameof(id_cargo))]
        public int? id_cargo { get; set; }
        public scp_CargosEntities? CargosObj { get; set; }
        public int? IdProceso { get; set; }
        public string? TipoCargo { get; set; }
    }

}
