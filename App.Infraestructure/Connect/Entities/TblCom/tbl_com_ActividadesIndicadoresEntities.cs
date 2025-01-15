using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ActividadesIndicadoresEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int RelacionId { get; set; }
    public int ActividadId { get; set; }
    public int IndicadorId { get; set; }
}
