using System;

namespace App.Models.Models.Scp;

public class SCP_FuncionariosModels
{
    public int Id_funcionario { get; set; }
    public int EmpresaId { get; set; }
    public int? ZonaId { get; set; }
    public int? OficinaId { get; set; }
    public int CargoId { get; set; }
    public long Identificacion { get; set; }
    public string? Nombre { get; set; }
    public int? Genero { get; set; }
    public string? Email { get; set; }
    public int? Cenco { get; set; }
    public bool? Estado { get; set; }
    public int? NivelSeguridad { get; set; }
    public bool? Nuevo { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool? EstadoPerfil { get; set; }
    public bool? Hojadevida { get; set; }
    public bool? IndiEstrategico { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public decimal? Sueldo { get; set; }
    public int? TipoContratoId { get; set; }
    public int? SedeId { get; set; }
}

public class JOINSCP_FuncionariosModels
{
    public int Id_funcionario { get; set; }
    public int EmpresaId { get; set; }
    public int? ZonaId { get; set; }
    public int? OficinaId { get; set; }
    public int CargoId { get; set; }
    public SCP_CargosModels Cargoobj { get; set; }
    public long Identificacion { get; set; }
    public string? Nombre { get; set; }
    public int? Genero { get; set; }
    public string? Email { get; set; }
    public int? Cenco { get; set; }
    public bool? Estado { get; set; }
    public int? NivelSeguridad { get; set; }
    public bool? Nuevo { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public bool? EstadoPerfil { get; set; }
    public bool? Hojadevida { get; set; }
    public bool? IndiEstrategico { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public decimal? Sueldo { get; set; }
    public int? TipoContratoId { get; set; }
    public int? SedeId { get; set; }
}
