
namespace App.logic.IServices;
public interface IFileMoverService
{
    Task<string> PostMoverArchivo(string NombreArchivo);
}
