using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_DialogodeDesarrolloEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdDialogo { get; set; }
    public int EmpresaId { get; set; }
    public long FuncionarioId { get; set; }
    public string? Observacion { get; set; }
    public string? TipoGestor { get; set; }
    public long GestorId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
