using System;

namespace App.Models.Models.TblCom;

public class TBL_com_PreguntasModels
{
    public int IdPregunta { get; set; }

    public int EmpresaId { get; set; }

    public string? Pregunta { get; set; }

    public bool Estado { get; set; }
}
