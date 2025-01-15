using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.Connect.Entities.Tipo
{
    public class tipos_DocumentoEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }
        public int EmpresaId { get; set; }
        public string CodigoTipo { get; set; }
        public string Tipo { get; set; }
        public string Observaciones { get; set; }
        public int TipoDocumento {  get; set; }
        public Boolean Adjunto { get; set; }
        public Boolean Estado {  get; set; }
    }
}
