using System;

namespace App.Models.Models.TblCom;

public class Tbl_com_NormasModels
{
    public int InIdNorma { get; set; }
    public int EmpresaId { get; set; }
    public string? VcCodNorma { get; set; }
    public string? VcCodFuncion { get; set; }
    public int? InIdTipoNorma { get; set; }
    public string? VcCompetencia { get; set; }
    public int? InConsecutivo { get; set; }
    public bool? BEstado { get; set; }
    public int? InIdGrupo { get; set; }
    public DateTime Fechacreacion { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string? UsuarioModificacion { get; set; }
}

public class JOINTbl_com_NormasModels
{
    public int InIdNorma { get; set; }
    public int EmpresaId { get; set; }
    public string? VcCodNorma { get; set; }
    public string? VcCodFuncion { get; set; }
    public int? InIdTipoNorma { get; set; }
    public string? VcCompetencia { get; set; }
    public int? InConsecutivo { get; set; }
    public bool? BEstado { get; set; }
    public int? InIdGrupo { get; set; }
    public DateTime Fechacreacion { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string? UsuarioModificacion { get; set; }
}
