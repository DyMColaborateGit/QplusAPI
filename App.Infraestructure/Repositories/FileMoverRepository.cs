using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using AutoMapper;
using App.Models.Models.FileMove;
using System.Formats.Tar;

namespace App.Infraestructure.Repositories;

public class FileMoverRepository : IFileMoverRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public FileMoverRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<FileResultModels> PostMoverArchivo(FileMoveModels fileMove)
    {
        try
        {
            // Ruta Servidor Local
            string _rutaLocal = fileMove.rutaUserFile;
            // Ruta Servidor Web
            //string _rutaLocal = @"C:\Users\DYMDesarrollo\Desktop\CODE\QPLUS\Qplus-Nube\ISOftware.WebApp\UserFiles\";

            string _folderA = fileMove.origen;
            string _folderB = fileMove.destino;

            //TODO crear la ruta absoluta del servidor para la gestion de archivos
            string origen = _rutaLocal + _folderA;
            string destino = _rutaLocal + _folderB;

            string ancla1 = fileMove.ancla1;
            string ancla2 = fileMove.ancla2;
            string ancla3 = fileMove.ancla3;
            string ancla4 = fileMove.ancla4;

            // Validar que el nombre del archivo no esté vacío
            if (string.IsNullOrEmpty(fileMove.nombre))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "BadRequest",
                    message = "El nombre del archivo está vacío."
                };
            }

            if (!Directory.Exists(origen))
            {
                Directory.CreateDirectory(origen);
            }

            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }

            string extension = Path.GetExtension(fileMove.nombre);
            string nomFile = ancla1 + "_" + ancla2 + "_" + ancla3 + "_" + ancla4 + extension;

            string nombreArchivo = $"{nomFile}";

            string rutaOriginal = origen + "/" + fileMove.nombre;
            string rutaFinal = destino + "/" + nombreArchivo;

            if (!System.IO.File.Exists(rutaOriginal))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "NotFound",
                    message = $"El archivo '{fileMove.nombre}' no fue encontrado en la carpeta origen."
                };
            }

            await Task.Run(() => System.IO.File.Move(rutaOriginal, rutaFinal));

            return new FileResultModels
            {
                success = true,
                status = "Success",
                message = $"El archivo '{nombreArchivo}' fue movido correctamente."
            };
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("PostMoverArchivo", ex, fileMove.nombre);
            throw;
        }
    }
}