using System;

namespace App.Models.Models.TblCom;

public class TBL_com_DialogodeDesarrolloModels
{
    public int IdDialogo { get; set; }
    public int EmpresaId { get; set; }
    public long FuncionarioId { get; set; }
    public string? Observacion { get; set; }
    public string? TipoGestor { get; set; }
    public long GestorId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
