
namespace App.Models.Models.TblGhu
{
    public class Tbl_ghu_TextosBrechaModels
    {
        public int TextoBrechaId { get; set; }
        public int EmpresaId { get; set; }
        public string? TextoBrecha { get; set; }
        public bool Estado { get; set; }
        public long UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
