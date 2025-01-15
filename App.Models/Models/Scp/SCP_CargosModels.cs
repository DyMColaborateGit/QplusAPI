using App.Models.Models.TblDoc;
using System;

namespace App.Models.Models.Scp;

public class SCP_CargosModels
{
    public int CargoId { get; set; }
    public int EmpresaId { get; set; }
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
}
