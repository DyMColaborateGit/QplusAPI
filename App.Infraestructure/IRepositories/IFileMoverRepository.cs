using System.IO;
using App.Models.Models.FileMove;

namespace App.Infraestructure.IRepositories;

public interface IFileMoverRepository
{
    Task<FileResultModels> PostMoverArchivo(FileMoveModels fileMove);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
}