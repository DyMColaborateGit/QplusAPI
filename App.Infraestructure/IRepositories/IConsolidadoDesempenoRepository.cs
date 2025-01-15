using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IConsolidadoDesempenoRepository
{
    Task<List<TBL_com_ConsolidadoDesempenoModels>> ListConsolidadoDesempeno(long EvaluacionId, int TipoId);

    Task<TBL_com_ConsolidadoDesempenoModels> CreateConsolidadoDesempeno(TBL_com_ConsolidadoDesempenoModels objCreate);

    Task<TBL_com_ConsolidadoDesempenoModels> UpdateConsolidadoDesempeno(TBL_com_ConsolidadoDesempenoModels ObjUpdate);
}
