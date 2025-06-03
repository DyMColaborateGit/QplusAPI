
namespace App.Models.Models.FileMove
{
    public class FileResultModels
    {
        public bool success { get; set; }
        public string? status { get; set; } // "OK", "NotFound", "BadRequest"
        public string? message { get; set; }
        public string? fileName { get; set; }
    }
}
