using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface IResultadosService
    {
        Task<List<Tbl_com_ResultadosModels>> GetResultadosEvaluacionListaByEvaluacionId(int EvaluacionId, int NormaId);
    }
}
