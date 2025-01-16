using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class NivelDesempenoPpalService : INivelDesempenoPpalService
    {
        private readonly INivelDesempenoPpalRepository _nivelDesempenoPpalRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;
        public NivelDesempenoPpalService(INivelDesempenoPpalRepository nivelDesempenoPpalRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _nivelDesempenoPpalRepository = nivelDesempenoPpalRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }

        public async Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListNivelDesempenoPpal(int EmpresaId, int InAnio)
        {
            var ListNivelesD = await _nivelDesempenoPpalRepository.ListNivelDesempenoPpal(EmpresaId, InAnio);
            return ListNivelesD.Where(x => x.EmpresaId == EmpresaId && x.InAnio == InAnio).ToList();
        }

        public async Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListConsolidadoNivelDesempeno(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            var ListNivelesD = await _nivelDesempenoPpalRepository.ListNivelDesempenoPpal(EmpresaId, InAnio);
            ListNivelesD = ListNivelesD.Where(x => x.EmpresaId == EmpresaId && x.InAnio == InAnio).ToList();
            int totalEvaluaciones = 0;
            foreach (TBL_com_NivelesDesempenoPpalModels NivelesD in ListNivelesD)
            {
                var Evaluaciones = await _progEvaluacionRepository.ListEvaluacionesNivelesDesempeno(EmpresaId, InAnio, ZonaId, OficinaId, 0, NivelesD.UbicacionMD, EvaluadorId, EvaluadoId, true);
                NivelesD.Contevaluaciones = Evaluaciones.Count;
                NivelesD.Backgroundcolor = GetBackgroundcolorHelpers.colormapadetalentos(NivelesD.Color);
                totalEvaluaciones += NivelesD.Contevaluaciones;
            }
            foreach (TBL_com_NivelesDesempenoPpalModels NivelesD in ListNivelesD)
            {
                NivelesD.PorcentajeEvaluaciones = totalEvaluaciones > 0 ? Math.Round((double)NivelesD.Contevaluaciones / totalEvaluaciones * 100, 2) : 0;
                NivelesD.TotalEvaluaciones = totalEvaluaciones;
            }
            return ListNivelesD;
        }
        public async Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListConsolidadoNivelDesempenoM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            var ListNivelesD = await _nivelDesempenoPpalRepository.ListNivelDesempenoPpal(EmpresaId, InAnio);
            ListNivelesD = ListNivelesD.Where(x => x.EmpresaId == EmpresaId && x.InAnio == InAnio).ToList();
            int totalEvaluaciones = 0;
            foreach (TBL_com_NivelesDesempenoPpalModels NivelesD in ListNivelesD)
            {
                var Evaluaciones = await _progEvaluacionRepository.ListEvaluacionesNivelesDesempenoM(EmpresaId, InAnio, ZonaId, OficinaId, 0, NivelesD.UbicacionMD, EvaluadorId, EvaluadoId, true);
                NivelesD.Contevaluaciones = Evaluaciones.Count;
                NivelesD.Backgroundcolor = GetBackgroundcolorHelpers.colormapadetalentos(NivelesD.Color);
                totalEvaluaciones += NivelesD.Contevaluaciones;
            }
            foreach (TBL_com_NivelesDesempenoPpalModels NivelesD in ListNivelesD)
            {
                NivelesD.PorcentajeEvaluaciones = totalEvaluaciones > 0 ? Math.Round((double)NivelesD.Contevaluaciones / totalEvaluaciones * 100, 2) : 0;
                NivelesD.TotalEvaluaciones = totalEvaluaciones;
            }
            return ListNivelesD;
        }

        public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoNivelesDesempenoPpal(int EmpresaId, int UbicacionMD, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            return await _progEvaluacionRepository.ListEvaluacionesNivelesDesempeno(EmpresaId, InAnio, ZonaId, OficinaId, 0, UbicacionMD, EvaluadorId, EvaluadoId, true);
        }

        public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoNivelesDesempenoPpalM(int EmpresaId, int UbicacionMD_M, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            return await _progEvaluacionRepository.ListEvaluacionesNivelesDesempenoM(EmpresaId, InAnio, ZonaId, OficinaId, 0, UbicacionMD_M, EvaluadorId, EvaluadoId, true);
        }
    }
}
