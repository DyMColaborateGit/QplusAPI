using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_ParametrosEmpresasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ParametroId { get; set; }
    public int EmpresaId { get; set; }
    public string? Parametro {  get; set; }
    public string? Descripcion { get; set; }
    public decimal? Valor { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
