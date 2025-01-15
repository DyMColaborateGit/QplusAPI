using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Entities
{
    public class historial_cambiosEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? IdHistorial {  get; set; }
        public DateTime FechaHistorial { get; set; }
        public DateTime FechaCambio { get; set; }
        public int NumeroActualizacion {  get; set; }
        public string? Descripcion {  get; set; }
        public string? CodigoDocumento { get; set; }
        public int IdDocumento { get; set; }
        public int EmpresaId {  get; set; }
    }
}
