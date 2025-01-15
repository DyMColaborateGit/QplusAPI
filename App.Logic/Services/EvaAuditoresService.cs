using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblAud;
using System;

namespace App.logic.Services;

public class EvaAuditoresService : IEvaAuditoresService
{
    private readonly IEvaAuditoresRepository _evaAuditoresRepository;
    private readonly IEvaPreguntasRepository _evaPreguntasRepository;

    public EvaAuditoresService(IEvaAuditoresRepository evaAuditoresRepository, IEvaPreguntasRepository evaPreguntasRepository)
    {
        _evaAuditoresRepository = evaAuditoresRepository;
        _evaPreguntasRepository = evaPreguntasRepository;
    }

    public async Task<ResponseTBL_aud_EvaAuditoresModels> GetEncabezadoEvaAuditorias(long IdEvaluacion)
    {
        var getResult = await _evaAuditoresRepository.ObjEncabezadoEvaAuditores(IdEvaluacion);
        return getResult;
    }

    public async Task<TBL_aud_EvaAuditoresModels> PostCrearEvaAuditores(TBL_aud_EvaAuditoresModels ObjCreate, int EmpresaId)
    {
        var ObjResult = await _evaAuditoresRepository.CrearEvaAuditores(ObjCreate, EmpresaId);
        return ObjResult;
    }

    public async Task<TBL_aud_EvaAuditoresModels> PutObservacionEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate)
    {
        var ObjResult = await _evaAuditoresRepository.UpdateObservacionEvaAuditores(ObjUpdate);
        return ObjResult;
    }

    public async Task<TBL_aud_EvaAuditoresModels> PutEstadoEvaAuditores(long IdEvaluacion)
    {
        TBL_aud_EvaAuditoresModels ObjResult = await _evaAuditoresRepository.GetObjEvaAuditores(IdEvaluacion);
        ObjResult.Promedio = await _evaPreguntasRepository.GetPromedioEvaPreguntas(IdEvaluacion);

        if (ObjResult.TotalPreguntas == ObjResult.TotalPreCalificadas)
        {
            ObjResult.Estado = true;
        }
        await _evaAuditoresRepository.UpdateEvaAuditores(ObjResult);
        return ObjResult;
    }
}
