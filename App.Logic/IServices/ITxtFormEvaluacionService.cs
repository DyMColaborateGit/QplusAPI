using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface ITxtFormEvaluacionService
    {
        Task<Tbl_com_TxtFormEvaluacionModels> GetObjTxtFormEvaluacion(int EmpresaId, int Tipotexto, int Tipovaloracion, int Anio);

        Task<List<Tbl_com_TxtFormEvaluacionModels>> ListTxtFormEvaluacion(int EmpresaId, int Anio, int Tipovaloracion);
    }
}
