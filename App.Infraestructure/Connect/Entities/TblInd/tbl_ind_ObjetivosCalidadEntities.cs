using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblInd;

public class tbl_ind_ObjetivosCalidadEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int InIdTipoObjetivo { get; set; }

    public int? EmpresaId { get; set; }

    public string? VcObjetivo { get; set; }

    public string? VcIndicador { get; set; }

    public int? Perspectiva { get; set; }

    public bool? Estado { get; set; }
}
