using App.Infraestructure.Connect.Entities.TblInd;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ConsolidadoDesempenoEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ConsolidadoId { get; set; }

    public int EvaluacionId { get; set; }

    public int TipoId { get; set; }
    public tbl_com_AspectosValoracionEntities? AspectoValoracionObj { get; set; }

    public decimal ValorAnalisis { get; set; }

    public string? Nivel { get; set; }

    public string? Color { get; set; }
}
