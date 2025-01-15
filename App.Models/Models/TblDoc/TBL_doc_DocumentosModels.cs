using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Models.TblDoc
{
    public class TBL_doc_DocumentosModels
    {
        public int DocumentoId { get; set; }
        public string? NombreDoc { get; set; }
        public int InIdSistema { get; set; }
        public int EmpresaId { get; set; }
        public int Consecutivo { get; set; }
        public string? CodigoDoc { get; set; }
        public int IdTipo { get; set; }
        public int proceso_doc { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? NumeroActualizacion { get; set; }
        public int ElaboradoPor { get; set; }
        public int RevisadoPor { get; set; }
        public int AprobadoPor { get; set; }
        public bool? BCumple { get; set; }
        public int Responsable { get; set; }
        public int? DocumentoIdPadre { get; set; }
        public string? UrlFormato { get; set; }
        public string? Estado { get; set; }
        public string? Historial { get; set; }
        public DateTime? FechaFlujoIni { get; set; }
        public DateTime? FechaFlujoFin { get; set; }
        public int? InDiasRetraso { get; set; }
        public int NivelSeguridad { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdArea { get; set; }
        public bool? EstadoCarga { get; set; }
        public string? RazonObsoleto { get; set; }
        public DateTime? FechaEnvioObsoleto { get; set; }
        public long? UsuarioEnvioObsoleto { get; set; }
        public DateTime? FechaDevolucionVigente { get; set; }
        public long? UsuarioDevolucionVigente { get; set; }
    }

    public class ResponseTBL_doc_DocumentosModels
    {
        public int DocumentoId { get; set; }
        public string? NombreDoc { get; set; }
        public int InIdSistema { get; set; }
        public int EmpresaId { get; set; }
        public int Consecutivo { get; set; }
        public string? CodigoDoc { get; set; }
        public int IdTipo { get; set; }
        //public int ProcesoDoc { get; set; }
        public int? proceso_doc { get; set; }
        public SCP_ProcesosModels? ProcesosObj { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? NumeroActualizacion { get; set; }
        public int ElaboradoPor { get; set; }
        public int RevisadoPor { get; set; }
        public int AprobadoPor { get; set; }
        public bool? BCumple { get; set; }
        public int Responsable { get; set; }
        public int? DocumentoIdPadre { get; set; }
        public string? UrlFormato { get; set; }
        public string? Estado { get; set; }
        public string? Historial { get; set; }
        public DateTime? FechaFlujoIni { get; set; }
        public DateTime? FechaFlujoFin { get; set; }
        public int? InDiasRetraso { get; set; }
        public int NivelSeguridad { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdArea { get; set; }
        public bool? EstadoCarga { get; set; }
        public string? RazonObsoleto { get; set; }
        public DateTime? FechaEnvioObsoleto { get; set; }
        public long? UsuarioEnvioObsoleto { get; set; }
        public DateTime? FechaDevolucionVigente { get; set; }
        public long? UsuarioDevolucionVigente { get; set; }
    }
}
