using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface IFileMoverRepository
{
    Task<string> PostMoverArchivo(string NombreArchivo);
}
