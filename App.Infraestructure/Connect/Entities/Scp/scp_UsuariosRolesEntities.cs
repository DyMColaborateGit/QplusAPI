using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_UsuariosRolesEntities
{
    [ForeignKey(nameof(UserId))]
    public long UserId { get; set; }
    public scp_UsuariosEntities? Usuariobj { get; set; }
    [ForeignKey(nameof(RoleId))]
    public int RoleId { get; set; }
    public scp_RolesEntities? Roleobj { get; set; }
}
