using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_UsuariosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }
    [Key]
    public long WWID { get; set; }
    [ForeignKey(nameof(ClienteId))]
    public int ClienteId { get; set; }
    public scp_ClientesEntities? Clienteobj { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }
    [ForeignKey(nameof(FuncionarioId))]
    public long FuncionarioId { get; set; }
    public scp_FuncionariosEntities? Funcionariobj { get; set; }
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
    public ICollection<scp_UsuariosRolesEntities>? scp_UsuariosRoles { get; set; }
}
