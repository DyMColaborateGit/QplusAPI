
namespace App.Models.Models.FileMove
{
    public class FileResultModels
    {
        public bool success { get; set; }
        public object? data { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? fileName { get; set; }
        public List<string>? Data { get; set; }
        public List<string>? Errors { get; set; }
    }
}
