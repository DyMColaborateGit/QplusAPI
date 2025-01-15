using App.Models.Models.TblAud;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEvaPreguntasRepository
{
    Task<List<TBL_aud_EvaPreguntasModels>> ListEvaPreguntas(long IdEvaluacion);

    Task<TBL_aud_EvaPreguntasModels> CrearEvaPreguntas(TBL_aud_EvaPreguntasModels ObjCreate, int EmpresaId);

    Task<TBL_aud_EvaPreguntasModels> PutEvaPreguntasByCalificacion(long IdEvaluacion, int Calificacion, long IdEvaPregunta);

    Task<decimal> GetPromedioEvaPreguntas(long IdEvaluacion);

    Task<string> DeleteEvaPreguntas(int IdEvaPregunta);
}
