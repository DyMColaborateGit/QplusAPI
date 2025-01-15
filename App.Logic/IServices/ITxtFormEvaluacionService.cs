using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface ITxtFormEvaluacionService
    {
        Task<Tbl_com_TxtFormEvaluacionModels> GetObjTxtFormEvaluacion(int EmpresaId, int Tipotexto, int Tipovaloracion, int Anio);
    }
}
