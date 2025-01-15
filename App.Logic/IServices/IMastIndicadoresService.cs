using App.Models.Models.TblInd;
using System;

namespace App.logic.IServices;

public interface IMastIndicadoresService
{
    Task<string> GetValueTiposdeindicadores(int EmpresaId, long EvaluacionId);

    Task<List<Tbl_ind_MastIndicadoresModels>> GetIndicadoresFuncionarioEstrategicos(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo);

    Task<Tbl_ind_MastIndicadoresModels> PostIndicadorFuncionarioByEvaluacionId(Tbl_ind_MastIndicadoresModels ObjRequest, long EvaluacionId);

    Task<List<Tbl_ind_MastIndicadoresModels>> GetListIndicadoresFuncionarioDifClass(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo);
}
