using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblCom;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;


namespace App.Infraestructure.Repositories
{
    public class ActividadesPIDRepository: IActividadesPIDRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ActividadesPIDRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TBL_com_ActividadesPIDModels> GetObjActividadesPDI(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ActividadesPID.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<TBL_com_ActividadesPIDModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjActividadesPDI", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<TBL_com_ActividadesPIDModels>> GetListaActividadesPDI(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_com_ActividadesPID.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_ActividadesPIDModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaActividadesPDI", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<TBL_com_ActividadesPIDModels>> GetListaActividadesPDIByEvaluadoIdByAnio(int EmpresaId, long EvaluadoId, int InAnio)
        {
            try
            {
                var objResult = await _context.TBL_com_ActividadesPID.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId && x.EvaluadoId == EvaluadoId && x.InAnio == InAnio)
                    .ToListAsync();
                return _mapper.Map<List<TBL_com_ActividadesPIDModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaActividadesPDIByEvaluadoIdByAnio", ex, EmpresaId + "/" + EvaluadoId + "/" + InAnio);
                throw;
            }
        }
        public async Task<TBL_com_ActividadesPIDModels> CreateActividadesPID(TBL_com_ActividadesPIDModels objCreate)
        {
            try
            {
                _context.TBL_com_ActividadesPID.Add(_mapper.Map<tbl_com_ActividadesPIDEntities>(objCreate));
                await _context.SaveChangesAsync();
                var ObjResult = await _context.TBL_com_ActividadesPID.OrderByDescending(e => e.InIdTipoActividad).FirstOrDefaultAsync();
                return _mapper.Map<TBL_com_ActividadesPIDModels>(ObjResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("CreateActividadesPID", ex, JsonConvert.SerializeObject(objCreate));
                throw;
            }
        }
    }
}
