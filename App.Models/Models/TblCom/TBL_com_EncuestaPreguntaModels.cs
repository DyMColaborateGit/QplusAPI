using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Models.TblCom;

public class TBL_com_EncuestaPreguntaModels
{
    public int IdEncuestaPregunta { get; set; }

    public int EmpresaId { get; set; }

    public int IdEncuesta { get; set; }

    public int IdPregunta { get; set; }

    public int Resultado { get; set; }
}

public class JOIN_tbl_com_EncuestaPreguntaModels
{
    public int IdEncuestaPregunta { get; set; }

    public int EmpresaId { get; set; }

    public int IdEncuesta { get; set; }

    public TBL_com_EncuestaModels? EncuestaObj { get; set; }

    public int IdPregunta { get; set; }

    public TBL_com_PreguntasModels? PreguntaObj { get; set; }

    public int Resultado { get; set; }
}
