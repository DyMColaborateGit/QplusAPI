using App.Infraestructure.Repositories;
using App.Models.Models.FileMove;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App.Infraestructure.IRepositories;

public interface IFileMoverRepository
{
    Task<FileResultModels> PostMoverArchivo(List<FileMoveModels> fileMove);
    Task<FileResultModels> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs);
    Task<FileResultModels> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs);
    Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck);
    Task<FileResultModels> GetGenerarGuardarPdfs(List<FilePdfADIPdiModel> requests, string rutaFinal);
    Task<FileResultModels> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz);
}