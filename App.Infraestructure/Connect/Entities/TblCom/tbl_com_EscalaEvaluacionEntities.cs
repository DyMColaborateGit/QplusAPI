using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Infraestructure.Connect.Entities.Scp;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_EscalaEvaluacionEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int EscalaId { get; set; }

    [ForeignKey(nameof(EmpresaId))]
    public int EmpresaId { get; set; }

    public scp_EmpresasEntities? Empresaobj { get; set; }

    public string? Nivel { get; set; }

    public string? Abreviatura { get; set; }

    public int Escala { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public string? Color { get; set; }

    public string? Fondo { get; set; }

    public int? AspectovaloracionId { get; set; }
}
