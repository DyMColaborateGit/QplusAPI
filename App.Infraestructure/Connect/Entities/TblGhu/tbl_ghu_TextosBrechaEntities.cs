using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_TextosBrechaEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TextoBrechaId { get; set; }
    public int EmpresaId { get; set; }
    public string? TextoBrecha { get; set; }
    public bool Estado { get; set; }
    public long UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
}
