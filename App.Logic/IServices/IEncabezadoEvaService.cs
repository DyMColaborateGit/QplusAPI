using App.Models.Models.TblCom;

namespace App.logic.IServices;

public interface IEncabezadoEvaService
{
    Task<ResponseEncabezadoEvaModels> GetObjEncabezadoEvaluacionByEvaluacionId(long EvaluacionId);
}
