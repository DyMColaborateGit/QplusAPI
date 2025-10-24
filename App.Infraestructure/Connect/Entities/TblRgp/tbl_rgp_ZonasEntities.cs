
using App.Infraestructure.Connect.Entities.TblDoc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_ZonasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdZona { set; get; }
    public int EmpresaId { set; get; }
    public string? Zona { set; get; }
    public string? Respuesta { set; get; }
    public string? Color { set; get; }
    public string? Sigla { set; get; }
    public string? Aceptabilidad { set; get; }
    public bool Estado { set; get; }
    public ICollection<tbl_rgp_ParametrosValoracionEntities>? TBL_rgp_ParametrosValoracion { get; set; }

}
