using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_PreguntasBrechaPEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int PreguntaId { get; set; }
    public int EmpresaId { get; set; }
    public string? Pregunta { get; set; }
    public int TipoPregunta { get; set; }
    public int TemaBrechaId { get; set; }
    public bool Estado { get; set; }
    public int Orden { get; set; }
   
}
