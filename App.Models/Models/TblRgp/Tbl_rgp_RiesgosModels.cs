
namespace App.Models.Models.TblRgp
{
    public class Tbl_rgp_RiesgosModels
    {
        public int IdRiesgo { get; set; }
        public int EmpresaId { get; set; }
        public string? Riesgo { get; set; }
        public string? Descripcion { get; set; }
        public int IdAgente { get; set; }
        public string? Causas { get; set; }
        public string? Efectos { get; set; }
        public int ProcesoId { get; set; }
        public int ClaseId { get; set; }
        public int IdTipoAnalisis { get; set; }
        public bool Estado {  get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int EvaluacionId { get; set; }
        public string? Codigo { get; set; }
        public int Consecutivo { get; set; }
        public int SubprocesoId { get; set; }
    }
}
