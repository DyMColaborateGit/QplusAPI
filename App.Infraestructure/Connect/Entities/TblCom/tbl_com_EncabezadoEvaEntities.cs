
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities.TblCom;

public class tbl_com_EncabezadoEvaEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int EncabezadoId { get; set; }
    [ForeignKey(nameof(InIdEbaluacion))]
    public int? InIdEbaluacion { get; set; }
    public tbl_com_ProgEvaluacionEntities? ProgEvaluacionobj { get; set; }
    public required string Periodo { get; set; }
    public required string Nombre { get; set; }
    public required string Identificacion { get; set; }
    public required string Oficina { get; set; }
    public required string Zona { get; set; }
    public required string VcNombre { get; set; }
    public required string Proceso { get; set; }
    public required string Motivo { get; set; }
    public required string Texto { get; set; }
    public required string TextoIndi { get; set; }
}
