using App.Models.Models.Scp;
using System;

namespace App.Models.Models.TblAud;

public class TBL_aud_EvaAuditoresModels
{
    public int IdEvaluacion { get; set; }

    public int EmpresaId { get; set; }

    public int IdAuditoria { get; set; }

    public long IdAuditor { get; set; }

    public decimal Promedio { get; set; }

    public string? Observaciones { get; set; }

    public int TotalPreCalificadas { get; set; }

    public int TotalPreguntas { get; set; }

    public bool Estado { get; set; }
}

public class ResponseTBL_aud_EvaAuditoresModels
{
    public int IdEvaluacion { get; set; }

    public int EmpresaId { get; set; }

    public int IdAuditoria { get; set; }
    public ResponseAuditoriasModels? AuditoriasObj { get; set; }

    public long IdAuditor { get; set; }
    public SCP_FuncionariosModels? AuditorObj { get; set; }

    public decimal Promedio { get; set; }

    public string? Observaciones { get; set; }

    public int TotalPreCalificadas { get; set; }

    public int TotalPreguntas { get; set; }

    public bool Estado { get; set; }
}
