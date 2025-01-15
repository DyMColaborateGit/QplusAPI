using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Entities.TblMast;

public class tbl_mast_ZonasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ZonaId { get; set; }
    public int CodigoZO { get; set; }
    public int ClienteId { get; set; }
    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }
    public scp_EmpresasEntities? Empresaobj { get; set; }
    public string? Zona { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CargoResponsable { get; set; }
}
