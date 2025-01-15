using System;

namespace App.Models.Models.Scp
{
    public class SCP_ProcesosModels
    {
        public int Id_Proceso { get; set; }
        public int EmpresaId { get; set; }
        public int? Id_Area { get; set; }
        public string? Proceso { get; set; }
        public string? Sigla { get; set; }
        public int Id_Cargo { get; set; }
        public string? Descripcion { get; set; }
        public string? Mision { get; set; }
        public string? Estado { get; set; }
        public string? Codigo_Mapa { get; set; }
        public int Consecutivo_Mapa { get; set; }
        public int Certificado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int ElaboradoPor { get; set; }
        public int AprobadoPor { get; set; }
        public bool? Generico { get; set; }
    }
}
