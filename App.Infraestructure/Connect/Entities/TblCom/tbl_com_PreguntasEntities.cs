using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_PreguntasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdPregunta { get; set; }

    public int EmpresaId { get; set; }

    public required string Pregunta { get; set; }

    public bool Estado { get; set; }

    public ICollection<tbl_com_EncuestaPreguntaEntities>? TBL_com_EncuestaPregunta { get; set; }
}
