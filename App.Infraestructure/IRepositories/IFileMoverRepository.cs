using App.Infraestructure.Repositories;
using App.Models.Models.FileMove;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App.Infraestructure.IRepositories;

public interface IFileMoverRepository
{
    Task<FilePdfResultsModel> PostMoverArchivo(List<FileMoveModels> fileMove);
    Task<FilePdfResultsModel> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs);
    Task<FilePdfResultsModel> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfs(List<FilePdfADIPdiModel> requests, string rutaFinal);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsADI(List<FilePdfADIPdiModel> requests, string rutaFinal);
    Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz);
    Task<FileResultModels> PostCrearPDFADI(List<FilePdfADIPdiModel> PdfADI);
}