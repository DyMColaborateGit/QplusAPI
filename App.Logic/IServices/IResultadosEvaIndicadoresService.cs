using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices
{
    public interface IResultadosEvaIndicadoresService
    {
        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadores(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<Tbl_com_ResultadosEvaIndicadoresModels> PostResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjRequest);

        Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByEvaluacionId(long EvaluacionId);

        Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByEvaluacionIdByIndcadorId(long EvaluacionId, long IndcadorId);

        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListaIndicadoreEstrategicos(long EvaluacionId, int Tipo, int Nivel, int EmpresaId);
    }
}
