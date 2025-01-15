using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_RolesEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }
    [Key]
    public int? CodigoRol { get; set; }
    public int? RolPadre { get; set; }
    public string? Role { get; set; }
    public string? CodigoApp { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public ICollection<scp_UsuariosRolesEntities>? scp_UsuariosRoles { get; set; }
}
