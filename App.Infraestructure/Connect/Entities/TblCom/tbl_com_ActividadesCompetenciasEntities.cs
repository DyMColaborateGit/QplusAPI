using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ActividadesCompetenciasEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int RelacionId { get; set; }
    public int? ActividadId { get; set; }
    public string? CodNorma { get; set; }
}
