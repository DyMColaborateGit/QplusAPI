using System;

namespace App.Models.Models.TblMast;

public class TBL_mast_OficinasModels
{
    public int OficinaId { get; set; }
    public int CodigoOf { get; set; }
    public int EmpresaId { get; set; }
    public string? Oficina { get; set; }
    public int ZonaId { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CargoResponsable { get; set; }
}
