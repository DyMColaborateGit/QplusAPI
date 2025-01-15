using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Connect.Entities.TblAud;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_FuncionariosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_funcionario { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }
    public int? ZonaId { get; set; }
    public int? OficinaId { get; set; }
    [ForeignKey(nameof(CargoId))]
    public int CargoId { get; set; }
    public scp_CargosEntities? Cargoobj { get; set; }
    [Key]
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
    public ICollection<scp_UsuariosEntities>? SCP_Usuarios { get; set; }
    public ICollection<tbl_com_ProgEvaluacionEntities>? TBL_com_ProgEvaluacion { get; set; }
    public ICollection<tbl_aud_EvaAuditoresEntities>? TBL_aud_EvaAuditores { get; set; }
}
