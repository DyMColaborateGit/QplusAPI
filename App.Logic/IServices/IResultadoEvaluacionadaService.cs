using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices;

public interface IResultadoEvaluacionadaService
{
    Task<List<TBL_com_ResultadoEvaluacionADAModels>> GetListResultadoEvaluacionadaByEvaluacionId(long EvaluacionId);

    Task<List<TBL_com_ResultadoEvaluacionADAModels>> PutResultadoEvaluacionadaByEvaluacionId(long EvaluacionId, int IdHijo, long IdResultado);

    Task<TBL_com_ResultadoEvaluacionADAModels> PutResultadoEvaluacionadaTxt(TBL_com_ResultadoEvaluacionADAModels ObjPut);
}
