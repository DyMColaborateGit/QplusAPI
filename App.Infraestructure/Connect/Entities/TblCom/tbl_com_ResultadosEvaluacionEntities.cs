using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ResultadosEvaluacionEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ResultadoId { get; set; }
    [ForeignKey(nameof(EvaluacionId))]
    public int EvaluacionId { get; set; }
    public tbl_com_ProgEvaluacionEntities? ProgEvaluacionobj { get; set; }
    [ForeignKey(nameof(NormaId))]
    public int NormaId { get; set; }
    public tbl_com_NormasEntities? Normasobj { get; set; }
    public double Resultado { get; set; }
    public double Porcentaje { get; set; }
    public required string Nivel { get; set; }
    public required string Color { get; set; }
    public required string Observaciones { get; set; }
}
