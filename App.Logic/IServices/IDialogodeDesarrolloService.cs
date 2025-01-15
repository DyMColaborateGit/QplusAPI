using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices
{
    public interface IDialogodeDesarrolloService
    {
        Task<List<TBL_com_DialogodeDesarrolloModels>> GetListDialogodeDesarrollo(int EmpresaId, long FuncionarioId, long Lider, int Anio);

        Task<List<TBL_com_DialogodeDesarrolloModels>> GetListDialogodedesarrolloByevaluacionId(int EmpresaId, long EvaluacionId);

        Task<TBL_com_DialogodeDesarrolloModels> GetObjDialogodeDesarrolloById(int IdDialogo);
    }
}
