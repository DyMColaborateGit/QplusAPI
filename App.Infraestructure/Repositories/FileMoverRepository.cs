using System;
using System.Formats.Tar;
using System.IO;
using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.FileMove;
using AutoMapper;
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
    public async Task<FileResultModels> PostMoverArchivo(FileMoveModels fileMove)
    {
        try
        {
            if (string.IsNullOrEmpty(fileMove.Origen) || string.IsNullOrEmpty(fileMove.Destino) || string.IsNullOrEmpty(fileMove.RutaUserFiles) || string.IsNullOrEmpty(fileMove.Ancla1) || string.IsNullOrEmpty(fileMove.Ancla2) || string.IsNullOrEmpty(fileMove.Ancla3) || string.IsNullOrEmpty(fileMove.Ancla4))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "Error",
                    message = "Los parámetros 'origen', 'destino', 'ancla1', 'ancla2', 'nombreArchivo', 'ancla3', 'ancla4' y 'rutaBase' son obligatorios."
                };
            }

            // Ruta Servidor Local
            string _rutaLocal = fileMove.RutaUserFiles;

            string _folderA = fileMove.Origen;
            string _folderB = fileMove.Destino;

            //TODO crear la ruta absoluta del servidor para la gestion de archivos
            string origen = _rutaLocal + _folderA;
            string destino = _rutaLocal + _folderB;

            string ancla1 = fileMove.Ancla1;
            string ancla2 = fileMove.Ancla2;
            string ancla3 = fileMove.Ancla3;
            string ancla4 = fileMove.Ancla4;

            // Validar que el nombre del archivo no esté vacío
            if (string.IsNullOrEmpty(fileMove.Nombre))
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

            string extension = Path.GetExtension(fileMove.Nombre);
            string nomFile = ancla1 + "_" + ancla2 + "_" + ancla3 + "_" + ancla4 + extension;

            string nombreArchivo = $"{nomFile}";

            string rutaOriginal = _rutaLocal + "\\" + _folderA + "\\" + fileMove.Nombre;
            string rutaFinal = _rutaLocal + "\\" + _folderB + "\\" + nombreArchivo;
            var rutaCompleta = Path.Combine(rutaFinal);


            if (!System.IO.File.Exists(rutaOriginal))
            {
                return new FileResultModels
                {
                    success = false,
                    status = "NotFound",
                    message = $"El archivo '{fileMove.Nombre}' no fue encontrado en la carpeta origen.",
                    fileName = nombreArchivo
                };
            }

            await Task.Run(() => System.IO.File.Move(rutaOriginal, rutaFinal));

            return new FileResultModels
            {
                success = true,
                status = "Success",
                message = $"El archivo '{nombreArchivo}' fue movido correctamente.",
                fileName = nombreArchivo
            };
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("PostMoverArchivo", ex, fileMove.Nombre);
            throw;
        }
    }
}