namespace App.Models.Models.TblGhu
{
    public class Tbl_ghu_RelFuncSolicitudPModels
    {
        public int RelFuncSolicitudPId { get; set; }
        public int EmpresaId { get; set; }
        public long Identificacion { get; set; }
        public int SolicitudId { get; set; }
        public bool Brecha { get; set; }
        public string? TextoBrecha { get; set; }
        public long UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
