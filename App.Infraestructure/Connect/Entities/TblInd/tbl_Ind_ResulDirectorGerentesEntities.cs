using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_Ind_ResulDirectorGerentesEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Resultadoid { get; set; }
    public int Anio { get; set; }
    public int Mesini { get; set; }
    public int Mesfin { get; set; }
    public long Identificacion { get; set; }
    public decimal Resultado { get; set; }
    public string? Tipo { get; set; }
}
