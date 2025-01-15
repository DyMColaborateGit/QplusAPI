using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Entities
{
    public class control_distribucionEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdDistribucion { get; set; }
        public DateTime FechaDistribucion { set; get; }
        public DateTime Fecha { set; get; }
        public int NumeroActualizacion { get; set; }
        public string? ListaDistribucion { get; set;}
        public string? CodigoDocumento { get; set; }
        public int IdDocumento { get; set; }
        public int EmpresaId {  get; set; }
    }
}
