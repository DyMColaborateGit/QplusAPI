using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblAud
{
    public class tbl_aud_preguntasEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPregunta { get; set; }

        public int? EmpresaId { get; set; }

        public string? PreguntaTexto { get; set; }

        public bool? Estado { get; set; }
    }
}
