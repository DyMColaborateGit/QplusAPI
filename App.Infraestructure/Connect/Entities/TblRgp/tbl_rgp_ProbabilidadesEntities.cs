
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_ProbabilidadesEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdProbabilidad { get; set; }
    public int EmpresaId { get; set; }
    public string? Probabilidad { get; set; }
    public int Varlor { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}
