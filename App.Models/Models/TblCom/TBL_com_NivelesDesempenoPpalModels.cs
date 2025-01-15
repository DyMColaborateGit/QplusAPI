using System;

namespace App.Models.Models.TblCom;

public class TBL_com_NivelesDesempenoPpalModels
{
    public int IdNivel { get; set; }

    public int EmpresaId { get; set; }

    public string? Nivel { get; set; }

    public string? ConceptoFinal { get; set; }

    public string? Color { get; set; }

    public int UbicacionMD { get; set; }

    public int? InAnio { get; set; }
    public int Contevaluaciones { get; set; }

    public string? Backgroundcolor { get; set; }
    public double PorcentajeEvaluaciones { get; set; }
    public int TotalEvaluaciones { get; set; }
}
