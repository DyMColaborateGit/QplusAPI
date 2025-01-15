using App.Models.Models.Scp;
using System;

namespace App.Models.Models.TblAud
{
    public class AuditoriasModels
    {
        public int IdAuditoria { get; set; }

        public int? InIdEmpresa { get; set; }

        public int? ZonaId { get; set; }

        public int? OficinaId { get; set; }

        public int? Consecutivo { get; set; }

        public string? CodigoAuditoria { get; set; }

        public int? Proceso { get; set; }

        public string? Auditor1 { get; set; }

        public string? Auditor2 { get; set; }

        public DateTime? FechaProg { get; set; }

        public DateTime? FechaReal { get; set; }

        public DateTime? FechaProgInforme { get; set; }

        public DateTime? FechaInfoDefinitivo { get; set; }

        public DateTime? FechaProgCierre { get; set; }

        public DateTime? FechaRealCierre { get; set; }

        public DateTime? FechaProgEvaluacion { get; set; }

        public DateTime? FechaRealEvaluacion { get; set; }

        public int? Mes { get; set; }

        public int? Anio { get; set; }

        public string? Estado { get; set; }

        public string? Requisitos { get; set; }

        public string? Hora { get; set; }

        public string? Auditados { get; set; }

        public double? FlIndicadorInforme { get; set; }

        public double? InDiasRetInforme { get; set; }

        public double? FlIndicadorCierre { get; set; }

        public double? InDiasRetCierre { get; set; }

        public double? FlIndicadorEvaluacion { get; set; }

        public double? InDiasRetEvaluacion { get; set; }

        public int? InIdSistema { get; set; }

        public long? AprobadorId { get; set; }

        public string? OtrosAuditores { get; set; }

        public long? Identiauditor1 { get; set; }

        public long? Identiauditor2 { get; set; }
    }

    public class ResponseAuditoriasModels
    {
        public int IdAuditoria { get; set; }

        public int? InIdEmpresa { get; set; }

        public int? ZonaId { get; set; }

        public int? OficinaId { get; set; }

        public int? Consecutivo { get; set; }

        public string? CodigoAuditoria { get; set; }

        public int? Proceso { get; set; }

        public SCP_ProcesosModels? ProcesosObj { get; set; }

        public string? Auditor1 { get; set; }

        public string? Auditor2 { get; set; }

        public DateTime? FechaProg { get; set; }

        public DateTime? FechaReal { get; set; }

        public DateTime? FechaProgInforme { get; set; }

        public DateTime? FechaInfoDefinitivo { get; set; }

        public DateTime? FechaProgCierre { get; set; }

        public DateTime? FechaRealCierre { get; set; }

        public DateTime? FechaProgEvaluacion { get; set; }

        public DateTime? FechaRealEvaluacion { get; set; }

        public int? Mes { get; set; }

        public int? Anio { get; set; }

        public string? Estado { get; set; }

        public string? Requisitos { get; set; }

        public string? Hora { get; set; }

        public string? Auditados { get; set; }

        public double? FlIndicadorInforme { get; set; }

        public double? InDiasRetInforme { get; set; }

        public double? FlIndicadorCierre { get; set; }

        public double? InDiasRetCierre { get; set; }

        public double? FlIndicadorEvaluacion { get; set; }

        public double? InDiasRetEvaluacion { get; set; }

        public int? InIdSistema { get; set; }

        public long? AprobadorId { get; set; }

        public string? OtrosAuditores { get; set; }

        public long? Identiauditor1 { get; set; }

        public long? Identiauditor2 { get; set; }
    }
}
