using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories
{
    public interface ITotalAnalisisIndiADIRepository
    {
        Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicosADI(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId);
    }
}
