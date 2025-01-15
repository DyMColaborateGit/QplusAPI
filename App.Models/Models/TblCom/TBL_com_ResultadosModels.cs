using System;

namespace App.Models.Models.TblCom;

public class Tbl_com_ResultadosModels
{
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int? CriterioId { get; set; }
    public int NormaId { get; set; }
    public string? Criterio { get; set; }
    public DateTime? FechaEva { get; set; }
    public int? ResEscala { get; set; }
    public int? BMejoramiento { get; set; }
    public string? VcObMejoramiento { get; set; }
    public bool? BEstado { get; set; }
    public int BCerrado { get; set; }
    public string? Color { get; set; }
    public int? EscalaId { get; set; }
    public string? Escalanivel { get; set; }
}
