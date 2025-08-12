
using App.Models.Models.FileMove;
using System.IO;

namespace App.logic.IServices;
public interface IFileMoverService
{
    Task<FileResultModels> PostMoverArchivo(List<FileMoveModels> fileMove);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
}
