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
    public async Task<FileResultModels> PostMoverArchivo(List<FileMoveModels> fileMove)
    {
        return await _fileMoverRepository.PostMoverArchivo(fileMove);
    }
    public async Task<FileResultModels> PostPdfArchivos(List<FilePdfADIPdiModel> FilePdfs)
    {
        return await _fileMoverRepository.PostPdfArchivos(FilePdfs);
    }
    public async Task<FileResultModels> PostGuardarPdfDataArchivo(FilePdfADIPdiModel FilePdfs)
    {
        return await _fileMoverRepository.PostGuardarPdfDataArchivo(FilePdfs);
    }
    public async Task<FileResultModels> CheckFileExists(FileMoveModels fileCheck)
    {
        return await _fileMoverRepository.CheckFileExists(fileCheck);
    }
    public async Task<FileResultModels> GetGenerarGuardarPdfs(List<FilePdfADIPdiModel> requests, string rutaFinal)
    {
        return await _fileMoverRepository.GetGenerarGuardarPdfs(requests, rutaFinal);
    }
    public async Task<FileResultModels> ObtenerImagenBase64(string nombreArchivo, string arbolRaiz)
    {
        return await _fileMoverRepository.ObtenerImagenBase64(nombreArchivo, arbolRaiz);
    }}