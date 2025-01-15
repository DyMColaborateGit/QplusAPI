using System;

namespace App.Models.Models.Scp;

public class SCP_UsuarioModels
{
    public long UserId { get; set; }
    public long WWID { get; set; }
    public int ClienteId { get; set; }
    public int EmpresaId { get; set; }
    public long? FuncionarioId { get; set; }
    public string? Nombre { get; set; }
    public string? UserName { get; set; }
    public string? Clave { get; set; }
    public string? Email { get; set; }
    public string? Observaciones { get; set; }
    public string? ImagenUrl { get; set; }
    public bool Estado { get; set; }
    public bool IsLogged { get; set; }
    public DateTime LastLogin { get; set; }
    public int ErroresCount { get; set; }
    public string? Rol { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
