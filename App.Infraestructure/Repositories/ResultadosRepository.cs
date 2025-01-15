using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Infraestructure.Repositories
{
    public class ResultadosRepository: IResultadosRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ResultadosRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Tbl_com_ResultadosModels> ObjResultados(long ResultadoId)
        {
            try
            {
                var objResult = await _context.TBL_com_Resultados.AsNoTracking()
                    .Where(x => x.ResultadoId == ResultadoId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<Tbl_com_ResultadosModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjResultados", ex, ResultadoId.ToString());
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionId(long EvaluacionId)
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
                ExceptionLogHelpers.LogException("ListResultadosByEvaluacionIdd", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionIdByestado(long EvaluacionId, int Bcerrado)
        {
            try
            {
                var objResult = await _context.TBL_com_Resultados.AsNoTracking()
                    .Where(x => x.EvaluacionId == EvaluacionId && x.BCerrado == Bcerrado)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_com_ResultadosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosByEvaluacionIdByestado", ex, EvaluacionId + "/" + Bcerrado);
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionCerrados(long EvaluacionId, bool BEstado)
        {
            try
            {
                var objResult = await _context.TBL_com_Resultados.AsNoTracking()
                    .Where(x => x.EvaluacionId == EvaluacionId && x.BEstado == BEstado)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_com_ResultadosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosByEvaluacionIdByestado", ex, EvaluacionId + "/" + BEstado);
                throw;
            }
        }


        public async Task<List<Tbl_com_ResultadosModels>> ListResultadosByEvaluacionIdByNormaId(long EvaluacionId, int NormaId)
        {
            try
            {
                var objResult = await _context.TBL_com_Resultados.AsNoTracking()
                    .Where(x => x.EvaluacionId == EvaluacionId && x.NormaId == NormaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_com_ResultadosModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosByEvaluacionIdByNormaId", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<Tbl_com_ResultadosModels> UpdateResultados(Tbl_com_ResultadosModels ObjUpdate, int Bcerrado)
        {
            var objResult = _mapper.Map<Tbl_com_EscalaEvaluacionModels>(_context.TBL_com_EscalaEvaluacion.FirstOrDefault(x => x.EscalaId == ObjUpdate.EscalaId));
            ObjUpdate.Escalanivel = objResult.Nivel;
            ObjUpdate.Color = objResult.Color;
            ObjUpdate.ResEscala = objResult.Escala;
            ObjUpdate.BEstado = objResult.Escala > 0 ? true: false;
            ObjUpdate.BCerrado = Bcerrado;
       
           var updateRegistro = _context.TBL_com_Resultados.FirstOrDefault(p => p.ResultadoId == ObjUpdate.ResultadoId);
            try
            {
                #region Update
                if (updateRegistro != null)
                {
                    updateRegistro.EvaluacionId = ObjUpdate.EvaluacionId;
                    updateRegistro.NormaId = ObjUpdate.NormaId;
                    updateRegistro.CriterioId = ObjUpdate.CriterioId;
                    updateRegistro.Criterio = ObjUpdate.Criterio;
                    updateRegistro.FechaEva = ObjUpdate.FechaEva;
                    updateRegistro.Color = ObjUpdate.Color;
                    updateRegistro.ResEscala = ObjUpdate.ResEscala;
                    updateRegistro.BMejoramiento = ObjUpdate.BMejoramiento;
                    updateRegistro.VcObMejoramiento = ObjUpdate.VcObMejoramiento;
                    updateRegistro.BEstado = ObjUpdate.BEstado;
                    updateRegistro.BCerrado = ObjUpdate.BCerrado;
                    updateRegistro.EscalaId = ObjUpdate.EscalaId;
                    updateRegistro.Escalanivel = ObjUpdate.Escalanivel;
                }
                #endregion
                await _context.SaveChangesAsync();
                return _mapper.Map<Tbl_com_ResultadosModels>(updateRegistro);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("UpdateResultados", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
        }
    }
}
