using App.Models.Models.TblCom;

namespace App.Infraestructure.IRepositories;

public interface IEscalaEvaluacionRepository
{
    Task<List<Tbl_com_EscalaEvaluacionModels>> ListEscalasByAspectoId(int EmpresaId, long AspectoId);

    Task<Tbl_com_EscalaEvaluacionModels> EscalaByEscalaId(int EscalaId);

    Task<List<Tbl_com_EscalaEvaluacionModels>> ListEscalasEvaluacion(int EmpresaId);
}
