using System;

namespace App.Models.Models.TblAud
{
    public class TBL_aud_EvaPreguntasModels
    {
        public int IdEvaPregunta { get; set; }

        public int? EmpresaId { get; set; }

        public int? IdPregunta { get; set; }

        public int? IdEvaluacion { get; set; }

        public int? Calificacion { get; set; }

        public string? TextPregunta { get; set; }
    }
}
