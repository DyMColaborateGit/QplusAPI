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
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsPdi(List<FilePdfADIPdiModel> requests);
    Task<FilePdfResultsModel> GetGenerarGuardarPdfsAdi(List<FilePdfADIPdiModel> requests);
    Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz);
}