using System;

namespace App.Models.Models.TblCom;

public class Tbl_com_ResultadosEvaluacionModels
{
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int NormaId { get; set; }
    public double Resultado { get; set; }
    public double Porcentaje { get; set; }
    public string? Nivel { get; set; }
    public string? Color { get; set; }
    public string? Observaciones { get; set; }
}

public class ResponseTbl_com_ResultadosEvaluacionModels
{
    public ResponseTbl_com_ResultadosEvaluacionModels()
    {
        Normasobj = new Tbl_com_NormasModels();
    }
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int NormaId { get; set; }
    public Tbl_com_NormasModels? Normasobj { get; set; }
    public decimal Resultado { get; set; }
    public decimal Porcentaje { get; set; }
    public string? Nivel { get; set; }
    public string? Color { get; set; }
    public string? Observaciones { get; set; }
}

public class ResponseJoinTbl_com_ResultadosEvaluacionModels
{
    public ResponseJoinTbl_com_ResultadosEvaluacionModels()
    {
        Normasobj = new Tbl_com_NormasModels();
        Comportamientos = new List<Tbl_com_ResultadosModels>();
    }
    public int ResultadoId { get; set; }
    public int EvaluacionId { get; set; }
    public int NormaId { get; set; }
    public Tbl_com_NormasModels? Normasobj { get; set; }
    public decimal Resultado { get; set; }
    public decimal Porcentaje { get; set; }
    public string? Nivel { get; set; }
    public string? Color { get; set; }
    public string? Observaciones { get; set; }
    public List<Tbl_com_ResultadosModels>? Comportamientos { get; set; }
}
