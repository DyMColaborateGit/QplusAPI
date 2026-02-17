
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_TipoAnalisisEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdTipoAnalisis { get; set; }
    public int EmpresaId { get; set; }
    public string? TipoAnalisis { get; set; }
    public bool Estado { get; set; }
}
