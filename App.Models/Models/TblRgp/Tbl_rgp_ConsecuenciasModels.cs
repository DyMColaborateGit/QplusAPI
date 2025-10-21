
namespace App.Models.Models.TblRgp;

public class Tbl_rgp_ConsecuenciasModels
{
    public int IdConsecuencia { get; set; }
    public int EmpresaId { get; set; }
    public string? Consecuencia { get; set; }
    public int Valor {  get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}
