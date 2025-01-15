using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_TotalIndEstCorporativosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdTotal { get; set; }
    public int Empresaid { get; set; }
    public int Anio { get; set; }
    public decimal Total { get; set; }
}
