
namespace App.Models.Models.FileMove
{
    public class FileResultModels
    {
        public bool Success { get; set; }
        public string? Status { get; set; } // "OK", "NotFound", "BadRequest"
        public string? Message { get; set; }
        public string? FileName { get; set; }
    }
}
