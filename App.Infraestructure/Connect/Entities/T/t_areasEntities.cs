using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.T
{
    public class areasEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? IdArea { get; set; }
        public int EmpresaId {  get; set; }
        public string? Area { get; set; }
        public string? CodigoMapa { get; set; }
        public string? FuncionPpl { get; set; }
        public int Estado {  get; set; }
        public string? Sigla {  get; set; }
        public string? Logo { get; set; }

    }
}
