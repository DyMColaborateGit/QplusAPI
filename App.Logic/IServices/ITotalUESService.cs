using App.Models.Models.TblInd;
using System;

namespace App.logic.IServices
{
    public interface ITotalUESService
    {
        Task<GeneralTotalUES> GetTotalAnalisisUES1(int EvaluacionIdPadre, int EmpresaId, int Tipo, int Nivel, int EvaluacionId);
        Task<GeneralTotalUES> GetTotalAnalisisUES2(long EvaluacionId, int EmpresaId);
    }
}
