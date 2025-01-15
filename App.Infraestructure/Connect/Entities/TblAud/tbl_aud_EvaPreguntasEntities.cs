using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblAud
{
    public class tbl_aud_EvaPreguntasEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaPregunta { get; set; }

        public int? EmpresaId { get; set; }

        public int? IdPregunta { get; set; }

        public int? IdEvaluacion { get; set; }

        public int? Calificacion { get; set; }

        public string? TextPregunta { get; set; }
    }
}
