using App.Models.Models.TblAud;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEvaAuditoresRepository
{
    Task<ResponseTBL_aud_EvaAuditoresModels> ObjEncabezadoEvaAuditores(long IdEvaluacion);

    Task<TBL_aud_EvaAuditoresModels> GetObjEvaAuditores(long IdEvaluacion);

    Task<TBL_aud_EvaAuditoresModels> CrearEvaAuditores(TBL_aud_EvaAuditoresModels ObjCreate, int EmpresaId);

    Task<TBL_aud_EvaAuditoresModels> UpdateEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate);

    Task<TBL_aud_EvaAuditoresModels> UpdateContadorEvaAuditores(long IdEvaluacion, bool Gest);

    Task<TBL_aud_EvaAuditoresModels> UpdateObservacionEvaAuditores(TBL_aud_EvaAuditoresModels ObjUpdate);

    Task<string> DeleteEvaAuditores(int IdEvaluacion);
}
