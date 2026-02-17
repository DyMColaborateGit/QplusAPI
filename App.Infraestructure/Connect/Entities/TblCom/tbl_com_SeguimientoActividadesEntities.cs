using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_SeguimientoActividadesEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InIdSeguimiento { get; set; }
    public int InIdActividadPIM { get; set; }
    public DateTime DtFechaSeguimiento { get; set; }
    public DateTime DtFechaReal { get; set; }
    public string? VcSeguimiento { get; set; }
    public string? UsuarioSeguimiento { get; set; }
}
