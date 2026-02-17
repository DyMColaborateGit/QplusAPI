
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp
{
    public class tbl_rgp_AgentesEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAgente { get; set; }
        public int EmpresaId { get; set; }
        public string? Agente { get; set; }
        public bool Estado { get; set; }
    }
}
