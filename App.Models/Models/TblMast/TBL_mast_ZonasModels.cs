using System;

namespace App.Models.Models.TblMast;

public class TBL_mast_ZonasModels
{
    public int ZonaId { get; set; }
    public int CodigoZO { get; set; }
    public int ClienteId { get; set; }
    public int EmpresaId { get; set; }
    public string? Zona { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CargoResponsable { get; set; }
}
