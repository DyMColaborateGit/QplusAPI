using App.Models.Models.TblCom;
using App.Models.Models.TblInd;

namespace App.Infraestructure.IRepositories
{
    public interface ItotalUESRepository
    {
        Task<GeneralTotalUES> GetTotalAnalisisUES1(Tbl_com_ProgEvaluacionModels dataPadre, int EmpresaId, int Tipo, int Nivel, Tbl_com_ProgEvaluacionModels progEvaluacion);

        Task<GeneralTotalUES> GetTotalAnalisisUES2(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId);
    }
}
