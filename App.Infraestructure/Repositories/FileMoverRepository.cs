using System;
using System.Formats.Tar;
using System.IO;
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.FileMove;
using AutoMapper;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

    public async Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck)
    {
        try
        {
            if (string.IsNullOrEmpty(fileCheck.Origen) || string.IsNullOrEmpty(fileCheck.Nombre) || string.IsNullOrEmpty(fileCheck.RutaUserFiles))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "Error",
                    message = "Los parámetros 'carpetaOrigen', 'nombreArchivo' y 'rutaBase' son obligatorios."
                };
            }

            string _rutaLocal = fileCheck.RutaUserFiles;
            string _folderA = fileCheck.Origen;
            string _archivo = fileCheck.Nombre;

            _rutaLocal = fileCheck.RutaUserFiles switch
            {
                "controlados" => "F:\\CODE\\DYM\\PLATAFORMA_1.0\\Qplus-Nube\\ISOftware.WebApp\\UserFiles\\",
                "proveedores" => "F:\\CODE\\DYM\\PLATAFORMA_1.0\\Qplus-Nube\\ISOftware.WebApp\\UserFiles\\Documentos\\",
                "clientes" => "F:\\CODE\\DYM\\PLATAFORMA_1.0\\Qplus-Nube\\ISOftware.WebApp\\UserFiles\\Documentos\\",
                _ => "",
            };
            var rutaCompleta = Path.Combine(_rutaLocal, _folderA, _archivo);
            Console.WriteLine("Ruta completa a verificar: " + rutaCompleta);
            if (System.IO.File.Exists(rutaCompleta))
            {
                return new FileResultModels
                {
                    success = true,
                    status = "Success",
                    message = $"El archivo '{_archivo}' si existe en la ruta especificada.",
                    fileName = _archivo
                };
            }
            else
            {
                return new FileResultModels
                {
                    success = false,
                    status = "NotFound",
                    message = $"El archivo '{_archivo}' no existe en la ruta especificada.",
                    fileName = _archivo
                };
            }
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("CheckFileExists", ex, fileCheck.Nombre);
            throw;
        }
    }

    public async Task<FileResultModels> PostMoverArchivo([FromBody] List<FileMoveModels> allFiles)
    {
        if (allFiles == null || allFiles.Count == 0)
        {
            return new FileResultModels
            {
                success = false,
                status = "BadRequest",
                message = "La lista de archivos está vacía."
            };
        }

        const int batchSize = 100;
        var resultados = new List<object>();

        for (int i = 0; i < allFiles.Count; i += batchSize)
        {
            var batch = allFiles.Skip(i).Take(batchSize).ToList();

            foreach (var fileMove in batch)
            {
                var resultado = await MoverArchivo(fileMove);
                resultados.Add(resultado);
            }
        }
        Console.WriteLine($"Resultados lista: {resultados}");

        return new FileResultModels
        {
            success = true,
            status = "Success",
            message = "Proceso correcto."
        };
    }

    public async Task<FileResultModels> MoverArchivo(FileMoveModels fileMove)
    {
        try
        {
            if (string.IsNullOrEmpty(fileMove.Origen) || string.IsNullOrEmpty(fileMove.Destino) || string.IsNullOrEmpty(fileMove.RutaUserFiles) || string.IsNullOrEmpty(fileMove.Ancla1) || string.IsNullOrEmpty(fileMove.Ancla2) || string.IsNullOrEmpty(fileMove.Ancla3) || string.IsNullOrEmpty(fileMove.Ancla4))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "Error",
                    message = "Los parametros no pueden estar vacios."
                };
            }

            var rutaDirectorioOrigen = Path.Combine(fileMove.RutaUserFiles, fileMove.Origen);
            var rutaDirectorioDestino = Path.Combine(fileMove.RutaUserFiles, fileMove.Destino);

            if (!Directory.Exists(rutaDirectorioOrigen))
            {
                Directory.CreateDirectory(rutaDirectorioOrigen);
            }

            if (!Directory.Exists(rutaDirectorioDestino))
            {
                Directory.CreateDirectory(rutaDirectorioDestino);
            }

            var extension = Path.GetExtension(fileMove.Nombre);
            var nomFile = $"{fileMove.Ancla1}_{fileMove.Ancla2}_{fileMove.Ancla3}_{fileMove.Ancla4}{extension}";

            var rutaOriginal = Path.Combine(rutaDirectorioOrigen, fileMove.Nombre);
            var rutaFinal = Path.Combine(rutaDirectorioDestino, nomFile);

            Console.WriteLine($"Ruta Original: {rutaOriginal}");
            Console.WriteLine($"Ruta Final: {rutaFinal}");

            if (!System.IO.File.Exists(rutaOriginal))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "NotFound",
                    message = "El archivo '{fileMove.Nombre}' no fue encontrado en la carpeta origen.",
                    fileName = nomFile
                };
            }

            // Mueve el archivo
            await Task.Run(() => System.IO.File.Move(rutaOriginal, rutaFinal));

            // Retorna el resultado exitoso
            return new FileResultModels
            {
                success = true,
                status = "Success",
                message = "El archivo '{nomFile}' fue movido correctamente.",
                fileName = nomFile
            };
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("PostMoverArchivo", ex, fileMove.Nombre);
            throw;
        }
    }
}