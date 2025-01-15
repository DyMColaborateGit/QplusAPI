using System;

namespace App.Models.Models.TblCom;

public class TBL_com_RelGestoresDialogoDesarrolloModels
{
    public int IdRelgd { get; set; }
    public int EmpresaId { get; set; }
    public long FuncionarioId { get; set; }
    public long GestorId { get; set; }
    public string? TipoRel { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
