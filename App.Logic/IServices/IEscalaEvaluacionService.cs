using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface IEscalaEvaluacionService
    {
        Task<List<Tbl_com_EscalaEvaluacionModels>> GetListEscalasByAspectoId(int EmpresaId, long AspectoId);

        Task<List<Tbl_com_EscalaEvaluacionModels>> GetListEscalasEvaluacion(int EmpresaId);

        Task<Tbl_com_EscalaEvaluacionModels> GetEscalaByEscalaIdn(int EscalaId);
    }
}
