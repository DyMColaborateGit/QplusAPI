
namespace App.Models.Models.TblRgp
{
    public class Tbl_rgp_ControlesModels
    {
        public int IdControl { get; set; }
        public int EmpresaId { get; set; }
        public int IdRiesgo { get; set; }
        public string? Control { get; set; }
        public int IdTipoControl { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdEvaluacion { get; set; }
    }
}
