using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_RespuestasMultiplesBrechaPEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int RespuestaBrechaPId { get; set; }
    public int PreguntaId { get; set; }
    public int EmpresaId { get; set; }
    public string? Respuesta { get; set; }
    public bool Estado { get; set; }
   
}
