using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.FileMove;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace App.logic.Services;

public class FileMoverService : IFileMoverService
{
    private readonly IFileMoverRepository _fileMoverRepository;

    public FileMoverService(IFileMoverRepository fileMoverRepository)
    {
        _fileMoverRepository = fileMoverRepository;
    }
    public async Task<FilePdfResultsModel> PostMoverArchivo(List<FileMoveModels> fileMove)
    {
        return await _fileMoverRepository.PostMoverArchivo(fileMove);
    }
    public async Task<FilePdfResultsModel> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs)
    {
        return await _fileMoverRepository.PostPdfArchivos(FilePdfs);
    }
    public async Task<FilePdfResultsModel> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs)
    {
        return await _fileMoverRepository.PostGuardarPdfDataArchivo(FilePdfs);
    }
    public async Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck)
    {
        return await _fileMoverRepository.CheckFileExists(fileCheck);
    }
    public async Task<FilePdfResultsModel> GetGenerarGuardarPdfs(List<FilePdfADIPdiModel> requests, string rutaFinal)
    {
        return await _fileMoverRepository.GetGenerarGuardarPdfs(requests, rutaFinal);
    }
    public async Task<FilePdfResultsModel> GetGenerarGuardarPdfsADI(List<FilePdfADIPdiModel> requests, string rutaFinal)
    {
        return await _fileMoverRepository.GetGenerarGuardarPdfsADI(requests, rutaFinal);
    }
    public async Task<ActionResult<FileResultModels>> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz)
    {
        return await _fileMoverRepository.ObtenerImagenBase64(nombreArchivo, arbolRaiz);
    }
    public async Task<FileResultModels> PostCrearPDFADI(List<FilePdfADIPdiModel> PdfADI)
    {
        return await _fileMoverRepository.PostCrearPDFADI(PdfADI);
    }
}