using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services;

public class PreguntasService : IPreguntasService
{
    private readonly IPreguntasRepository _preguntasRepository;

    public PreguntasService(IPreguntasRepository preguntasRepository)
    {
        _preguntasRepository = preguntasRepository;
    }

    public async Task<List<TBL_aud_preguntasModels>> GetListPreguntas(int IdPregunta)
    {
        var ListResult = await _preguntasRepository.ListPreguntas(IdPregunta);
        return ListResult;
    }

    public async Task<TBL_aud_preguntasModels> PostCrearPreguntas(TBL_aud_preguntasModels ObjCreate, int EmpresaId)
    {
        var ListResult = await _preguntasRepository.CrearPreguntas(ObjCreate, EmpresaId);
        return ListResult;
    }

    public async Task<string> DeletePreguntas(TBL_aud_preguntasModels ObjModificar)
    {
        var ListResult = await _preguntasRepository.DeletePreguntas(ObjModificar.IdPregunta);
        return ListResult;
    }
}
