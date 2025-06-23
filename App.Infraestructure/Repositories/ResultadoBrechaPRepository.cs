using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblGhu;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories
{
    public class ResultadoBrechaPRepository : IResultadoBrechaPRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public ResultadoBrechaPRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaPById(int RelFuncSolicitudPId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_ResultadoBrechaP.AsNoTracking()
                    .Where(x => x.RelFuncSolicitudPId == RelFuncSolicitudPId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_ResultadoBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaResultadoBrechaPById", ex, RelFuncSolicitudPId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_ResultadoBrechaPModels>> GetListaResultadoBrechaP(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_ResultadoBrechaP.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_ResultadoBrechaPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaResultadoBrechaP", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels objCreate)
        {
            try
            {
                _context.TBL_ghu_ResultadoBrechaP.Add(_mapper.Map<tbl_ghu_ResultadoBrechaPEntities>(objCreate));
                await _context.SaveChangesAsync();
                var ObjResult = await _context.TBL_ghu_ResultadoBrechaP.OrderByDescending(e => e.ResultadoBrechaId).FirstOrDefaultAsync();
                return _mapper.Map<Tbl_ghu_ResultadoBrechaPModels>(ObjResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("PostResultadosBrechaP", ex, JsonConvert.SerializeObject(objCreate));
                throw;
            }
        }
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PutResultadoBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            var UpdateRegistro = _context.TBL_ghu_ResultadoBrechaP.FirstOrDefault(p => p.ResultadoBrechaId == ObjUpdate.ResultadoBrechaId);
            try
            {
                if (UpdateRegistro != null)
                {
                    #region Update
                    UpdateRegistro.PreguntaId = ObjUpdate.PreguntaId;
                    UpdateRegistro.UsuarioAnalisisBrecha = ObjUpdate.UsuarioAnalisisBrecha;
                    UpdateRegistro.TipoPregunta = ObjUpdate.TipoPregunta;
                    UpdateRegistro.TemaBrecha = ObjUpdate.TemaBrecha;
                    UpdateRegistro.RelFuncSolicitudPId = ObjUpdate.RelFuncSolicitudPId;
                    UpdateRegistro.PadreId = ObjUpdate.PadreId;
                    UpdateRegistro.HijoId = ObjUpdate.HijoId;
                    UpdateRegistro.TextoPregunta = ObjUpdate.TextoPregunta;
                    UpdateRegistro.TextoSMultiple = ObjUpdate.TextoSMultiple;
                    UpdateRegistro.RespuestaAbierta = ObjUpdate.RespuestaAbierta;
                    UpdateRegistro.ResultadoSMultiple = ObjUpdate.ResultadoSMultiple;
                    #endregion
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("PutResultadoBrechaP", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
            return _mapper.Map<Tbl_ghu_ResultadoBrechaPModels>(UpdateRegistro);
        }
    }
}
