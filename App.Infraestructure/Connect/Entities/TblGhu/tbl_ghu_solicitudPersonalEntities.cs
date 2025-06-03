using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Infraestructure.Connect.Entities.TblGhu;

public class tbl_ghu_solicitudPersonalEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int SolicitudId { get; set; }
    public int EmpresaId { get; set; }
    public long Solicitante { get; set; }
    public int TipoSolicitud { get; set; }
    public string? CargoDigitado { get; set; }
    public int CodigoCargo { get; set; }
    public int CargoJefe { get; set; }
    public bool EstadoSolicitud { get; set; }
    public bool EstadoBrecha { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime FechaSolicitudIngreso { get; set; }
    public int MacroProcesoId { get; set; }
    public int Id_proceso { get; set; }
    public int Id_producto { get; set; }
    public int CantidadPersonasS { get; set; }
    public string? HorarioTrabajo { get; set; }
    public string? SalarioAsignado { get; set; }
    public string? CentroCostos { get; set; }
    public int IdContrato { get; set; }
    public int DuracionVinculacion { get; set; }
    public string? Ciudad { get; set; }
    public string? Requisitos { get; set; }
    public string? Funciones { get; set; }
    public bool SolicitudCorreo { get; set; }
    public bool EquipoComputo { get; set; }
    public bool Portatil { get; set; }
    public bool Escritorio { get; set; }
    public string? Observaciones { get; set; }
    public long UsuarioCreacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public long UsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
