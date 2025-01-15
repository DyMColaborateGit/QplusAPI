using System;

namespace App.Models.Models.Scp;

public class SCP_UsuariosRolesModels
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}


public class ResponseSCP_UsuariosRolesModels
{
    public long UserId { get; set; }
    public SCP_UsuarioModels? Usuariobj { get; set; }
    public long RoleId { get; set; }
    public SCP_RolesModels? Roleobj { get; set; }
}
