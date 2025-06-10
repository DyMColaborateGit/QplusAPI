
namespace App.Models.Models.TblGhu
{
    public class Tbl_ghu_PreguntasBrechaPModels
    {
        public int PreguntaId { get; set; }
        public int EmpresaId { get; set; }
        public string? Pregunta { get; set; }
        public int TipoPregunta { get; set; }
        public int TemaBrechaId { get; set; }
        public bool Estado { get; set; }
        public int Orden { get; set; }
    }
}
