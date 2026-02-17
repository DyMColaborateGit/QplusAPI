
using App.Models.Models.FileMove;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App.logic.IServices;
public interface IFileMoverService
{
    Task<FilePdfResultsModel> PostMoverArchivo(List<FileMoveModels> fileMove);
    Task<FilePdfResultsModel> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs);
    Task<FilePdfResultsModel> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsPdi(List<FilePdfADIPdiModel> requests);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsAdi(List<FilePdfADIPdiModel> requests);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
    Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz);
}
