namespace App.Models.Models.TblCom;

public class Tbl_com_EncabezadoEvaModels
{
    public int EncabezadoId { get; set; }
    public int? InIdEvaluacion { get; set; }
    public string? Periodo { get; set; }
    public string? Nombre { get; set; }
    public string? Identificacion { get; set; }
    public string? Oficina { get; set; }
    public string? Zona { get; set; }
    public string? VcNombre { get; set; }
    public string? Proceso { get; set; }
    public string? Motivo { get; set; }
    public string? Texto { get; set; }
    public string? TextoIndi { get; set; }
}

public class ResponseEncabezadoEvaModels
{
    public int EncabezadoId { get; set; }
    public int? InIdEvaluacion { get; set; }
    public Tbl_com_ProgEvaluacionModels? ProgEvaluacionobj { get; set; }
    public string? Periodo { get; set; }
    public string? Nombre { get; set; }
    public string? Identificacion { get; set; }
    public string? Oficina { get; set; }
    public string? Zona { get; set; }
    public string? VcNombre { get; set; }
    public string? Proceso { get; set; }
    public string? Motivo { get; set; }
    public string? Texto { get; set; }
    public string? TextoIndi { get; set; }
    public string? Fecha { get; set; }
}

