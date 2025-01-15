using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.Scp;

public class SCP_ParametrosEmpresasModels
{
    public int ParametroId { get; set; }
    public int EmpresaId { get; set; }
    public string? Parametro { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Valor { get; set; }
    public bool Estado { get; set; }
    public string? UsuarioCreacion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
