using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_PesosxTipoIndEstxTipoNivelEstEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdPesos { get; set; }
    public int Empresaid { get; set; }
    public int TipoNivelEst { get; set; }
    public int IdtipoIndicadorEst { get; set; }
    public decimal Peso { get; set; }
    public int Anio { get; set; }
}
