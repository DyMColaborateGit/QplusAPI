using System;
using App.Models.Models.Scp;

namespace App.Models.Models.Share;

public class LoginModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int Id { get; set; }
    public string? Token { get; set; }
    public bool EstaAutenticado { get; set; }
    public SCP_UsuarioModels Usuario { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }

    public LoginModel()
    {
        Usuario = new SCP_UsuarioModels();
    }
}
