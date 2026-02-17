
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infraestructure.Connect.Entities;

public class linkRelacionadoActividadesPIDEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public int InIdActividadPID { get; set; }
    public string? Nombre_Link { get; set; }
    public string? Link { get; set; }
}
