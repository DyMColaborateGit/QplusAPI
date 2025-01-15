using App.Models.Models.Share;
using App.Models.Models.TblCom;

namespace App.logic.IServices;

public interface IResultadosEvaluacionService
{
    Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> GetListCompetenciasByEvaluacionId(long EvaluacionId);

    Task<Tbl_com_ResultadosEvaluacionModels> PutResultadoEvaluacionObservacion(long EvaluacionId, RequestUpdateObservaciones ObjPut);
}
