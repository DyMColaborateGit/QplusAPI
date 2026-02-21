namespace App.Models.Models.FileMove
{
    public class FolderPdfStatsModel
    {
        public string? FolderName { get; set; }
        public string? FullPath { get; set; }
        public string? rootPath { get; set; }
        public string? customPath { get; set; }
        public int?  PdfCount { get; set; }
        public long? TotalSize { get; set; } // Opcional: tamaño en bytes
    }
}
