using App.Models.Models.TblAud;
using System;

namespace App.logic.IServices;

public interface IEvaAuditoresService
{
    Task<ResponseTBL_aud_EvaAuditoresModels> GetEncabezadoEvaAuditorias(long IdEvaluacion);

    Task<TBL_aud_EvaAuditoresModels> PostCrearEvaAuditores(TBL_aud_EvaAuditoresModels ObjCreate, int EmpresaId);

    Task<TBL_aud_EvaAuditoresModels> PutObservacionEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate);

    Task<TBL_aud_EvaAuditoresModels> PutEstadoEvaAuditores(long IdEvaluacion);
}
