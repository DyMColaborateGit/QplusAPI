
using App.Infraestructure.Connect.Entities.TblDoc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_RiesgosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdRiesgo { get; set; }
    public int EmpresaId { get; set; }
    public string? Riesgo { get; set; }
    public string? Descripcion { get; set; }
    public int IdAgente { get; set; }
    public string? Causas { get; set; }
    public string? Efectos { get; set; }
    public int ProcesoId { get; set; }
    public int ClaseId { get; set; }
    public int IdTipoAnalisis { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }

    [ForeignKey(nameof(EvaluacionId))]
    public int? EvaluacionId { get; set; }
    public tbl_rgp_EvaluacionRiesgoEntities? EvaluacionRObj { get; set; }
    public string? Codigo { get; set; }
    public int Consecutivo { get; set; }
    public int SubprocesoId { get; set; }
    public ICollection<tbl_rgp_EvaluacionRiesgoEntities>? TBL_rgp_EvaluacionRiesgo { get; set; }
}
