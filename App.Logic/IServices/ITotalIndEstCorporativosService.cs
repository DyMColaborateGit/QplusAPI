using App.Models.Models.TblCom;
using App.Models.Models.TblInd;

namespace App.logic.IServices
{
    public interface ITotalIndEstCorporativosService
    {
        Task<List<GeneralTBL_ind_TotalIndEstCorporativosModels>> GetListaTotalIndicadoresCorporativos(int EvaluacionId, int EmpresaId);
    }
}
