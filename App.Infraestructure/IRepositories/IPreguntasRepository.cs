using App.Models.Models.TblAud;
using System;

namespace App.Infraestructure.IRepositories;

public interface IPreguntasRepository
{
    Task<List<TBL_aud_preguntasModels>> ListPreguntas(int IdPregunta);
    Task<TBL_aud_preguntasModels> CrearPreguntas(TBL_aud_preguntasModels ObjCreate, int EmpresaId);
    Task<string> DeletePreguntas(int IdPregunta);
}
