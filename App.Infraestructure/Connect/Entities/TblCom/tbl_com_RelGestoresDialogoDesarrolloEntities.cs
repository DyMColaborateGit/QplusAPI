using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_RelGestoresDialogoDesarrolloEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int IdRelgd { get; set; }
    public int EmpresaId { get; set; }
    public long FuncionarioId { get; set; }
    public long GestorId { get; set; }
    public string? TipoRel { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
