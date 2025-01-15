using App.Infraestructure.Connect.Entities.Scp;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblAud
{
    public class tbl_aud_EvaAuditoresEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdEvaluacion { get; set; }

        public int EmpresaId { get; set; }

        [ForeignKey(nameof(IdAuditoria))]
        public int IdAuditoria { get; set; }
        public auditoriasEntities? AuditoriasObj { get; set; }

        [ForeignKey(nameof(IdAuditor))]
        public long IdAuditor { get; set; }
        public scp_FuncionariosEntities?  AuditorObj{ get; set; }

        public decimal Promedio { get; set; }

        public string? Observaciones { get; set; }

        public int TotalPreCalificadas { get; set; }

        public int TotalPreguntas { get; set; }

        public bool Estado { get; set; }
    }
}
