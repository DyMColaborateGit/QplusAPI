using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface IResultadosRepository
    {
        Task<Tbl_com_ResultadosModels> ObjResultados(long ResultadoId);

        Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionId(long EvaluacionId);

        Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionIdByNormaId(long EvaluacionId, int NormaId);

        Task<Tbl_com_ResultadosModels> UpdateResultados(Tbl_com_ResultadosModels ObjUpdate, int Bcerrado);

        Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionIdByestado(long EvaluacionId, int Bcerrado);

        Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionCerrados(long EvaluacionId, bool BEstado);
    }
}
