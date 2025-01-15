using System;

namespace App.Models.Models.TblCom;

public class TBL_com_ConsolidadoDesempenoModels
{
    public int ConsolidadoId { get; set; }

    public int EvaluacionId { get; set; }

    public int TipoId { get; set; }

    public decimal ValorAnalisis { get; set; }

    public string? Nivel { get; set; }

    public string? Color { get; set; }
}

public class TBL_com_TotalesConsolidadoDesempenoModels
{
    public int ConsolidadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int TipoId { get; set; }
    public decimal ValorAnalisis { get; set; }
    public string? NomTipo { get; set; }
    public string? Nivel { get; set; }
    public string? Color { get; set; }
    public decimal Peso { get; set; }
    public int Tiponivel { get; set; }
    public decimal PesoTIG { get; set; }
    public decimal PromTIG { get; set; }
    public string? ColorTIG { get; set; }
    public string? NivelTIG { get; set; }
    public bool PesoEstra { get; set; }
    public bool Pesoges { get; set; }
}
