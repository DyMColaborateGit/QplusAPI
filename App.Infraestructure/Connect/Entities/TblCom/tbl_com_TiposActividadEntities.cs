using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_TiposActividadEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int InIdTipoActividad { get; set; }
    public string? VcTipoActividad { get; set; }
    public bool? BEstado { get; set; }
    public int? InIdCategoria { get; set; }
    public int? EmpresaId { get; set; }
}
