using System;

namespace App.Models.Models.TblCom;

public class TBL_com_ActividadesPIDModels
{
    public int InIdActividadPID { get; set; }
    public int? EmpresaId { get; set; }
    public long? EvaluadoId { get; set; }
    public int? InIdEvaluacion { get; set; }
    public int? InIdTipoActividad { get; set; }
    public string? VcActividad { get; set; }
    public DateTime? DtFechaInicial { get; set; }
    public DateTime? DtFechaFinal { get; set; }
    public DateTime? DtFechaReal { get; set; }
    public string? VcLugar { get; set; }
    public string? VcObMejoramiento { get; set; }
    public int? BEstado { get; set; }
    public bool? BCapacitacion { get; set; }
    public int? InIdFuente { get; set; }
    public int? InAnio { get; set; }
    public int? CategoriaPDI { get; set; }
    public string? AutoDesarrollo { get; set; }
    public string? TipoActividadOtro { get; set; }
    public string? Analisis { get; set; }
}
