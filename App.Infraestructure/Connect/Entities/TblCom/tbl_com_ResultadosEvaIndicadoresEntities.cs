using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.TblInd;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ResultadosEvaIndicadoresEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ResultadoId { get; set; }
    [ForeignKey(nameof(EvaluacionId))]
    public int EvaluacionId { get; set; }
    public tbl_com_ProgEvaluacionEntities? ProgEvaluacionobj { get; set; }
    [ForeignKey(nameof(IndcadorId))]
    public int IndcadorId { get; set; }
    public tbl_ind_MastIndicadoresEntities? MastIndicadoresobj { get; set; }
    public string? Indicador { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Peso { get; set; }
    public decimal Meta { get; set; }
    public decimal Real { get; set; }
    public decimal Ponderado { get; set; }
    public string? Cumple { get; set; }
    public string? Color { get; set; }
    public decimal PesoNext { get; set; }
    public bool Editar { get; set; }
    public int? TipoIndi { get; set; }
    public bool? EnablePeso { get; set; }
    public bool? EnableCalificacion { get; set; }
}
