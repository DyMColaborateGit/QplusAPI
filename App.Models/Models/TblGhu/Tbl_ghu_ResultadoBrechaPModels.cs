
namespace App.Models.Models.TblGhu
{
    public class Tbl_ghu_ResultadoBrechaPModels
    {
        public int ResultadoBrechaId { get; set; }
        public int EmpresaId { get; set; }
        public int PreguntaId { get; set; }
        public long UsuarioAnalisisBrecha { get; set; }
        public int TipoPregunta { get; set; }
        public int TemaBrecha { get; set; }
        public int RelFuncSolicitudPId { get; set; }
        public int PadreId { get; set; }
        public int HijoId { get; set; }
        public string? TextoPregunta { get; set; }
        public string? TextoSMultiple { get; set; }
        public string? RespuestaAbierta { get; set; }
        public bool ResultadoSMultiple { get; set; }
    }
}
