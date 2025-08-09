using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_TemasBrechaPEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TemaBrechaId { get; set; }
    public int EmpresaId { get; set; }
    public string? NombreTema { get; set; }
    public int CodigoTema { get; set; }
    public bool Estado { get; set; }
}
