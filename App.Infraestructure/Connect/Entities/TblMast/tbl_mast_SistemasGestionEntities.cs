using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Entities.TblMast
{
    public class tbl_mast_SistemasGestionEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int InIdSistema { get; set; }
        public int EmpresaId {  get; set; }
        public string VcSistema { get; set; }
        public string VcSigla { get; set; }
        public int InEstado { get; set; }
        public int Principal {  get; set; }

    }
}
