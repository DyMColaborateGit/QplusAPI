using App.Infraestructure.Connect;
using App.Infraestructure.Connect.Entities.TblGhu;
using App.Infraestructure.Connect.Entities.TblInd;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblAud;
using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
using App.Models.Models.TblInd;
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
        public async Task<Tbl_ghu_ResultadoBrechaPModels> ObjResultadoBrechaP(int ResultadoBrechaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_ResultadoBrechaP.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ResultadoBrechaId == ResultadoBrechaId);
                return _mapper.Map<Tbl_ghu_ResultadoBrechaPModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjResultadoBrechaP", ex, ResultadoBrechaId.ToString());
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
        public async Task<Tbl_ghu_ResultadoBrechaPModels> PostResultadosBrechaP(Tbl_ghu_ResultadoBrechaPModels ObjUpdate)
        {
            tbl_ghu_ResultadoBrechaPEntities CreateRegistro = _mapper.Map<tbl_ghu_ResultadoBrechaPEntities>(ObjUpdate);
            try
            {
                _context.TBL_ghu_ResultadoBrechaP.Add(CreateRegistro);
                await _context.SaveChangesAsync();
                var ObjResult = await _context.TBL_ghu_ResultadoBrechaP.OrderByDescending(e => e.ResultadoBrechaId).FirstOrDefaultAsync();
                return _mapper.Map<Tbl_ghu_ResultadoBrechaPModels>(ObjResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("PostResultadosBrechaP", ex, JsonConvert.SerializeObject(ObjUpdate));
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
