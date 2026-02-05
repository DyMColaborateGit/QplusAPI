using App.Models.Models.FileMove;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App.logic.IServices;
public interface IFileMoverService
{
    Task<FilePdfResultsModel> PostMoverArchivo(List<FileMoveModels> fileMove);
    Task<FileResultModels> PostCrearPDFADI(List<FilePdfADIPdiModel> PdfADI);
    Task<FilePdfResultsModel> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs);
    Task<FilePdfResultsModel> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfs(List<FilePdfADIPdiModel> requests, string rutaFinal);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsADI(List<FilePdfADIPdiModel> requests, string rutaFinal);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
    Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz);
}