using App.Infraestructure.Connect.Entities;
using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories;

public interface IResultadosEvaluacionRepository
{
    Task<Tbl_com_ResultadosEvaluacionModels> ObjResultadosEvaluacion(long ResultadoId);

    Task<Tbl_com_ResultadosEvaluacionModels> ObjResultadosEvaluacionByEvaluacionIdByNormaId(long EvaluacionId, int NormaId);

    Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> ListCompetenciasByEvaluacionId(long EvaluacionId);

    Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> ListFormEvaluacionByEvaluacionId(long EvaluacionId);

    Task<Tbl_com_ResultadosEvaluacionModels> UpdateResultadosEvaluacion(Tbl_com_ResultadosEvaluacionModels ObjUpdate);

    Task<Tbl_com_ResultadosEvaluacionModels> CreaResultadosEvaluacion(Tbl_com_ResultadosEvaluacionModels objCreate);
}
