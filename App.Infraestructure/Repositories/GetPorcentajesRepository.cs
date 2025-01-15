using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infraestructure.Repositories
{
    public class GetPorcentajesRepository: IGetPorcentajesRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;
        private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;

        public GetPorcentajesRepository(ConnectContext context, IMapper mapper, IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository)
        {
            _context = context;
            _mapper = mapper;
            _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;   
        }

        public async Task<double> GetPorcentajeEvaluacionIndi(long EvaluacionId, int EmpresaId)
        {
            try
            {
                List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListResultadosEvaIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByDifClaseId(EvaluacionId, new int[] { 5, 6 }, EmpresaId);
                List<Tbl_com_ResultadosEvaIndicadoresModels> ListResultadosEvaIndicadoresEstrategicos = await GetListaEvaluacionIndicadoresByEvaluacionIdEvaluadosEstrategicos(EvaluacionId);

                int totEvaladas = 0;
                int totEvEstra = 0;

                totEvaladas = ListResultadosEvaIndicadores.Where(x => x.Ponderado != 0).ToList().Count;
               
                totEvEstra = ListResultadosEvaIndicadoresEstrategicos.Where(x => x.Ponderado != 0).ToList().Count;

                int totalEvaIndi = totEvaladas + totEvEstra;

                int totalIndi= (ListResultadosEvaIndicadores.Count() + ListResultadosEvaIndicadoresEstrategicos.Count());


                double multi = totalEvaIndi * 100;
                double divi = multi / totalIndi;

                double res = Math.Round(divi, 0);

                if (res <= 0)
                {
                    res = 0;
                } 

                if (res > 100)
                {
                    res = 100;
                }  

                return res;
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetPorcentajeEvaluacionIndi", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<double> GetPorcentajeEvaCompetencias(long EvaluacionId)
        {
            try
            {
                List<Tbl_com_ResultadosModels> listResultados = await GetResultadosEvaluacionListaByEvaluacionIdPorcEva(EvaluacionId);

                int totPreguntas = listResultados.Where(x => x.BEstado == false).ToList().Count;
                int totEvaladas = listResultados.Where(x => x.BEstado == true).ToList().Count;

                if (totPreguntas == 0)
                    totPreguntas = 1;

                double multi = totEvaladas * 100;
                double divi = multi / listResultados.Count();

                double res = Math.Round(divi, 0);

                if (res <= 0)
                {
                    res = 0;
                }  

                if (res > 100)
                {
                    res = 100;
                }
                return res;
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetPorcentajeEvaCompetencias", ex, EvaluacionId.ToString());
                throw;
            }
            
        }

        private async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListaEvaluacionIndicadoresByEvaluacionIdEvaluadosEstrategicos(long EvaluacionId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                   .Where(x => x.EvaluacionId == EvaluacionId && new List<int> { 5, 6 }.Contains(x.MastIndicadoresobj.ClaseId))
                   .ToListAsync();

                return _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaEvaluacionIndicadoresByEvaluacionIdEvaluadosEstrategicos", ex, EvaluacionId.ToString());
                throw;
            }
        }

        private async Task<List<Tbl_com_ResultadosModels>> GetResultadosEvaluacionListaByEvaluacionIdPorcEva(long EvaluacionId)
        {
            try
            {
                var objResult = await _context.TBL_com_Resultados.AsNoTracking()
                   .Where(x => x.EvaluacionId == EvaluacionId)
                   .ToListAsync();

                return _mapper.Map<List<Tbl_com_ResultadosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetResultadosEvaluacionListaByEvaluacionIdPorcEva", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<decimal> GetGesSumaPesosIndiGestion(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                                 .Where(x => x.EvaluacionId == EvaluacionId && ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                                 .ToListAsync();

                var listResult = _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);
                int indiPe = listResult.Where(x => x.Peso > 0).ToList().Count();

                if (indiPe > 0)
                {
                    return listResult.Select(x => x.Peso).Sum();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGesSumaPesosIndiGestion", ex, EvaluacionId+"/"+ ClaseId.ToString() + "/"+ EmpresaId);
                throw;
            }
        }

        public async Task<decimal> GetGestSumaPesoGestionDifClass(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                                 .Where(x => x.EvaluacionId == EvaluacionId && !ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                                 .ToListAsync();

                var listResult = _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);

                return listResult.Select(x => x.Peso).Sum();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGestSumaPonderadosGestion", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId);
                throw;
            }
        }

        public async Task<decimal> GetGesSumaPesosIndiEstrategicos(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                                 .Where(x => x.EvaluacionId == EvaluacionId && ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                                 .ToListAsync();

                var listResult = _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);

                return listResult.Select(x => x.Peso).Sum();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGesSumaPesosIndiEstrategicos", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId);
                throw;
            }
        }

        public async Task<decimal> GetGesSumaPonderadosEstrategicos(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                                 .Where(x => x.EvaluacionId == EvaluacionId && ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                                 .ToListAsync();

                var listResult = _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);

                return listResult.Select(x => x.Ponderado).Sum();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGesSumaPonderadosEstrategicos", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId);
                throw;
            }
        }

        public async Task<decimal> GetGesSumaPonderadosDifClass(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                                 .Where(x => x.EvaluacionId == EvaluacionId && !ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                                 .ToListAsync();

                var listResult = _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);

                return listResult.Select(x => x.Ponderado).Sum();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetGesSumaPonderadosEstrategicos", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId);
                throw;
            }
        }
    }
}
