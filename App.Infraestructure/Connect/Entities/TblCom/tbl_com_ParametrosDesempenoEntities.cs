using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_ParametrosDesempenoEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
