
using Microsoft.AspNetCore.Http;

namespace App.Models.Models.FileMove
{
    public class FilePdfADIPdiModel
    {
        public string?Ccliente { get; set; }
        public string? FileName { get; set; }
        public string? FolderPath { get; set; }
        public string? HeaderHtml { get; set; }
        public string? BodyHtml { get; set; }
        public string? FooterHtml { get; set; }
        public string? Mensaje { get; set; }
    }
}
