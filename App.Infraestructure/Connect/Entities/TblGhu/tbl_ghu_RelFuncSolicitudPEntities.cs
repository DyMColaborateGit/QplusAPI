using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_RelFuncSolicitudPEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int RelFuncSolicitudPId { get; set; }
    public int EmpresaId { get; set; }
    public long Identificacion { get; set; }
    public int SolicitudId { get; set; }
    public bool Brecha { get; set; }
    public string? TextoBrecha { get; set; }
    public long UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public long UsuarioCierreBrecha { get; set; }

}
