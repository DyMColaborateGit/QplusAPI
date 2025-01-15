using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_NormasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int InIdNorma { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }
    public required string VcCodNorma { get; set; }
    public required string VcCodFuncion { get; set; }
    public int? InIdTipoNorma { get; set; }
    public required string VcCompetencia { get; set; }
    public int? InConsecutivo { get; set; }
    public bool? BEstado { get; set; }
    public int? InIdGrupo { get; set; }
    public DateTime Fechacreacion { get; set; }
    public required string UsuarioCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public required string UsuarioModificacion { get; set; }
    public ICollection<tbl_com_ResultadosEvaluacionEntities>? TBL_com_ResultadosEvaluacion { get; set; }
    public ICollection<tbl_com_NivelesCargoCompEntities>? TBL_com_NivelesCargoComp { get; set; }
}
