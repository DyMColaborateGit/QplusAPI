using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblGhu;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App.Infraestructure.Repositories
{
    public class SolicitudPersonalRepository : ISolicitudPersonalRepository
    {
        private readonly ConnectContext _context;
        private readonly IMapper _mapper;

        public SolicitudPersonalRepository(ConnectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Tbl_ghu_SolicitudPersonalModels> GetObjSolicitudPersonalById(int SolicitudId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_SolicitudPersonal.AsNoTracking()
                    .Where(x => x.SolicitudId == SolicitudId)
                    .FirstOrDefaultAsync();
                return _mapper.Map<Tbl_ghu_SolicitudPersonalModels>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetObjSolicitudPersonalById", ex, SolicitudId.ToString());
                throw;
            }
        }
        public async Task<List<Tbl_ghu_SolicitudPersonalModels>> GetListaSolicitudesPersonal(int EmpresaId)
        {
            try
            {
                var objResult = await _context.TBL_ghu_SolicitudPersonal.AsNoTracking()
                    .Where(x => x.EmpresaId == EmpresaId)
                    .ToListAsync();
                return _mapper.Map<List<Tbl_ghu_SolicitudPersonalModels>>(objResult);
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("GetListaSolicitudesPersonal", ex, EmpresaId.ToString());
                throw;
            }
        }
        public async Task<Tbl_ghu_SolicitudPersonalModels> PutSolicitudPById(Tbl_ghu_SolicitudPersonalModels ObjUpdate)
        {
            var UpdateRegistro = _context.TBL_ghu_SolicitudPersonal.FirstOrDefault(p => p.SolicitudId == ObjUpdate.SolicitudId);
            try
            {
                if (UpdateRegistro != null)
                {
                    #region Update
                    UpdateRegistro.SolicitudId = ObjUpdate.SolicitudId;
                    UpdateRegistro.EmpresaId = ObjUpdate.EmpresaId;
                    UpdateRegistro.Solicitante = ObjUpdate.Solicitante;
                    UpdateRegistro.TipoSolicitud = ObjUpdate.TipoSolicitud;
                    UpdateRegistro.CargoDigitado = ObjUpdate.CargoDigitado;
                    UpdateRegistro.CodigoCargo = ObjUpdate.CodigoCargo;
                    UpdateRegistro.CargoJefe = ObjUpdate.CargoJefe;
                    UpdateRegistro.EstadoSolicitud = ObjUpdate.EstadoSolicitud;
                    UpdateRegistro.EstadoBrecha = ObjUpdate.EstadoBrecha;
                    UpdateRegistro.FechaSolicitud = ObjUpdate.FechaSolicitud;
                    UpdateRegistro.FechaSolicitudIngreso = ObjUpdate.FechaSolicitudIngreso;
                    UpdateRegistro.MacroProcesoId = ObjUpdate.MacroProcesoId;
                    UpdateRegistro.Id_proceso = ObjUpdate.Id_proceso;
                    UpdateRegistro.Id_producto = ObjUpdate.Id_producto;
                    UpdateRegistro.CantidadPersonasS = ObjUpdate.CantidadPersonasS;
                    UpdateRegistro.HorarioTrabajo = ObjUpdate.HorarioTrabajo;
                    UpdateRegistro.SalarioAsignado = ObjUpdate.SalarioAsignado;
                    UpdateRegistro.CentroCostos = ObjUpdate.CentroCostos;
                    UpdateRegistro.IdContrato = ObjUpdate.IdContrato;
                    UpdateRegistro.DuracionVinculacion = ObjUpdate.DuracionVinculacion;
                    UpdateRegistro.Ciudad = ObjUpdate.Ciudad;
                    UpdateRegistro.Requisitos = ObjUpdate.Requisitos;
                    UpdateRegistro.Funciones = ObjUpdate.Funciones;
                    UpdateRegistro.SolicitudCorreo = ObjUpdate.SolicitudCorreo;
                    UpdateRegistro.EquipoComputo = ObjUpdate.EquipoComputo;
                    UpdateRegistro.Portatil = ObjUpdate.Portatil;
                    UpdateRegistro.Escritorio = ObjUpdate.Escritorio;
                    UpdateRegistro.Observaciones = ObjUpdate.Observaciones;
                    UpdateRegistro.UsuarioCreacion = ObjUpdate.UsuarioCreacion;
                    UpdateRegistro.FechaCreacion = ObjUpdate.FechaCreacion;
                    UpdateRegistro.UsuarioModificacion = ObjUpdate.UsuarioModificacion;
                    UpdateRegistro.FechaModificacion = ObjUpdate.FechaModificacion;
                    #endregion
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ExceptionLogHelpers.LogException("PutSolicitudPById", ex, JsonConvert.SerializeObject(ObjUpdate));
                throw;
            }
            return _mapper.Map<Tbl_ghu_SolicitudPersonalModels>(UpdateRegistro);
        }
    }
}
