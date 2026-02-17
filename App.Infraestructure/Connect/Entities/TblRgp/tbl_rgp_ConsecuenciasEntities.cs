
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_ConsecuenciasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdConsecuencia { get; set; }
    public int EmpresaId { get; set; }
    public string? Consecuencia { get; set; }
    public int Valor { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}
