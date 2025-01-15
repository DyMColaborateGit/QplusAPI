using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ResultadoEvaluacionADAEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdResultado { get; set; }
    public int? IdEvaluacion { get; set; }
    public int? IdPadre { get; set; }
    public int? IdHijo { get; set; }
    public string? TextoPregunta { get; set; }
    public string? TextoRespuesta { get; set; }
    public string? ResultadoTxt { get; set; }
    public bool? Resultado { get; set; }
    public int? Tipo { get; set; }
    public int? Orden { get; set; }
}
