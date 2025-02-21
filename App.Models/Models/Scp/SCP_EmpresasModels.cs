using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Models.Scp;

public class SCP_EmpresasModels
{
    public int IdEmpresa { get; set; }
    public int EmpresaId { get; set; }
    public int ClienteId { get; set; }
    public string? CodigoCli { get; set; }
    public string? Empresa { get; set; }
    public string? Logo { get; set; }
    public bool Estado { get; set; }
    public string? Presentacion { get; set; }
    public string? Ciudad { get; set; }
    public int TipoLogin { get; set; }
    public int ParamCodigo { get; set; }
    public string? CodProveedor { get; set; }
    public string? SrvAutenticacion { get; set; }
    public string? DominioLdap { get; set; }
    public string? UsuarioLdap { get; set; }
    public string? ClaveLdap { get; set; }
    public string UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int TipoNivelComp { get; set; }
    public bool LogoMacroProceso { get; set; }
    public int CodTipoMatrix { get; set; }
    public bool Mod_MT {  get; set; }
    public bool MapaTalentos { get; set; }
    public bool Mod_MD { get; set; }
    public bool Adi_Estrategicos { get; set; }
}
