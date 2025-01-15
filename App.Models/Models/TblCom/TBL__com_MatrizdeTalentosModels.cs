using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.TblCom;

public class TBL_com_MatrizdeTalentosModels
{
    public int CodTalento { get; set; }

    public int EmpresaId { get; set; }

    public string? NombreCaja { get; set; }

    public string? Descripcion { get; set; }

    public int NumeroCaja { get; set; }

    public decimal PorcMaxC { get; set; }

    public decimal PorcMinC { get; set; }

    public decimal PorcMaxI { get; set; }

    public decimal PorcMinI { get; set; }

    public int CodMatrix { get; set; }

    public string? Color { get; set; }

    public bool Estado { get; set; }

    public long UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}

public class ResponseTBL_com_MatrizdeTalentosModels
{
    public int CodTalento { get; set; }

    public int EmpresaId { get; set; }

    public string? NombreCaja { get; set; }

    public string? Descripcion { get; set; }

    public int NumeroCaja { get; set; }

    public decimal PorcMaxC { get; set; }

    public decimal PorcMinC { get; set; }

    public decimal PorcMaxI { get; set; }

    public decimal PorcMinI { get; set; }

    public int CodMatrix { get; set; }

    public string? Color { get; set; }

    public bool Estado { get; set; }

    public long UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public long UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int Contevaluaciones { get; set; }

    public string? Backgroundcolor { get; set; }
    public double PorcentajeEvaluaciones { get; set; }
    public int TotalEvaluaciones { get; set; }
}
