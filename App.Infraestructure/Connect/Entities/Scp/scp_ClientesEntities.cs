using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_ClientesEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClienteId { get; set; }
    [Key]
    public string? CodigoCli { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Identificacion { get; set; }
    public string? Telefono { get; set; }
    public bool Estado { get; set; }
    public int TipoLicenciaId { get; set; }
    public string? CodigoLicencia { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int NumUsers { get; set; }
    public string? TipoBD { get; set; }
    public string? NomBD { get; set; }
    public string? HostBD { get; set; }
    public string? UserBD { get; set; }
    public string? PassBD { get; set; }
    public string? PortBD { get; set; }
    public string? SmtpHost { get; set; }
    public string? StrCorreo { get; set; }
    public string? StrPassword { get; set; }
    public bool InsLog { get; set; }
    public int TipoSync { get; set; }
    public int TipoLogin { get; set; }
    public string? Idioma { get; set; }
    public string? Logo { get; set; }
    public long UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public long UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int? TipoEmpresa { get; set; }
    //public ICollection<scp_EmpresasEntities>? SCP_Empresas { get; set; }
    public ICollection<scp_UsuariosEntities>? SCP_Usuarios { get; set; }
}
