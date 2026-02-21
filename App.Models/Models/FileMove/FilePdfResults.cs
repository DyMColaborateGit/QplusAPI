
namespace App.Models.Models.FileMove
{
    public class FilePdfResultsModel
    {
        public int? totalRegistros { get; set; }
        public int? noGenerados { get; set; }
        public int? generadosCorrectamente { get; set; }
        public int? noGuardados { get; set; }
        public int? guardadosCorrectamente { get; set; }
        public Boolean? estadoGeneracion { get; set; }
        public List<string>? detalleGenerados { get; set; }
        public List<string>? detalleNoGenerados { get; set; }
        public List<string>? detalleGuardados { get; set; }
        public List<string>? detalleNoGuardados { get; set; }
        public List<string>? Errors { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public int? id { get; set; }
        public string? path { get; set; }
    }
}