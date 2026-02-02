using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface IResultIndiCoporpRepository
    {
        Task<JOINTBL_ind_ResultIndiCoporpModels> ResultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio);
        Task<List<JOINTBL_ind_ResultIndiCoporpModels>> ListResultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio);
        Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResultadoIndicadoresCorporativos(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId);
        //Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResultadoIndicadoresCorporativos(int EvaluacionId, int EmpresaId);

    }
}
