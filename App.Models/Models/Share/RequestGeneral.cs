using System;

namespace App.Models.Models.Share;

public partial class RequestUpdateObservaciones
{
    public int NormaId { get; set; }
    public int Caracteres { get; set; }
    public string? Observacion { get; set; }
}

public partial class RequestUpdateComportamiento
{
    public int EmpresaId { get; set; }
    public long EvaluacionId { get; set; }
    public long NormaId { get; set; }
    public long ResultadoId { get; set; }
    public long ResultadoIdEscala { get; set; }
    public int Escala { get; set; }
    public int Escalaid { get; set; }
    public string? Escalanivel { get; set; }
    public int BCerrado { get; set; }
}

public class RequestConceptoFinal
{
    public long EvaluacionId { get; set; }
    public int EmpresaId { get; set; }
    public string? Justificacion { get; set; }
    public bool Concepto { get; set; }
}
public class RequestIndicadores
{
    public long ResultadoId { get; set; }
    public decimal Peso { get; set; }
    public decimal Meta { get; set; }
    public decimal Real { get; set; }
    public decimal Resultado { get; set; }
    public int Tipo { get; set; }
    public int EmpresaId { get; set; }
}