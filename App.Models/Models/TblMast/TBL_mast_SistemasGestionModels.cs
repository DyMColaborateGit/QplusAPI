using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.TblMast
{
    public class TBL_mast_SistemasGestionModels
    {
        public int InIdSistema { get; set; }
        public int EmpresaId { get; set; }
        public string VcSistema { get; set; }
        public string VcSigla { get; set; }
        public int InEstado { get; set; }
        public int Principal { get; set; }
    }
}
