using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_EncuestaEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdEncuesta { get; set; }
    public int EmpresaId { get; set; }
    public int IdADI { get; set; }
    public int TotalPreguntas { get; set; }
    public int PreguntasCalificadas { get; set; }
    public int Estado { get; set; }
    public ICollection<tbl_com_EncuestaPreguntaEntities>? TBL_com_EncuestaPregunta { get; set; }
}
