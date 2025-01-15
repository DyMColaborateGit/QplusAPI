using App.Models.Models.TblAud;
using System;

namespace App.logic.IServices;

public interface IEvaPreguntasService
{
    Task<List<TBL_aud_EvaPreguntasModels>> GetListEvaPreguntas(long IdEvaluacion);

    Task<TBL_aud_EvaPreguntasModels> UpdateEvaPreguntas(long IdEvaluacion, int Calificacion, long IdEvaPregunta);

    Task<TBL_aud_EvaPreguntasModels> PostCrearEvaPreguntas(TBL_aud_EvaPreguntasModels ObjCreate, int EmpresaId);

    Task<string> DeleteEvaPreguntas(TBL_aud_EvaPreguntasModels ObjModificar);
}
