using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using AutoMapper;
using App.Models.Models.FileMove;

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
            string _folderA = fileMove.Origen;
            string _folderB = fileMove.Destino;
            var basePath = Directory.GetCurrentDirectory(); // Directorio raíz de la app
            var origen = Path.Combine(basePath, _folderA, fileMove.Nombre);
            var destino = Path.Combine(basePath, _folderB, fileMove.Nombre);
            string ancla1 = fileMove.Ancla1;
            string ancla2 = fileMove.Ancla2;
            string ancla3 = fileMove.Ancla3;
            string ancla4 = fileMove.Ancla4;

            // Validar que el nombre del archivo no esté vacío
            if (string.IsNullOrEmpty(fileMove.Nombre))
            {
                return new FileResultModels
                {
                    Success = false,
                    Status = "BadRequest",
                    Message = "Debe proporcionar el nombre del archivo."
                };
            }

            // Asegurarse de que las carpetas existan
            if (!Directory.Exists(_folderA))
            {
                Directory.CreateDirectory(_folderA);
            }

            string extension = Path.GetExtension(fileMove.Nombre);
            // 2. Concatenar nombre del archivo
            string nombreArchivo = $"{ancla1}{ancla2}{ancla3}_{ancla4}{extension}";

            // 3. Construir ruta absoluta a carpeta destino (carpetaB)
            string carpetaDestino = Path.Combine(Directory.GetCurrentDirectory(), "carpetaB");

            // 4. Asegurarse de que la carpeta existe
            if (!Directory.Exists(_folderB))
            {
                Directory.CreateDirectory(_folderB);
            }

            // 5. Ruta final al archivo en carpetaB
            string rutaFinal = Path.Combine(_folderB, nombreArchivo);

            // Verificar si el archivo existe en la carpeta B
            if (!System.IO.File.Exists(rutaFinal))
            {
                return new FileResultModels
                {
                    Success = false,
                    Status = "NotFound",
                    Message = $"El archivo '{fileMove.Nombre}' no fue encontrado."
                };
            }

            // Ruta destino en la carpeta A
            string destFilePath = Path.Combine(_folderA, fileMove.Nombre);

            // Mover el archivo
            await Task.Run(() => System.IO.File.Move(rutaFinal, destFilePath));

            return new FileResultModels
            {
                Success = true,
                Status = "Success",
                Message = $"El archivo '{nombreArchivo}' fue movido correctamente."
            };
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("PostMoverArchivo", ex, fileMove.Nombre);
            throw;
        }
    }
}