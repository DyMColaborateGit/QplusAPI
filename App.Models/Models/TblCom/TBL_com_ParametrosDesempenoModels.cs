using System;

namespace App.Models.Models.TblCom;

public class TBL_com_ParametrosDesempenoModels
{
    public int ParametroId { get; set; }
    public int? EmpresaId { get; set; }
    public int TipoId { get; set; }
    public string? OperadorMin { get; set; }
    public double ValorMin { get; set; }
    public string? OperadorMax { get; set; }
    public double ValorMax { get; set; }
    public string? Parametro { get; set; }
    public string? Color { get; set; }
    public string? Descripcion { get; set; }
}
