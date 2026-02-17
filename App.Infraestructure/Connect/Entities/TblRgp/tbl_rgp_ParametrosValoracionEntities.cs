using App.Infraestructure.Connect.Entities.Scp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblRgp;
public class tbl_rgp_ParametrosValoracionEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdParametro { get; set; }
    public int EmpresaId { get; set; }
    public int ValorProbabilidad { get; set; }
    public int valorConsecuencia { get; set; }
    public int Resultado { get; set; }

    [ForeignKey(nameof(IdZona))]
    public int? IdZona { get; set; }
    public tbl_rgp_ZonasEntities? ZonaObj { get; set; }
    public int UbicacionMR { get; set; }
}
