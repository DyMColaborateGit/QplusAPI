using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ResultcomTecnicasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ResultadoId { get; set; }

    public int EvaluacionId { get; set; }

    public string? Descripcion { get; set; }

    public string? Observacion { get; set; }

    public string? EscalaNivel { get; set; }

    public DateTime? FechaEva { get; set; }

    public int EscalaId { get; set; }

    public int ResEscala { get; set; }

    public bool? BEstado { get; set; }

    public int? BCerrado { get; set; }

    public string? Color { get; set; }
}
