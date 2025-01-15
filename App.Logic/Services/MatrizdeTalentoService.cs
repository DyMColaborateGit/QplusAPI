using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class MatrizdeTalentoService: IMatrizdeTalentoService
    {
        private readonly IMatrizdeTalentoRepository _matrizdeTalentoRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;
        public MatrizdeTalentoService(IMatrizdeTalentoRepository matrizdeTalentoRepository, IProgEvaluacionRepository progEvaluacionRepository)
        {
            _matrizdeTalentoRepository = matrizdeTalentoRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
        }

        public async Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListMatrizdeTalentos(int EmpresaId, int Codmatriz)
        {
            var ListMatriz = await _matrizdeTalentoRepository.ListMatrizdeTalentos(EmpresaId);
            return ListMatriz.Where(x => x.CodMatrix == Codmatriz).ToList();
        }

        public async Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListConsolidadoMatrizdeTalentos(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            var ListMatriz = await _matrizdeTalentoRepository.ListMatrizdeTalentos(EmpresaId);
            ListMatriz = ListMatriz.Where(x => x.CodMatrix == Codmatriz).ToList();
            int totalEvaluaciones = 0;
            foreach (ResponseTBL_com_MatrizdeTalentosModels matriz in ListMatriz)
            {
                var Evaluaciones = await _progEvaluacionRepository.ListEvaluacionesTalentosFuncionarios(EmpresaId, InAnio, ZonaId, OficinaId, 0, matriz.NumeroCaja, EvaluadorId, EvaluadoId, true);
                matriz.Contevaluaciones = Evaluaciones.Count;
                matriz.Backgroundcolor = GetBackgroundcolorHelpers.colormapadetalentos(matriz.Color);
                totalEvaluaciones += matriz.Contevaluaciones;
            }
            foreach (ResponseTBL_com_MatrizdeTalentosModels matriz in ListMatriz)
            {
                matriz.PorcentajeEvaluaciones = totalEvaluaciones > 0 ? Math.Round((double)matriz.Contevaluaciones / totalEvaluaciones * 100, 2) : 0;
                matriz.TotalEvaluaciones = totalEvaluaciones;
            }
            return ListMatriz;
        }

        public async Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListConsolidadoMatrizdeTalentosM(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId)
        {
            var ListMatriz = await _matrizdeTalentoRepository.ListMatrizdeTalentos(EmpresaId);
            ListMatriz = ListMatriz.Where(x => x.CodMatrix == Codmatriz).ToList();
            int totalEvaluaciones = 0;
            foreach (ResponseTBL_com_MatrizdeTalentosModels matriz in ListMatriz)
            {
                var Evaluaciones = await _progEvaluacionRepository.ListEvaluacionesTalentosFuncionariosM(EmpresaId, InAnio, ZonaId, OficinaId, 0, matriz.NumeroCaja, EvaluadorId, EvaluadoId, true);
                matriz.Contevaluaciones = Evaluaciones.Count;
                matriz.Backgroundcolor = GetBackgroundcolorHelpers.colormapadetalentos(matriz.Color);
                totalEvaluaciones += matriz.Contevaluaciones;
            }
            foreach (ResponseTBL_com_MatrizdeTalentosModels matriz in ListMatriz)
            {
                matriz.PorcentajeEvaluaciones = totalEvaluaciones > 0 ? Math.Round((double)matriz.Contevaluaciones / totalEvaluaciones * 100, 2) : 0;
                matriz.TotalEvaluaciones = totalEvaluaciones;
            }
            return ListMatriz;
        }

        public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListEvaluacionesAnioEvaluadorId(int InAnio, long EvaluadorId)
        {
            return await _progEvaluacionRepository.ListEvaluacionesAnioEvaluadorId(InAnio, EvaluadorId);
        }

        public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoMatrizdeTalentos(int EmpresaId, int NumeroCaja, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        { 
            return await _progEvaluacionRepository.ListEvaluacionesTalentosFuncionarios(EmpresaId, InAnio, ZonaId, OficinaId, 0, NumeroCaja, EvaluadorId, EvaluadoId, true);
        }
        public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoMatrizdeTalentosM(int EmpresaId, int NumeromapatalentoM, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId)
        {
            return await _progEvaluacionRepository.ListEvaluacionesTalentosFuncionariosM(EmpresaId, InAnio, ZonaId, OficinaId, 0, NumeromapatalentoM, EvaluadorId, EvaluadoId, true);
        }

        public async Task<int> GestUpdateMatrizdeTalentosFuncionarios(int Anio, int EmpresaId)
        {
            var ListEvaluaciones = await _progEvaluacionRepository.ListEvaluacionesAnio(Anio, 1);
            foreach (var item in ListEvaluaciones)
            {
                TBL_com_MatrizdeTalentosModels categoriaObj = await _matrizdeTalentoRepository.CategoriaMatrizdeTalentos((int)item.PromComp, (int)item.PromIndi, EmpresaId);
                if (categoriaObj is object)
                {
                    item.NumeroMapaTalento = categoriaObj.NumeroCaja;
                    item.ColorMapaTalento = categoriaObj.Color;
                    item.CajaMapaTalento = categoriaObj.NombreCaja;
                    item.NumeroMapaTalentoM = categoriaObj.NumeroCaja;
                    item.ColorMapaTalentoM = categoriaObj.Color;
                    item.CajaMapaTalentoM = categoriaObj.NombreCaja;

                    await _progEvaluacionRepository.UpdateProgEvaluacion(item);
                }
            }

            return ListEvaluaciones.Count();
        }

    }
}
