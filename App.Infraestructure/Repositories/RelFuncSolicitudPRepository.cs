using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories
{
    public class RelFuncSolicitudPRepository : IRelFuncSolicitudPRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public RelFuncSolicitudPRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Tbl_ghu_RelFuncSolicitudPModels> GetObjRelFuncSolicitudPById(int RelFuncSolicitudPId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RelFuncSolicitudP.AsNoTracking()
                    .Where(x => x.RelFuncSolicitudPId == RelFuncSolicitudPId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<Tbl_ghu_RelFuncSolicitudPModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjRelFuncSolicitudPById", ex, RelFuncSolicitudPId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudP(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RelFuncSolicitudP.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_RelFuncSolicitudPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRelFuncSolicitudP", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_RelFuncSolicitudPModels>> GetListaRelFuncSolicitudPBySolicitudId(int SolicitudId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_RelFuncSolicitudP.AsNoTracking()
                    .Where(x => x.SolicitudId == SolicitudId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_RelFuncSolicitudPModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaRelFuncSolicitudPBySolicitudId", ex, SolicitudId.ToString());
                throw;
            }
        }
        public async Task<Tbl_ghu_RelFuncSolicitudPModels> PutRelFuncSolicitudP(Tbl_ghu_RelFuncSolicitudPModels ObjUpdate)
        {
            var UpdateRegistro = _context.TBL_ghu_RelFuncSolicitudP.FirstOrDefault(p => p.RelFuncSolicitudPId == ObjUpdate.RelFuncSolicitudPId);
            try
            {
                if (UpdateRegistro != null)
                {
                    #region Update
                    UpdateRegistro.RelFuncSolicitudPId = ObjUpdate.RelFuncSolicitudPId;
                    UpdateRegistro.EmpresaId = ObjUpdate.EmpresaId;
                    UpdateRegistro.Identificacion = ObjUpdate.Identificacion;
                    UpdateRegistro.SolicitudId = ObjUpdate.SolicitudId;
                    UpdateRegistro.RelFuncSolicitudPId = ObjUpdate.RelFuncSolicitudPId;
                    UpdateRegistro.Brecha = ObjUpdate.Brecha;
                    UpdateRegistro.TextoBrecha = ObjUpdate.TextoBrecha;
                    UpdateRegistro.UsuarioCreacion = ObjUpdate.UsuarioCreacion;
                    UpdateRegistro.FechaCreacion = ObjUpdate.FechaCreacion;
                    #endregion
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("PutRelFuncSolicitudP", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
            return _mapper.Map<Tbl_ghu_RelFuncSolicitudPModels>(UpdateRegistro);
        }
    }
}
