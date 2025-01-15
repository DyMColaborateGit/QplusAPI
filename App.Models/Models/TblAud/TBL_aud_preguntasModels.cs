using System;

namespace App.Models.Models.TblAud
{
    public class TBL_aud_preguntasModels
    {
        public int IdPregunta { get; set; }

        public int? EmpresaId { get; set; }

        public string? PreguntaTexto { get; set; }

        public bool? Estado { get; set; }
    }
}
