using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories
{
    public class ResultadosEvaIndicadoresRepository : IResultadosEvaIndicadoresRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ResultadosEvaIndicadoresRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Tbl_com_ResultadosEvaIndicadoresModels> ObjResultadosEvaIndicadores(long ResultadoId)
        {
            try
            {
                var updateRegistro = await _context.TBL_com_ResultadosEvaIndicadores.FirstOrDefaultAsync(p => p.ResultadoId == ResultadoId);
                return _mapper.Map<Tbl_com_ResultadosEvaIndicadoresModels>(updateRegistro);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ObjResultadosEvaIndicadores", ex, ResultadoId.ToString());
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadores(long EvaluacionId)
        {
            try
            {
                var updateRegistro = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                    .Where(p => p.EvaluacionId == EvaluacionId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(updateRegistro);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosEvaIndicadores", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                .Where(x => x.EvaluacionId == EvaluacionId && ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                .ToListAsync();
                return _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosEvaIndicadoresByClaseId", ex, EvaluacionId +"/"+ ClaseId.ToString()+"/"+EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> ListJoinResultadosEvaIndicadoresByClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                .Where(x => x.EvaluacionId == EvaluacionId && ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                .Include( x => x.MastIndicadoresobj)
                .ToListAsync();
                return _mapper.Map<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListJoinResultadosEvaIndicadoresByClaseId", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId.ToString());
                throw;
            }
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> ListResultadosEvaIndicadoresByDifClaseId(long EvaluacionId, int[] ClaseId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                    .Where(x => x.EvaluacionId == EvaluacionId && !ClaseId.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                    .Include(x => x.MastIndicadoresobj)
                    .ToListAsync();
                var Resultado = _mapper.Map<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>(objResult);
                return Resultado;
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("ListResultadosEvaIndicadoresByDifClaseId", ex, EvaluacionId + "/" + ClaseId.ToString() + "/" + EmpresaId);
                throw;
            }
        }

        public async Task<List<Tbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosEvaIndicadores(long EvaluacionId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                   .Where(x => x.EvaluacionId == EvaluacionId)
                   .ToListAsync();

                return _mapper.Map<List<Tbl_com_ResultadosEvaIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListResultadosEvaIndicadores", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<List<JOINTbl_com_ResultadosEvaIndicadoresModels>> GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId(long EvaluacionId, int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ResultadosEvaIndicadores.AsNoTracking()
                    .Include(x => x.MastIndicadoresobj)
                    .Where(x => x.EvaluacionId == EvaluacionId && x.MastIndicadoresobj.EmpresaId == EmpresaId)
                    .ToListAsync();

                return _mapper.Map<List<JOINTbl_com_ResultadosEvaIndicadoresModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId", ex, EvaluacionId.ToString());
                throw;
            }
        }

        public async Task<Tbl_com_ResultadosEvaIndicadoresModels> UpdateResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjUpdate)
        {
            var updateRegistro = _context.TBL_com_ResultadosEvaIndicadores.FirstOrDefault(p => p.ResultadoId == ObjUpdate.ResultadoId);
            try
            {
                #region Update
                if (updateRegistro != null)
                {
                    updateRegistro.EvaluacionId = ObjUpdate.EvaluacionId;
                    updateRegistro.IndcadorId = ObjUpdate.IndcadorId;
                    updateRegistro.Indicador = ObjUpdate.Indicador;
                    updateRegistro.Fecha = ObjUpdate.Fecha;
                    updateRegistro.Peso = ObjUpdate.Peso;
                    updateRegistro.Meta = ObjUpdate.Meta;
                    updateRegistro.Real = ObjUpdate.Real;
                    updateRegistro.Ponderado = ObjUpdate.Ponderado;
                    updateRegistro.Cumple = ObjUpdate.Cumple;
                    updateRegistro.Color = ObjUpdate.Color;
                    updateRegistro.PesoNext = ObjUpdate.PesoNext;
                    updateRegistro.Editar = ObjUpdate.Editar;
                    updateRegistro.TipoIndi = ObjUpdate.TipoIndi;
                    updateRegistro.EnablePeso = ObjUpdate.EnablePeso;
                    updateRegistro.EnableCalificacion = ObjUpdate.EnableCalificacion;
                }
                #endregion

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("UpdateResultadosEvaIndicadores", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
            return _mapper.Map<Tbl_com_ResultadosEvaIndicadoresModels>(updateRegistro);
        }

        public async Task<Tbl_com_ResultadosEvaIndicadoresModels> CreateResultadosEvaIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjUpdate)
        {
            tbl_com_ResultadosEvaIndicadoresEntities CreateRegistro = _mapper.Map<tbl_com_ResultadosEvaIndicadoresEntities>(ObjUpdate);
            try
            {
                 _context.TBL_com_ResultadosEvaIndicadores.Add(CreateRegistro);
                await _context.SaveChangesAsync();
                var ObjResult = await _context.TBL_com_ResultadosEvaIndicadores.OrderByDescending(e => e.ResultadoId).FirstOrDefaultAsync();
                return _mapper.Map<Tbl_com_ResultadosEvaIndicadoresModels>(ObjResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("CreateResultadosEvaIndicadores", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
        }

        public async Task<string> DeleteResultadosEvaIndicadores(long ResultadoId, long EvaluacionId)
        {
            try
            {

                var objDelete = await _context.TBL_com_ResultadosEvaIndicadores.FirstOrDefaultAsync(x => x.EvaluacionId == EvaluacionId && x.ResultadoId == ResultadoId);
                if (objDelete != null)
                {
                    _context.TBL_com_ResultadosEvaIndicadores.Remove(objDelete);
                    await _context.SaveChangesAsync();
                    return "Registro Eliminado";
                }
              
                return "No Existen Registros para Eliminar";
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("DeleteResultadosEvaIndicadores", ex, ResultadoId.ToString()+"/"+ EvaluacionId);
                throw;
            }
        }

    }
}
