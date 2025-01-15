using System;
using App.Models.Models.TblInd;

namespace App.Models.Models.TblCom;

public class Tbl_com_ResultadosEvaIndicadoresModels
{
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int IndcadorId { get; set; }
    public string? Indicador { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Peso { get; set; }
    public decimal Meta { get; set; }
    public decimal Real { get; set; }
    public decimal Ponderado { get; set; }
    public string? Cumple { get; set; }
    public string? Color { get; set; }
    public decimal PesoNext { get; set; }
    public bool Editar { get; set; }
    public int TipoIndi { get; set; }
    public bool EnablePeso { get; set; }
    public bool EnableCalificacion { get; set; }
}

public class JOINTbl_com_ResultadosEvaIndicadoresModels
{
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int IndcadorId { get; set; }
    public Tbl_ind_MastIndicadoresModels? MastIndicadoresobj { get; set; }
    public string? Indicador { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Peso { get; set; }
    public decimal Meta { get; set; }
    public decimal Real { get; set; }
    public decimal Ponderado { get; set; }
    public string? Cumple { get; set; }
    public string? Color { get; set; }
    public decimal PesoNext { get; set; }
    public bool Editar { get; set; }
    public int TipoIndi { get; set; }
    public bool EnablePeso { get; set; }
    public bool EnableCalificacion { get; set; }
    public bool bEvaluado { get; set; }
}
