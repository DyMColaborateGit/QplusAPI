
namespace App.Models.Models.TblRgp;

public class Tbl_rgp_ParametrosValoracionModels
{
    public int IdParametro { get; set; }
    public int EmpresaId { get; set; }
    public int ValorProbabilidad { get; set; }
    public int valorConsecuencia { get; set; }
    public int Resultado { get; set; }
    public int? IdZona { get; set; }
    public Tbl_rgp_ZonasModels? ZonaObj { get; set; }
    public int UbicacionMR { get; set; }
}
