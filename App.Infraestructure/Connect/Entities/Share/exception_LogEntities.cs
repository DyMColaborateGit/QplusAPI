using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.Share;

public class Exception_LogEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LogId { get; set; }

    public string? Metodo { get; set; }

    public string? Aplicacion { get; set; }

    public string? ExceptionString { get; set; }

    public string? Observacion { get; set; }

    public int Anio { get; set; }

    public DateTime FechaLog { get; set; }
}
