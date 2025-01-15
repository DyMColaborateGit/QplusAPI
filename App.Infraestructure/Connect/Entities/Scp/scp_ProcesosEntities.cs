using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Infraestructure.Connect.Entities.TblAud;
using App.Infraestructure.Connect.Entities.TblDoc;

namespace App.Infraestructure.Connect.Entities.Scp;

public class scp_ProcesosEntities
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id_Proceso { get; set; }
    public int EmpresaId { get; set; }
    public int? Id_Area { get; set; }
    public required string Proceso { get; set; }
    public required string Sigla { get; set; }
    public int Id_Cargo { get; set; }
    public required string Descripcion { get; set; }
    public required string Mision { get; set; }
    public required string Estado { get; set; }
    public required string Codigo_Mapa { get; set; }
    public int Consecutivo_Mapa { get; set; }
    public int Certificado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public int ElaboradoPor { get; set; }
    public int AprobadoPor { get; set; }
    public bool? Generico { get; set; }
    public ICollection<auditoriasEntities>? Auditorias { get; set; }
    public ICollection<tbl_doc_DocumentosEntities>? TBL_Doc_Documentos { get; set; }


}
