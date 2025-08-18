
namespace App.Models.Models.FileMove
{
    public class FileMoveModels
    {
        public int id { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public string? Ancla1 { get; set; }
        public int? Ancla2 { get; set; }
        public int? Ancla3 { get; set; }
        public int? Ancla4 { get; set; }
        public string? Nombre { get; set; }
        public string? Mensaje { get; set; }
        public string? RutaUserFiles { get; set; }
    }
}
