using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class ResultadosEvaIndicadoresService : IResultadosEvaIndicadoresService
    {
        private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;

        public ResultadosEvaIndicadoresService(IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadores(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            var ListResult =  await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByDifClaseId(EvaluacionId, ClaseId, EmpresaId);
            return ListResult;
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            var ListResult = await _resultadosEvaIndicadoresRepository.ListJoinResultadosEvaIndicadoresByClaseId(EvaluacionId, ClaseId, EmpresaId);
            return ListResult;
        }

        public async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByEvaluacionIdByIndcadorId(long EvaluacionId, long IndcadorId)
        {
            var ListResult = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(EvaluacionId);
            return ListResult.Where(x => x.IndcadorId == IndcadorId).ToList();
        }

        public async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosIndicadoresByEvaluacionId(long EvaluacionId)
        {
            var ListResult = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(EvaluacionId);
            return ListResult;
        }

        public async Task<Tbl_com_ResultadosEvaIndicadoresModels> PostResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjRequest)
        {
            Tbl_com_ResultadosEvaIndicadoresModels ObjResult = await _resultadosEvaIndicadoresRepository.CreateResultadosEvaIndicadores(ObjRequest);
            return ObjResult;
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListaIndicadoreEstrategicos(long EvaluacionId, int Tipo, int Nivel, int EmpresaId)
        {
            long idEVa = 0;
            List<JOINTbl_com_ResultadosEvaIndicadoresModels> li = new List<JOINTbl_com_ResultadosEvaIndicadoresModels>();
            Tbl_com_ProgEvaluacionModels dE = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            if (Nivel == 1)
            {

                if (Tipo == 1)
                {

                    idEVa = EvaluacionId;

                }
                if (Tipo == 2)
                {

                    idEVa = (await _progEvaluacionRepository.ObjProgEvaluacionPadre((long)dE.IdPadre, (int)dE.InAno, (int)dE.MesIni, (int)dE.MesFin, EmpresaId, 1, 1)).InIdEvaluacion;

                }

            }
            if (Nivel != 1)
            {
                if (dE.IdPadre == 0)
                {

                    idEVa = EvaluacionId;
                }
                else
                {
                    var DataEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacionPadre((long)dE.IdPadre, (int)dE.InAno, (int)dE.MesIni, (int)dE.MesFin, EmpresaId, 1, 1);
                    idEVa = DataEvaluacion.InIdEvaluacion;

                }
            }

            li = await _resultadosEvaIndicadoresRepository.ListJoinResultadosEvaIndicadoresByClaseId(idEVa, new int[] { 6 }, EmpresaId);

            return li;
        }
    }
}
