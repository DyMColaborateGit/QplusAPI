using System;

namespace App.Models.Models.TblCom;

public class TBL_com_EncuestaModels
{
    public int IdEncuesta { get; set; }
    public int EmpresaId { get; set; }
    public int IdADI { get; set; }
    public int TotalPreguntas { get; set; }
    public int PreguntasCalificadas { get; set; }
    public int Estado { get; set; }
}
