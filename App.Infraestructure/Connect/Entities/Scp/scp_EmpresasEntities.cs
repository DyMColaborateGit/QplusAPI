using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Connect.Entities.TblMast;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_EmpresasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdEmpresa { get; set; }
    [Key]
    public int EmpresaId { get; set; }
    //[ForeignKey(nameof(ClienteId))]
    public int ClienteId { get; set; }
    //public scp_ClientesEntities? Clienteobj { get; set; }
    public string? CodigoCli { get; set; }
    public string? Empresa { get; set; }
    public string? Logo { get; set; }
    public bool Estado { get; set; }
    public string? Presentacion { get; set; }
    public string? Ciudad { get; set; }
    public int TipoLogin { get; set; }
    public int ParamCodigo { get; set; }
    public string? CodProveedor { get; set; }
    public string? SrvAutenticacion { get; set; }
    public string? DominioLdap { get; set; }
    public string? UsuarioLdap { get; set; }
    public string? ClaveLdap { get; set; }
    public string UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string UsuarioModificacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int TipoNivelComp { get; set; }
    public bool LogoMacroProceso { get; set; }
    public int CodTipoMatrix { get; set; }
    public bool Mod_MT { get; set; }
    public bool MapaTalentos { get; set; }
    public bool Mod_MD { get; set; }
    public bool Adi_Estrategicos { get; set; }

    public ICollection<scp_UsuariosEntities>? SCP_Usuarios { get; set; }
    public ICollection<scp_FuncionariosEntities>? SCP_Funcionarios { get; set; }
    public ICollection<scp_CargosEntities>? SCP_Cargos { get; set; }
    public ICollection<tbl_mast_ZonasEntities>? TBL_mast_Zonas { get; set; }
    public ICollection<tbl_mast_OficinasEntities>? TBL_mast_Oficinas { get; set; }
    public ICollection<tbl_com_NormasEntities>? TBL_com_Normas { get; set; }
    public ICollection<tbl_com_EscalaEvaluacionEntities>? TBL_com_EscalaEvaluacion { get; set; }
    public ICollection<tbl_com_TxtFormEvaluacionEntities>? TBL_com_TxtFormEvaluacion { get; set; }
}
