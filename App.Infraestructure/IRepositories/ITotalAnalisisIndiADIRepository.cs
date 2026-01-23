using App.Models.Models.TblCom;
using System.Collections.Generic;

namespace App.Infraestructure.IRepositories
{
    public interface ITotalAnalisisIndiADIRepository
    {
        Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicosADI(long EvaluacionId, int EmpresaId);
    }
}
