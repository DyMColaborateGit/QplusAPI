using System;

namespace App.Models.Models.TblInd;

public class Tbl_ind_ObjetivosCalidadModels
{
    public int InIdTipoObjetivo { get; set; }

    public int? EmpresaId { get; set; }

    public string? VcObjetivo { get; set; }

    public string? VcIndicador { get; set; }

    public int? Perspectiva { get; set; }

    public bool? Estado { get; set; }
}
