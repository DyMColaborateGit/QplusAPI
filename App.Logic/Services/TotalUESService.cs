using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblInd;
using System;

namespace App.logic.Services
{
    public class TotalUESService : ITotalUESService
    {
        private readonly ItotalUESRepository _totalUESRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;

        public TotalUESService(ItotalUESRepository totalUESRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _totalUESRepository = totalUESRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }
        public async Task<GeneralTotalUES> GetTotalAnalisisUES1(long EvaluacionId, int EmpresaId, int Tipo, int Nivel)
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            return await _totalUESRepository.GetTotalAnalisisUES1(progEva, EmpresaId, Tipo, Nivel);
        }
        public async Task<GeneralTotalUES> GetTotalAnalisisUES2(long EvaluacionId, int EmpresaId)
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            return await _totalUESRepository.GetTotalAnalisisUES2(progEva, EmpresaId);
        }
    }
}
