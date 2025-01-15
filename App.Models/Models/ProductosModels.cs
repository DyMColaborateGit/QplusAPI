using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class ProductosModels
    {
        public int? IdProducto { get; set; }
        public int? IdProceso { get; set; }
        public string? Producto { get; set; }
        public string? VcDescripcion { get; set; }
        public int Frecuencia { get; set; }
        public int Responsable { get; set; }
        public int Estado { get; set; }
        public int TipoProducto { get; set; }
        public int TipoIndOpt { get; set; }
        public int? Eliminado { get; set; }
        public string? Abreviatura { get; set; }
    }

}
