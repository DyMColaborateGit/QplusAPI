using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using System;

namespace App.logic.Services;

public class EvaPreguntasService : IEvaPreguntasService
{
    private readonly IEvaPreguntasRepository _evaPreguntasRepository;

    public EvaPreguntasService(IEvaPreguntasRepository evaPreguntasRepository)
    {
        _evaPreguntasRepository = evaPreguntasRepository;
    }

    public async Task<List<TBL_aud_EvaPreguntasModels>> GetListEvaPreguntas(long IdEvaluacion)
    {
        List<TBL_aud_EvaPreguntasModels> ListResult = await _evaPreguntasRepository.ListEvaPreguntas(IdEvaluacion);
        return ListResult;
    }

    public async Task<TBL_aud_EvaPreguntasModels> UpdateEvaPreguntas(long IdEvaluacion, int Calificacion, long IdEvaPregunta)
    {
        TBL_aud_EvaPreguntasModels ObjResult = await _evaPreguntasRepository.PutEvaPreguntasByCalificacion(IdEvaluacion, Calificacion, IdEvaPregunta);
        return ObjResult;
    }

    public async Task<TBL_aud_EvaPreguntasModels> PostCrearEvaPreguntas(TBL_aud_EvaPreguntasModels ObjCreate, int EmpresaId)
    {
        var ListResult = await _evaPreguntasRepository.CrearEvaPreguntas(ObjCreate, EmpresaId);
        return ListResult;
    }

    public async Task<string> DeleteEvaPreguntas(TBL_aud_EvaPreguntasModels ObjModificar)
    {
        var ListResult = await _evaPreguntasRepository.DeleteEvaPreguntas(ObjModificar.IdEvaPregunta);
        return ListResult;
    }
}
