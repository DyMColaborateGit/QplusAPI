using App.Infraestructure.Connect.Entities.TblDoc;
using App.Models.Models.TblDoc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_CargosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int CargoId { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }
    public int Codigo { get; set; }
    public int CodigoCO { get; set; }
    public string? VcNombre { get; set; }
    public int NivelSeguridad { get; set; }
    public bool Estado { get; set; }
    public string? BActivo { get; set; }
    public bool Nuevo { get; set; }
    public bool COActiva { get; set; }
    public bool DescCargo { get; set; }
    public int AreaValoracion { get; set; }
    public int GrupoCargo { get; set; }
    public int IdTipoNivelEstrategico { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public long UsuarioModificacion { get; set; }
    public long UsuarioCreacion { get; set; }
    public ICollection<scp_FuncionariosEntities>? SCP_Funcionarios { get; set; }
    public ICollection<scp_CargosProcesosEntities>? SCP_CargosProcesos { get; set; }

}
