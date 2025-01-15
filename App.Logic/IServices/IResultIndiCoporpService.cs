using App.Models.Models.TblInd;
using System;

namespace App.logic.IServices
{
    public interface IResultIndiCoporpService
    {
        Task<JOINTBL_ind_ResultIndiCoporpModels> GetresultadoTotalIndicadoreCorporativos(long EvaluacionId, int EmpresaId, int InAnio);

        Task<List<JOINTBL_ind_ResultIndiCoporpModels>> GetListaResutIndiCorporativos(long EvaluacionId, int EmpresaId, int InAnio);
    }
}
