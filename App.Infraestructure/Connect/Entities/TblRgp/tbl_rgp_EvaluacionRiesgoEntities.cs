
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;

public class tbl_rgp_EvaluacionRiesgoEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdEvaluacion { set; get; }
    public DateTime Fecha { set; get; }
    public int IdRiesgo { set; get; }
    public int ValorProbabilidad { set; get; }
    public int ValorConsecuencia { set; get; }
    public int ResultadoRiesgo { set; get; }
    public string? Zona { set; get; }
    public string? SiglaZona { set; get; }
    public string? Respuesta { set; get; }
    public string? Color { set; get; }
    public string? Aceptabilidad { set; get; }
    public int EvaAnterior { set; get; }
    public int UbicacionMR { set; get; }
}
