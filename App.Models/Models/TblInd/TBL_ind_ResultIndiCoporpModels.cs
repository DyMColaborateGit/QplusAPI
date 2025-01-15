using System;

namespace App.Models.Models.TblInd;

public class TBL_ind_ResultIndiCoporpModels
{
    public int ResultadoId { get; set; }
    public int? EmpresaId { get; set; }
    public string? CodigoIndi { get; set; }
    public int? Anio { get; set; }
    public decimal? Resultado { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Ponderado { get; set; }
}

public class JOINTBL_ind_ResultIndiCoporpModels
{
    public int ResultadoId { get; set; }
    public int? EmpresaId { get; set; }
    public string? CodigoIndi { get; set; }
    public Tbl_ind_MastIndicadoresModels? MastIndicadoresobj { get; set; }
    public int? Anio { get; set; }
    public decimal? Resultado { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Ponderado { get; set; }
}
