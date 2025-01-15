using System;

namespace App.Models.Models.TblCom;

public class TBL_com_ResultadoEvaluacionADAModels
{
    public int IdResultado { get; set; }
    public int? IdEvaluacion { get; set; }
    public int? IdPadre { get; set; }
    public int? IdHijo { get; set; }
    public string? TextoPregunta { get; set; }
    public string? TextoRespuesta { get; set; }
    public string? ResultadoTxt { get; set; }
    public bool? Resultado { get; set; }
    public int? Tipo { get; set; }
    public int? Orden { get; set; }
}

public class PutRequestTBL_com_ResultadoEvaluacionADAModels
{
    public int IdResultado { get; set; }
    public string? ResultadoTxt { get; set; }
}
