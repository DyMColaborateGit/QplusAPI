using System;

namespace App.Models.Models.TblCom;

public class Tbl_com_EscalaEvaluacionModels
{
    public int EscalaId { get; set; }

    public int EmpresaId { get; set; }

    public string? Nivel { get; set; }

    public string? Abreviatura { get; set; }

    public int Escala { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public string? Color { get; set; }

    public string? Fondo { get; set; }

    public int? AspectovaloracionId { get; set; }
}

public class EscalaEvaluacionAspectosValoracionModels
{
    public List<Tbl_com_EscalaEvaluacionModels>? Competencias { get; set; }
    public List<Tbl_com_EscalaEvaluacionModels>? Indicadores { get; set; }
    public List<Tbl_com_EscalaEvaluacionModels>? CompTecnicas { get; set; }
}
