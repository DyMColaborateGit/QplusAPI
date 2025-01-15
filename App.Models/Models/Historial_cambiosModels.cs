using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models
{
    public class Historial_cambiosModels
    {
        public int? IdHistorial { get; set; }
        public DateTime FechaHistorial { get; set; }
        public DateTime FechaCambio { get; set; }
        public int NumeroActualizacion { get; set; }
        public string? Descripcion { get; set; }
        public string? CodigoDocumento { get; set; }
        public int IdDocumento { get; set; }
        public int EmpresaId { get; set; }
    }
}
