using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_RelIndiEstrategicosFuncionariosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdRelacion { get; set; }
    [ForeignKey(nameof(IndicadorId))]
    public int IndicadorId { get; set; }
    public tbl_ind_MastIndicadoresEntities? tbl_ind_MastIndicadoresObj { get; set; }
    public long Identificacion { get; set; }
    public double Peso { get; set; }
}
