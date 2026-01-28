using App.Models.Models.TblInd;
using System;

namespace App.logic.IServices
{
    public interface ITotalUESService
    {
        Task<GeneralTotalUES> GetTotalAnalisisUES1(long EvaluacionId, int EmpresaId, int Tipo, int Nivel);
        Task<GeneralTotalUES> GetTotalAnalisisUES2(long EvaluacionId, int EmpresaId);
    }
}
