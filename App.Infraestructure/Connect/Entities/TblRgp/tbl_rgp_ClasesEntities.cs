
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp
{
    public class tbl_rgp_ClasesEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClaseId { get; set; }
        public int EmpresaId { get; set; }
        public string? Clase { get; set; }
        public bool Estado { get; set; }
    }
}
