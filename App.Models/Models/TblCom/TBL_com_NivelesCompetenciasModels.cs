using System;

namespace App.Models.Models.TblCom;

public class TBL_com_NivelesCompetenciasModels
{
    public int NivelId { get; set; }

    public int EmpresaId { get; set; }

    public int TipoId { get; set; }

    public double ValorMinComp { get; set; }

    public double ValorMaxComp { get; set; }

    public double ValorMinInd { get; set; }

    public double ValorMaxInd { get; set; }

    public double Calificacion { get; set; }

    public string? Nivel { get; set; }

    public string? Color { get; set; }

    public string? Descripcion { get; set; }

    public double? MinDesempeno { get; set; }

    public double? MaxDesempeno { get; set; }
}
