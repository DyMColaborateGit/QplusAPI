using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface ITotalAnalisisIndiADIService
    {
        Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicosADI(long EvaluacionId, int EmpresaId);
    }
}
