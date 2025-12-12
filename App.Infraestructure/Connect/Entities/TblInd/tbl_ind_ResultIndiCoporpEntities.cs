
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_ResultIndiCoporpEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ResultadoId { get; set; }
    public int? EmpresaId { get; set; }

    [ForeignKey(nameof(CodigoIndi))]
    public string? CodigoIndi { get; set; }
    public tbl_ind_MastIndicadoresEntities? MastIndicadoresObj { get; set; }
    public int? Anio { get; set; }
    public decimal? Resultado { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Ponderado { get; set; }
}
