using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_EncuestaPreguntaEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdEncuestaPregunta { get; set; }

    public int EmpresaId { get; set; }

    [ForeignKey(nameof(IdEncuesta))]
    public int IdEncuesta { get; set; }
    public tbl_com_EncuestaEntities? EncuestaObj { get; set; }

    [ForeignKey(nameof(IdPregunta))]
    public int IdPregunta { get; set; }
    public tbl_com_PreguntasEntities? PreguntaObj { get; set; }

    public int Resultado { get; set; }
}
