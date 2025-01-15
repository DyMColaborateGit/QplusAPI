using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ResultadosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ResultadoId { get; set; }
    [ForeignKey(nameof(EvaluacionId))]
    public int EvaluacionId { get; set; }
    public tbl_com_ProgEvaluacionEntities? ProgEvaluacionobj { get; set; }
    public int? CriterioId { get; set; }
    public int NormaId { get; set; }
    public string? Criterio { get; set; }
    public DateTime? FechaEva { get; set; }
    public int? ResEscala { get; set; }
    public int? BMejoramiento { get; set; }
    public string? VcObMejoramiento { get; set; }
    public bool? BEstado { get; set; }
    public int? BCerrado { get; set; }
    public string? Color { get; set; }
    public int? EscalaId { get; set; }
    public string? Escalanivel { get; set; }
}
