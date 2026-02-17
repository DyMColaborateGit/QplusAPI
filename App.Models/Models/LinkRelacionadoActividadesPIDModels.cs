
namespace App.Models.Models;
public class LinkRelacionadoActividadesPIDModels
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public int InIdActividadPID { get; set; }
    public string? Nombre_Link { get; set; }
    public string? Link { get; set; }
}
