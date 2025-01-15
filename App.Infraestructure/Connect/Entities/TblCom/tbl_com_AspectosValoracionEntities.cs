using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_AspectosValoracionEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AspectoValoracionId { get; set; }
    public int EmpresaId { get; set; }
    public string? AspectoValoracion { get; set; }
    public bool Estado { get; set; }
}
