using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services;

public class EncuestaPreguntaService: IEncuestaPreguntaService
{
    private readonly IEncuestaPreguntaRepository _encuestaPreguntaRepository;

    private readonly IEncuestaRepository _encuestaRepository;

    public EncuestaPreguntaService(IEncuestaPreguntaRepository encuestaPreguntaRepository, IEncuestaRepository encuestaRepository)
    {
        _encuestaPreguntaRepository = encuestaPreguntaRepository;
        _encuestaRepository = encuestaRepository;
    }

    public async Task<List<JOIN_tbl_com_EncuestaPreguntaModels>> GetListEncuestaPregunta(int EmpresaId, int IdEncuesta)
    {
        return await _encuestaPreguntaRepository.ListEncuestaPregunta(EmpresaId, IdEncuesta);
    }

    public async Task<TBL_com_EncuestaPreguntaModels> PutUpdateEncuestaPregunta(TBL_com_EncuestaPreguntaModels ObjRequest)
    {
        var ObjPregunta = await _encuestaPreguntaRepository.ObjEncuestaPregunta(ObjRequest.IdEncuestaPregunta);
        ObjPregunta.Resultado = ObjRequest.Resultado;

        await ActualizarContadorEncuesta(ObjPregunta.EmpresaId, ObjPregunta.IdEncuesta);

        return await _encuestaPreguntaRepository.UpdateEncuestaPregunta(ObjPregunta);
    }

    public async Task<string> GetValidateEstadoEncuesta(int EmpresaId, int IdEncuesta)
    {
        TBL_com_EncuestaModels ObjEncuesta = await ActualizarContadorEncuesta(EmpresaId, IdEncuesta);
        return ObjEncuesta.Estado == 1? "Encuesta Finalizada": "Para finalizar la encuesta del ADI debe calificar todas las preguntas.";
    }

    private async Task<TBL_com_EncuestaModels> ActualizarContadorEncuesta(int EmpresaId, int IdEncuesta)
    {
        var ObjEncuestas = await _encuestaPreguntaRepository.ListEncuestaPregunta(EmpresaId, IdEncuesta);
        int calificadas = ObjEncuestas.Where(x => x.Resultado != 0).ToList().Count();
        if (calificadas == ObjEncuestas[0].EncuestaObj.TotalPreguntas)
        {
            ObjEncuestas[0].EncuestaObj.Estado = 1;
        }
        ObjEncuestas[0].EncuestaObj.PreguntasCalificadas = calificadas;

       return await _encuestaRepository.UpdateEncuesta(ObjEncuestas[0].EncuestaObj);
    }
}
