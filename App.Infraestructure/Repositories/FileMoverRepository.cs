using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.FileMove;
using App.Models.Models.TblCom;
using App.Models.Models.TblDoc;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Infraestructure.Repositories
{
    public class FileMoverRepository : IFileMoverRepository
    {
        private readonly ConnectContext _context;
        private readonly IConverter _converter;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IProgEvaluacionRepository _progevaluacionRepository;
        private static readonly object _pdfLock = new object();

        public FileMoverRepository(ConnectContext context, IMapper mapper, IConverter converter, IWebHostEnvironment environment, IProgEvaluacionRepository progevaluacionRepository
         )
        {
            _context = context;
            _mapper = mapper;
            _converter = converter;
            _environment = environment;
            _progevaluacionRepository = progevaluacionRepository;
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
                        message = "Los parámetros 'Origen', 'Nombre' y 'RutaUserFiles' son obligatorios."
                    };
                }

                string _rutaLocal = fileCheck.RutaUserFiles switch
                {
                    "controlados" => @"F:\CODE\DYM\PLATAFORMA_1.0\Qplus-Nube\ISOftware.WebApp\UserFiles\",
                    "proveedores" => @"F:\CODE\DYM\PLATAFORMA_1.0\Qplus-Nube\ISOftware.WebApp\UserFiles\Documentos\",
                    "clientes" => @"F:\CODE\DYM\PLATAFORMA_1.0\Qplus-Nube\ISOftware.WebApp\UserFiles\Documentos\",
                    _ => fileCheck.RutaUserFiles, // Mantener original si no coincide con los alias
                };

                var rutaCompleta = Path.Combine(_rutaLocal, fileCheck.Origen, fileCheck.Nombre);

                if (System.IO.File.Exists(rutaCompleta))
                {
                    return new FileResultModels
                    {
                        success = true,
                        status = "Success",
                        message = $"El archivo '{fileCheck.Nombre}' sí existe.",
                        fileName = fileCheck.Nombre
                    };
                }

                return new FileResultModels
                {
                    success = false,
                    status = "NotFound",
                    message = $"El archivo '{fileCheck.Nombre}' no existe.",
                    fileName = fileCheck.Nombre
                };
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("CheckFileExists", ex, fileCheck.Nombre);
                return new FileResultModels { success = false, status = "Error", message = ex.Message };
            }
        }

        public async Task<FilePdfResultsModel> PostMoverArchivo(List<FileMoveModels> allFiles)
        {
            var result = new FilePdfResultsModel
            {
                totalRegistros = allFiles?.Count ?? 0,
                detalleGuardados = new List<string>(),
                detalleNoGuardados = new List<string>(),
                Errors = new List<string>()
            };

            if (allFiles == null || allFiles.Count == 0)
            {
                result.totalRegistros = 0;
                result.detalleGuardados = new List<string>();
                result.detalleNoGuardados = new List<string>();
                result.Errors.Add("La lista de archivos está vacía.");
            }

            foreach (var fileMove in allFiles)
            {
                var individualResult = await PostMoverDataArchivo(fileMove);
                if (individualResult.success)
                {
                    result.guardadosCorrectamente++;
                    result.detalleGuardados.Add(individualResult.fileName);
                }
                else
                {
                    result.noGuardados++;
                    result.detalleNoGuardados.Add($"{individualResult.fileName}: {individualResult.message}");
                }
            }

            result.estadoGeneracion = true;
            result.status = result.noGuardados == 0 ? "Success" : "PartialContent";
            result.message = "Proceso de movimiento finalizado.";
            return result;
        }

        public async Task<FileResultModels> PostMoverDataArchivo(FileMoveModels fileMove)
        {
            try
            {
                string extension = Path.GetExtension(fileMove.Nombre);
                string nomFile = $"{fileMove.Ancla1}_{fileMove.Ancla2}_{fileMove.Ancla3}_{fileMove.Ancla4}{extension}";

                if (string.IsNullOrEmpty(fileMove.Origen) || string.IsNullOrEmpty(fileMove.Destino) || string.IsNullOrEmpty(fileMove.Nombre))
                {
                    return new FileResultModels { success = false, status = "Warning", message = "Parámetros incompletos", fileName = nomFile };
                }

                var rutaOrigen = Path.Combine(fileMove.RutaUserFiles, fileMove.Origen, fileMove.Nombre);
                var rutaDestinoFolder = Path.Combine(fileMove.RutaUserFiles, fileMove.Destino);
                var rutaFinal = Path.Combine(rutaDestinoFolder, nomFile);

                if (!Directory.Exists(rutaDestinoFolder)) Directory.CreateDirectory(rutaDestinoFolder);

                if (System.IO.File.Exists(rutaOrigen))
                {
                    // Si el destino ya existe, lo borramos o manejamos según lógica de negocio
                    if (System.IO.File.Exists(rutaFinal)) System.IO.File.Delete(rutaFinal);

                    await Task.Run(() => System.IO.File.Move(rutaOrigen, rutaFinal));
                    await UpdateDocumentos(fileMove.id, 1);

                    return new FileResultModels { success = true, status = "Success", fileName = nomFile };
                }
                else
                {
                    await UpdateDocumentos(fileMove.id, 2);
                    return new FileResultModels { success = false, status = "Warning", message = "Archivo origen no encontrado", fileName = nomFile };
                }
            }
            catch (Exception ex)
            {
                return new FileResultModels { success = false, status = "Error", message = ex.Message, fileName = fileMove.Nombre };
            }
        }
        
        public async Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz)
        {
            try
            {
                string carpeta = Path.Combine(_environment.ContentRootPath, "wwwroot", "LogosEmpresas");
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                if (!System.IO.File.Exists(rutaCompleta))
                {
                    return new FileResultModels { success = false, status = "NotFound", message = "La imagen no existe." };
                }

                byte[] bytes = await System.IO.File.ReadAllBytesAsync(rutaCompleta);
                string extension = Path.GetExtension(nombreArchivo).ToLower();
                string tipoMime = extension == ".png" ? "image/png" : "image/jpeg";
                string base64 = Convert.ToBase64String(bytes);

                return new FileResultModels
                {
                    success = true,
                    status = "Success",
                    fileName = nombreArchivo,
                    data = $"data:{tipoMime};base64,{base64}"
                };
            }
            catch (Exception ex)
            {
                return new FileResultModels { success = false, status = "Error", message = ex.Message };
            }
        }

        public async Task<TBL_doc_DocumentosModels> UpdateDocumentos(int docId, int existe)
        {
            var registro = _context.TBL_doc_Documentos.FirstOrDefault(p => p.DocumentoId == docId);
            if (registro != null)
            {
                registro.ArchivoEliminadoApp = existe;
                await _context.SaveChangesAsync();
            }
            return new TBL_doc_DocumentosModels { DocumentoId = docId };
        }
       
        public async Task<FilePdfResultsModel> PostPdfArchivos(List<FilePdfADIPdiModel> allFiles)
        {
            var result = new FilePdfResultsModel
            {
                totalRegistros = allFiles?.Count ?? 0,
                detalleGuardados = new List<string>(),
                detalleNoGuardados = new List<string>(),
                Errors = new List<string>()
            };

            if (allFiles == null || allFiles.Count == 0)
            {
                result.totalRegistros = 0;
                result.detalleGuardados = new List<string>();
                result.detalleNoGuardados = new List<string>();
                result.Errors.Add("La lista de archivos está vacía.");
            }

            foreach (var fileMove in allFiles)
            {
                // Este método simula el guardado de un PDF ya existente o buffer
                var individualResult = await PostGuardarPdfDataArchivo(fileMove);
                if (individualResult.estadoGeneracion == true)
                {
                    result.guardadosCorrectamente++;
                    result.detalleGuardados.Add(fileMove.FileName);
                }
                else
                {
                    result.noGuardados++;
                    result.detalleNoGuardados.Add($"{fileMove.FileName}: {individualResult.message}");
                }
            }

            result.estadoGeneracion = result.noGuardados == 0;
            result.status = result.noGuardados == 0 ? "Success" : "PartialContent";
            return result;
        }

        public async Task<FilePdfResultsModel> PostGuardarPdfDataArchivo(FilePdfADIPdiModel fileMove)
        {
            var result = new FilePdfResultsModel
            {
                totalRegistros = 1,
                detalleGenerados = new List<string>(),
                detalleNoGenerados = new List<string>(),
                Errors = new List<string>()
            };

            try
            {
                if (string.IsNullOrEmpty(fileMove.FileName) || string.IsNullOrEmpty(fileMove.FolderPath))
                {
                    result.noGenerados++;
                    result.detalleNoGenerados.Add($"{fileMove.FileName}");
                    result.Errors.Add($"{fileMove.FileName}" + ", No encontrado");
                }

                if (!Directory.Exists(fileMove.FolderPath)) Directory.CreateDirectory(fileMove.FolderPath);
                string rutaFinal = Path.Combine(fileMove.FolderPath, fileMove.FileName);

                result.estadoGeneracion = true;
                result.status = result.noGenerados == 0 ? "Success" : "PartialContent";
                result.message = "Proceso de generación de PDFs finalizado.";
                return result;
            }
            catch (Exception ex)
            {
                result.estadoGeneracion = false;
                result.status = "Error";
                result.message = ex.Message;
                return result;
            }
        }

        public async Task<FilePdfResultsModel> GetGenerarGuardarPdfsPdi(List<FilePdfADIPdiModel> pdiAdiObjs)
        {
            var result = new FilePdfResultsModel
            {
                totalRegistros = pdiAdiObjs.Count,
                detalleGenerados = new List<string>(),
                detalleNoGenerados = new List<string>(),
                detalleGuardados = new List<string>(),
                detalleNoGuardados = new List<string>(),
                Errors = new List<string>(),

                generadosCorrectamente = 0,
                guardadosCorrectamente = 0,
                noGenerados = 0,
                noGuardados = 0,
                estadoGeneracion = false
            };

            foreach (var request in pdiAdiObjs)
            {
                try
                {
                    AsegurarEstructuraDirectorios(request.FolderPath);

                    string savedPath = GenerarYGuardarArchivoFisico(request);

                    result.generadosCorrectamente++;
                    result.guardadosCorrectamente++;
                    result.detalleGenerados.Add(request.FileName);
                    result.detalleGuardados.Add(request.FileName);
                    result.path = savedPath;
                }
                catch (Exception ex)
                {
                    result.noGenerados++;
                    result.noGuardados++;
                    result.detalleNoGenerados.Add($"{request.FileName}");
                    result.detalleNoGuardados.Add($"{request.FileName}");
                    result.Errors.Add($"{request.FileName}: {ex.Message}");
                }
            }

            result.estadoGeneracion = true;
            result.status = result.noGenerados == 0 ? "Success" : "PartialContent";
            result.message = "Proceso de generación de PDFs finalizado.";

            return result;
        }
        
        public async Task<FilePdfResultsModel> GetGenerarGuardarPdfsAdi(List<FilePdfADIPdiModel> pdiAdiObjs)
        {
            var result = new FilePdfResultsModel
            {
                totalRegistros = pdiAdiObjs.Count,
                detalleGenerados = new List<string>(),
                detalleNoGenerados = new List<string>(),
                detalleGuardados = new List<string>(),
                detalleNoGuardados = new List<string>(),
                Errors = new List<string>(),

                generadosCorrectamente = 0,
                guardadosCorrectamente = 0,
                noGenerados = 0,
                noGuardados = 0,
                estadoGeneracion = false
            };

            foreach (var request in pdiAdiObjs)
            {
                try
                {
                    if (request.Evaluacion != null)
                    {
                        request.BodyHtml = await _progevaluacionRepository.GeneradorBodyADIByEvaluacionId(request);
                    }
                    else
                    {
                        request.BodyHtml = "No hay datos de la Evaluacion";
                    }

                    AsegurarEstructuraDirectorios(request.FolderPath);

                    string savedPath = GenerarYGuardarArchivoFisico(request);

                    result.generadosCorrectamente++;
                    result.guardadosCorrectamente++;
                    result.detalleGenerados.Add(request.FileName);
                    result.detalleGuardados.Add(request.FileName);
                    result.path = savedPath;
                }
                catch (Exception ex)
                {
                    result.noGenerados++;
                    result.noGuardados++;
                    result.detalleNoGenerados.Add($"{request.FileName}");
                    result.detalleNoGuardados.Add($"{request.FileName}");
                    result.Errors.Add($"{request.FileName}: {ex.Message}");
                }
            }

            result.estadoGeneracion = true;
            result.status = result.noGenerados == 0 ? "Success" : "PartialContent";
            result.message = "Proceso de generación de PDFs finalizado.";

            return result;
        }

        private void AsegurarEstructuraDirectorios(string ruta)
        {
            if (string.IsNullOrEmpty(ruta)) return;

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
        }

        public string GenerarYGuardarArchivoFisico(FilePdfADIPdiModel request)
        {
            string fileName = request.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)
                ? request.FileName
                : request.FileName + ".pdf";

            // Usamos nombres únicos para los temporales
            string tempId = Guid.NewGuid().ToString();
            string headerTempPath = Path.Combine(Path.GetTempPath(), $"{tempId}_header.html");
            string footerTempPath = Path.Combine(Path.GetTempPath(), $"{tempId}_footer.html");

            try
            {
                // 1. Escribir temporales solo si es estrictamente necesario
                if (!string.IsNullOrEmpty(request.HeaderHtml))
                    File.WriteAllText(headerTempPath, PrepararContenedorHtml(request.HeaderHtml));

                if (!string.IsNullOrEmpty(request.FooterHtml))
                    File.WriteAllText(footerTempPath, PrepararContenedorHtml(request.FooterHtml, incluirScriptPaginas: true));

                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 25, Bottom = 25, Left = 10, Right = 10 }
                },
                    Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = request.BodyHtml,
                        WebSettings = { DefaultEncoding = "utf-8", Background = true },
                        HeaderSettings = { 
                            // Importante: file:/// es necesario para rutas locales
                            HtmlUrl = !string.IsNullOrEmpty(request.HeaderHtml) ? headerTempPath : null,
                            Spacing = 10
                        },
                        FooterSettings = {
                            HtmlUrl = !string.IsNullOrEmpty(request.FooterHtml) ? footerTempPath : null,
                            Spacing = 10
                        }
                    }
                }
                };

                byte[] pdfBytes;

                // 2. SECCIÓN CRÍTICA: El motor de WkHtmlToPdf NO es thread-safe
                lock (_pdfLock)
                {
                    pdfBytes = _converter.Convert(doc);
                }

                // 3. Asegurar directorio de salida
                if (!Directory.Exists(request.FolderPath))
                    Directory.CreateDirectory(request.FolderPath);

                string fullOutputPath = Path.Combine(request.FolderPath, fileName);

                // 4. Escritura atómica
                File.WriteAllBytes(fullOutputPath, pdfBytes);

                return fullOutputPath;
            }
            catch (Exception ex)
            {
                // Loguear el error específico aquí
                throw new Exception($"Error generando PDF {request.FileName}: {ex.Message}", ex);
            }
            finally
            {
                // 5. Limpieza agresiva de temporales
                EliminarArchivoTemporal(headerTempPath);
                EliminarArchivoTemporal(footerTempPath);
            }
        }

        private string PrepararContenedorHtml(string htmlFragmento, bool incluirScriptPaginas = false)
        {
            // Script para inyectar números de página en elementos con clases específicas
            string scriptPaginacion = incluirScriptPaginas ? @"
            <script>
            function subst() {
                var vars = {};
                var query_strings_from_url = document.location.search.substring(1).split('&');
                for (var query_string in query_strings_from_url) {
                    var cas = query_strings_from_url[query_string].split('=', 2);
                    vars[cas[0]] = decodeURI(cas[1]);
                }
                var css_selector_classes = ['page', 'frompage', 'topage', 'webpage', 'section', 'subsection', 'date', 'isodate', 'time', 'title', 'doctitle', 'sitepage', 'sitepages'];
                for (var css_class in css_selector_classes) {
                    var elements = document.getElementsByClassName(css_selector_classes[css_class]);
                    for (var j = 0; j < elements.length; ++j) {
                        elements[j].textContent = vars[css_selector_classes[css_class]];
                    }
                }
            }
            </script>" : "";

            string bodyAttr = incluirScriptPaginas ? "onload='subst()'" : "";

            return $@"<!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8'>
                    {scriptPaginacion}
                    <style>
                        body {{ margin: 0; padding: 18px 0px 0px 0px; font-family: sans-serif; font-size: 12px; }}
                        .page-number-container {{ text-align: right; width: 100%; }}
                    </style>
                </head>
                <body {bodyAttr}>
                    {htmlFragmento}
                </body>
                </html>";
        }

        private void EliminarArchivoTemporal(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); } catch { }
        }

        public string GenerarGuardarPdf(FilePdfADIPdiModel request)
        {
            string fileName = request.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ? request.FileName : request.FileName + ".pdf";
            string headerTempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_header.html");
            string footerTempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_footer.html");

            try
            {
                if (!string.IsNullOrEmpty(request.HeaderHtml))
                {
                    File.WriteAllText(headerTempPath, PrepararContenedorHtml(request.HeaderHtml));
                }

                // Al preparar el Footer, inyectamos soporte para las clases de numeración automática
                if (!string.IsNullOrEmpty(request.FooterHtml))
                {
                    File.WriteAllText(footerTempPath, PrepararContenedorHtml(request.FooterHtml, incluirScriptPaginas: true));
                }

                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 25, Bottom = 25, Left = 10, Right = 10 }
                },
                    Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = request.BodyHtml,
                        WebSettings = { DefaultEncoding = "utf-8", Background = true },
                        HeaderSettings = {
                            HtmlUrl = !string.IsNullOrEmpty(request.HeaderHtml) ? new Uri(headerTempPath).AbsoluteUri : null,
                            Spacing = 10
                        },
                        FooterSettings = {
                            HtmlUrl = !string.IsNullOrEmpty(request.FooterHtml) ? new Uri(footerTempPath).AbsoluteUri : null,
                            Spacing = 10,
                        }
                    }
                }
                };

                byte[] pdfBytes = _converter.Convert(doc);

                if (!Directory.Exists(request.FolderPath))
                    Directory.CreateDirectory(request.FolderPath);

                string fullOutputPath = Path.Combine(request.FolderPath, fileName);
                File.WriteAllBytes(fullOutputPath, pdfBytes);

                return fullOutputPath;
            }
            finally
            {
                EliminarArchivoTemporal(headerTempPath);
                EliminarArchivoTemporal(footerTempPath);
            }
        }

        public async Task<byte[]> GetZipFolderStreamAsync(string carpetaPath)
        {
            if (!Directory.Exists(carpetaPath))
                throw new DirectoryNotFoundException("La carpeta no existe.");

            var files = Directory.GetFiles(carpetaPath, "*.pdf");
            if (!files.Any())
                throw new FileNotFoundException("No hay archivos PDF para comprimir.");

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var filePath in files)
                    {
                        var fileName = Path.GetFileName(filePath);
                        var entry = archive.CreateEntry(fileName, CompressionLevel.Optimal);
                        using (var entryStream = entry.Open())
                        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            await fileStream.CopyToAsync(entryStream);
                        }
                    }
                }
                return memoryStream.ToArray();
            }
        }

        public async Task<List<FolderPdfStatsModel>> GetUserFilesFolderPdfsStats([FromBody] FolderPdfStatsModel rutasDescarga)
        {
            if (rutasDescarga == null || string.IsNullOrWhiteSpace(rutasDescarga.FullPath))
            {
                return new List<FolderPdfStatsModel>();
            }

            return await Task.Run(() =>
            {
                var result = new List<FolderPdfStatsModel>();
                string targetPath = rutasDescarga.FullPath;

                try
                {
                    if (!Directory.Exists(targetPath))
                    {
                        return result;
                    }

                    var directories = Directory.GetDirectories(targetPath);

                    foreach (var dir in directories)
                    {
                        try
                        {
                            var dirInfo = new DirectoryInfo(dir);
                            var pdfFiles = dirInfo.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);

                            result.Add(new FolderPdfStatsModel
                            {
                                FolderName = dirInfo.Name,
                                FullPath = dirInfo.FullName,
                                PdfCount = pdfFiles.Length,
                                TotalSize = pdfFiles.Sum(f => f.Length)
                            });
                        }
                        catch (UnauthorizedAccessException)
                        {
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Loggear el error (ex) según tu sistema de logs
                    // Por ahora retornamos lo que hayamos alcanzado a procesar
                }

                return result;
            });
        }

        public byte[] GetFolderAsByteArray(string folderPath)
        {
            // Validación básica de existencia
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                // Podrías lanzar una excepción personalizada aquí si el contexto lo requiere
                return Array.Empty<byte>();
            }

            using (var memoryStream = new MemoryStream())
            {
                // Creamos el archivo ZIP en el MemoryStream
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var directoryInfo = new DirectoryInfo(folderPath);
                    FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);

                    foreach (var file in files)
                    {
                        // Calculamos la ruta relativa para no incluir la ruta absoluta del servidor en el ZIP
                        string relativePath = Path.GetRelativePath(folderPath, file.FullName);
                        var entry = archive.CreateEntry(relativePath);

                        using (var entryStream = entry.Open())
                        using (var fileStream = file.OpenRead())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    }
                }

                // Es fundamental retornar ToArray() fuera del bloque 'using' de ZipArchive 
                // para asegurar que el archivo se haya cerrado y flasheado correctamente.
                return memoryStream.ToArray();
            }
        }
    }
}