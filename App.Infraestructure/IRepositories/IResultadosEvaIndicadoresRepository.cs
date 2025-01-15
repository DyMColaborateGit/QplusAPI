using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories
{
    public interface IResultadosEvaIndicadoresRepository
    {
        Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadoresByDifClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> ListJoinResultadosEvaIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<Tbl_com_ResultadosEvaIndicadoresModels> ObjResultadosEvaIndicadores(long ResultadoId);

        Task<Tbl_com_ResultadosEvaIndicadoresModels> UpdateResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjUpdate);

        Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosEvaIndicadores(long EvaluacionId);

        Task<Tbl_com_ResultadosEvaIndicadoresModels> CreateResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjUpdate);

        Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId(long EvaluacionId, int EmpresaId);

        Task<string> DeleteResultadosEvaIndicadores(long ResultadoId, long EvaluacionId);

        Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadores(long EvaluacionId);
    }
}
