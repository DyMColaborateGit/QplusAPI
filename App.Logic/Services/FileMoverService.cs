using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.FileMove;
using System.IO;

namespace App.logic.Services;

public class FileMoverService : IFileMoverService
{
    private readonly IFileMoverRepository _fileMoverRepository;

    public FileMoverService(IFileMoverRepository fileMoverRepository)
    {
        _fileMoverRepository = fileMoverRepository;
    }

    public async Task<FileResultModels> PostMoverArchivo(FileMoveModels fileMove)
    {
        return await _fileMoverRepository.PostMoverArchivo(fileMove);
    }

}