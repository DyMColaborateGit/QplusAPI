using App.Infraestructure.IRepositories;
using App.logic.IServices;

namespace App.logic.Services;

public class FileMoverService : IFileMoverService
{
    private readonly IFileMoverRepository _fileMoverRepository;

    public FileMoverService(IFileMoverRepository fileMoverRepository)
    {
        _fileMoverRepository = fileMoverRepository;
    }

    public async Task<string> PostMoverArchivo(string NombreArchivo)
    {
        return await _fileMoverRepository.PostMoverArchivo(NombreArchivo);
    }

}
