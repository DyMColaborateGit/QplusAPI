using System;

namespace App.Models.Models.Scp;

public class SCP_RolesModels
{
    public int RoleId { get; set; }
    public int? CodigoRol { get; set; }
    public int? RolPadre { get; set; }
    public string? RoleName { get; set; }
    public string? CodigoApp { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
