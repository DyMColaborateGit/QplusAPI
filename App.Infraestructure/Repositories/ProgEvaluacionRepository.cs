using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace App.Infraestructure.Repositories;

public class ProgEvaluacionRepository: IProgEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;

    public ProgEvaluacionRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Tbl_com_ProgEvaluacionModels> ObjProgEvaluacion(long evaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .FirstOrDefaultAsync(x => x.InIdEvaluacion == evaluacionId);
            return _mapper.Map<Tbl_com_ProgEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjProgEvaluacion", ex, evaluacionId.ToString());
            throw;
        }
    }

    public async Task<ResponseTbl_com_ProgEvaluacionModels> ObjProgEvaluacionByMasivas(long evaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InIdEvaluacion == evaluacionId)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj).FirstOrDefaultAsync();
            return _mapper.Map<ResponseTbl_com_ProgEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjProgEvaluacionByMasivas", ex, evaluacionId.ToString());
            throw;
        }
    }

    public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesTalentosFuncionarios(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, 
        int Numeromapatalento, string EvaluadorId, long EvaluadoId, bool BEstado)
    {
        try
        {
            string cedula = "-1";
            if (EvaluadoId != -1)
            {
                cedula = EvaluadoId.ToString();
            }
            else
            {
                cedula = EvaluadorId;
            }

            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == InAnio && x.EvaluadObj.EmpresaId == EmpresaId && x.TipoEvaluacion == 1 && x.TipoValoracionId == 1 && x.BEstado == BEstado && x.NumeroMapaTalento == Numeromapatalento)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj)
            .ToListAsync();

            if (ZonaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoDireccion == ZonaId).Distinct().ToList();
            }
            if (OficinaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoGerencia == OficinaId).Distinct().ToList();
            }
            if (cedula != "-1" && EvaluadorId != null && EvaluadorId != "0" && EvaluadorId != "")
            {
                objResult = objResult.Where(p => p.InIdEvaluador.ToString().ToLower().Contains(cedula)).Distinct().ToList();
            }
            //if (EvaluadorId != null && EvaluadorId != "0" && EvaluadorId != "")
            //{
            //    objResult = objResult.Where(p => p.InIdEvaluador.ToString().ToLower().Contains(EvaluadorId.ToLower())).Distinct().ToList();
            //}

            return _mapper.Map<List<ResponseTbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesTalentosFuncionarios", ex, EmpresaId + "/" + InAnio + "/" + ZonaId + "/" + OficinaId + "/" + ProcesoId + "/" + Numeromapatalento + "/" + EvaluadorId + "/" + EvaluadoId + "/" + BEstado);
            throw;
        }
    }

    public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesTalentosFuncionariosM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId,
        int NumeromapatalentoM, string EvaluadorId, long EvaluadoId, bool BEstado)
    {
        try
        {
            string cedula = "-1";
            if (EvaluadoId != -1)
            {
                cedula = EvaluadoId.ToString();
            }
            else
            {
                cedula = EvaluadorId;
            }

            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == InAnio && x.EvaluadObj.EmpresaId == EmpresaId && x.TipoEvaluacion == 1 && x.TipoValoracionId == 1 && x.BEstado == BEstado && x.NumeroMapaTalentoM == NumeromapatalentoM)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj)
            .ToListAsync();

            if (ZonaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoDireccion == ZonaId).Distinct().ToList();
            }
            if (OficinaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoGerencia == OficinaId).Distinct().ToList();
            }
            if (cedula != "-1" && EvaluadorId != null && EvaluadorId != "0" && EvaluadorId != "")
            {
                objResult = objResult.Where(p => p.InIdEvaluador.ToString().ToLower().Contains(cedula)).Distinct().ToList();
            }

            return _mapper.Map<List<ResponseTbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesTalentosFuncionariosM", ex, EmpresaId + "/" + InAnio + "/" + ZonaId + "/" + OficinaId + "/" + ProcesoId + "/" + NumeromapatalentoM + "/" + EvaluadorId + "/" + EvaluadoId + "/" + BEstado);
            throw;
        }
    }

    public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesAnioEvaluadorId(int Anio, long EvaluadorId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == Anio && x.TipoEvaluacion == 1 && x.TipoValoracionId == 1 && x.BEstado == true && x.InIdEvaluador == EvaluadorId)
            .ToListAsync();
            objResult = objResult.OrderBy(p => p.NomEvaluado).ToList();
            return _mapper.Map<List<ResponseTbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesAnioEvaluadorId", ex, Anio + "/" + EvaluadorId);
            throw;
        }
    }

    public async Task<Tbl_com_ProgEvaluacionModels> ObjProgEvaluacionPadre(long InIdEvaluado, int Anio, int MesIni, int MesFin, int EmpresaId, int TipoEvaluacion, int TipoValoracionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion
            .FirstOrDefaultAsync(x => x.InIdEvaluado == InIdEvaluado && x.TipoValoracionId == TipoValoracionId && x.TipoEvaluacion == TipoEvaluacion && x.MesFin == MesFin && x.MesIni == MesIni && x.InAno == Anio);
            return _mapper.Map<Tbl_com_ProgEvaluacionModels>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ObjProgEvaluacionPadre", ex, InIdEvaluado + "/" + Anio + "/" + MesIni + "/" + MesFin + "/" + EmpresaId + "/"+ TipoEvaluacion + "/" + TipoValoracionId);
            throw;
        }
    }

    public async Task<List<Tbl_com_ProgEvaluacionModels>> ListEvaluacionesHeredadas(long Evaluado, int EmpresaId, int Anio, int MesIni, int MesFin)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.IdPadre == Evaluado && x.InAno == Anio && x.MesIni == MesIni && x.MesFin == MesFin && x.BEstado == true && x.EvaluadObj.EmpresaId == EmpresaId)
            .ToListAsync();
            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesHeredadas", ex, Evaluado +"/"+ EmpresaId + "/" + Anio + "/" + MesIni + "/"+ MesFin);
            throw;
        }
    }


    public async Task<List<Tbl_com_ProgEvaluacionModels>> ListEvaluacionesAnio(int Anio, int TipoEvaluacion)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == Anio  && x.BEstado == true && x.TipoEvaluacion == TipoEvaluacion)
            .ToListAsync();
            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesAnio", ex, Anio + "/" + TipoEvaluacion);
            throw;
        }
    }

    public async Task<Tbl_com_ProgEvaluacionModels> UpdateProgEvaluacion(Tbl_com_ProgEvaluacionModels ObjUpdate)
    {
        var UpdateRegistro = _context.TBL_com_ProgEvaluacion.FirstOrDefault(p => p.InIdEvaluacion == ObjUpdate.InIdEvaluacion);
        try
        {
            if (UpdateRegistro != null)
            {
                #region Update
                UpdateRegistro.InTipoInstrumento = ObjUpdate.InTipoInstrumento;
                UpdateRegistro.InIdTipoNorma = ObjUpdate.InIdTipoNorma;
                UpdateRegistro.NomNorma = ObjUpdate.NomNorma;
                UpdateRegistro.InIdEvaluador = ObjUpdate.InIdEvaluador;
                UpdateRegistro.NomEvaluador = ObjUpdate.NomEvaluador;
                UpdateRegistro.CodigoCargo = ObjUpdate.CodigoCargo;
                UpdateRegistro.InIdEvaluado = ObjUpdate.InIdEvaluado;
                UpdateRegistro.NomEvaluado = ObjUpdate.NomEvaluado;
                UpdateRegistro.BLider = ObjUpdate.BLider;
                UpdateRegistro.MesIni = ObjUpdate.MesIni;
                UpdateRegistro.NomMesInicio = ObjUpdate.NomMesInicio;
                UpdateRegistro.MesFin = ObjUpdate.MesFin;
                UpdateRegistro.NomMesFin = ObjUpdate.NomMesFin;
                UpdateRegistro.InAno = ObjUpdate.InAno;
                UpdateRegistro.BEstado = ObjUpdate.BEstado;
                UpdateRegistro.BEstadoLider = ObjUpdate.BEstadoLider;
                UpdateRegistro.Resultado = ObjUpdate.Resultado;
                UpdateRegistro.Nivel = ObjUpdate.Nivel;
                UpdateRegistro.DescNivel = ObjUpdate.DescNivel;
                UpdateRegistro.Color = ObjUpdate.Color;
                UpdateRegistro.TotComp = ObjUpdate.TotComp;
                UpdateRegistro.CompEva = ObjUpdate.CompEva;
                UpdateRegistro.CalifComp = ObjUpdate.CalifComp;
                UpdateRegistro.PromComp = ObjUpdate.PromComp;
                UpdateRegistro.NivelComp = ObjUpdate.NivelComp;
                UpdateRegistro.ColorComp = ObjUpdate.ColorComp;
                UpdateRegistro.PorEvaComp = ObjUpdate.PorEvaComp;
                UpdateRegistro.TotIndi = ObjUpdate.TotIndi;
                UpdateRegistro.IndiEva = ObjUpdate.IndiEva;
                UpdateRegistro.PorEvaIndi = double.IsNaN(ObjUpdate.PorEvaIndi.GetValueOrDefault()) ? 0 : ObjUpdate.PorEvaIndi;
                UpdateRegistro.CalifIndi = ObjUpdate.CalifIndi;
                UpdateRegistro.PromIndi = ObjUpdate.PromIndi;
                UpdateRegistro.NivelIndi = ObjUpdate.NivelIndi;
                UpdateRegistro.ColorIndi = ObjUpdate.ColorIndi;
                UpdateRegistro.TipoEvaluacion = ObjUpdate.TipoEvaluacion;
                UpdateRegistro.MotivoAnalisis = ObjUpdate.MotivoAnalisis;
                UpdateRegistro.Concepto = ObjUpdate.Concepto ;
                UpdateRegistro.JustificacionConcepto = ObjUpdate.JustificacionConcepto;
                UpdateRegistro.UsuarioCreacion = ObjUpdate.UsuarioCreacion;
                UpdateRegistro.FechaCreacion = ObjUpdate.FechaCreacion;
                UpdateRegistro.UsuarioModificacion = ObjUpdate.UsuarioModificacion;
                UpdateRegistro.FechaModificacion = ObjUpdate.FechaModificacion;
                UpdateRegistro.FechaInicio = ObjUpdate.FechaInicio;
                UpdateRegistro.FechaFin = ObjUpdate.FechaFin;
                UpdateRegistro.FechaVencimiento = ObjUpdate.FechaVencimiento;
                UpdateRegistro.DiaVencimiento = ObjUpdate.DiaVencimiento;
                UpdateRegistro.ColorVencimiento = ObjUpdate.ColorVencimiento;
                UpdateRegistro.FechaEnvio = ObjUpdate.FechaEnvio;
                UpdateRegistro.DuracionContrato = ObjUpdate.DuracionContrato;
                UpdateRegistro.TipoValoracionId = ObjUpdate.TipoValoracionId;
                UpdateRegistro.EvaIndis = ObjUpdate.EvaIndis;
                UpdateRegistro.IdPadre = ObjUpdate.IdPadre;
                UpdateRegistro.IdPrgramacionEvaluacion = ObjUpdate.IdPrgramacionEvaluacion;
                UpdateRegistro.PesoIndi = ObjUpdate.PesoIndi;
                UpdateRegistro.PesoCompe = ObjUpdate.PesoCompe;
                UpdateRegistro.ResultadoADI = ObjUpdate.ResultadoADI;
                UpdateRegistro.TipoNivelEstrategico = ObjUpdate.TipoNivelEstrategico;
                UpdateRegistro.NivelCargo = ObjUpdate.NivelCargo;
                UpdateRegistro.PesoTec = ObjUpdate.PesoTec;
                UpdateRegistro.PromTec = ObjUpdate.PromTec;
                UpdateRegistro.ColorComt = ObjUpdate.ColorComt;
                UpdateRegistro.NivelComt = ObjUpdate.NivelComt;
                UpdateRegistro.NumeroMapaTalento = ObjUpdate.NumeroMapaTalento;
                UpdateRegistro.ColorMapaTalento = ObjUpdate.ColorMapaTalento;
                UpdateRegistro.CajaMapaTalento = ObjUpdate.CajaMapaTalento;
                UpdateRegistro.PesoTIG = ObjUpdate.PesoTIG;
                UpdateRegistro.PromTIG = ObjUpdate.PromTIG;
                UpdateRegistro.ColorTIG = ObjUpdate.ColorTIG;
                UpdateRegistro.NivelTIG = ObjUpdate.NivelTIG;
                UpdateRegistro.FechaCierre = DateTime.Now;
                UpdateRegistro.ObservacionGeneral = ObjUpdate.ObservacionGeneral;
                UpdateRegistro.NumeroMapaTalentoM = ObjUpdate.NumeroMapaTalentoM;
                UpdateRegistro.ColorMapaTalentoM = ObjUpdate.ColorMapaTalentoM;
                UpdateRegistro.CajaMapaTalentoM = ObjUpdate.CajaMapaTalentoM;
                UpdateRegistro.Mod_MT = ObjUpdate.Mod_MT;
                UpdateRegistro.Obs_Mod_MapaT = ObjUpdate.Obs_Mod_MapaT;
                UpdateRegistro.UbicacionMD = ObjUpdate.UbicacionMD;
                UpdateRegistro.UbicacionMD_M = ObjUpdate.UbicacionMD_M;
                UpdateRegistro.ColorNivelM = ObjUpdate.ColorNivelM;
                UpdateRegistro.NivelM = ObjUpdate.NivelM;
                UpdateRegistro.Obs_Nivel_MapaD = ObjUpdate.Obs_Nivel_MapaD;
                UpdateRegistro.Mod_MD = ObjUpdate.Mod_MD;
                UpdateRegistro.UsuarioModNivel = ObjUpdate.UsuarioModNivel;
                #endregion
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("UpdateProgEvaluacion", ex, JsonConvert.SerializeObject(ObjUpdate));
            throw;
        }
        return _mapper.Map<Tbl_com_ProgEvaluacionModels>(UpdateRegistro);
    }

    public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesNivelesDesempeno(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId,
        int UbicacionMD, string EvaluadorId, long EvaluadoId, bool BEstado)
    {
        try
        {
            string cedula = "-1";
            if (EvaluadoId != -1)
            {
                cedula = EvaluadoId.ToString();
            }
            else
            {
                cedula = EvaluadorId;
            }

            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == InAnio && x.EvaluadObj.EmpresaId == EmpresaId && x.TipoEvaluacion == 1 && x.TipoValoracionId == 1 && x.BEstado == true && x.UbicacionMD == UbicacionMD)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj)
            .ToListAsync();

            if (ZonaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoDireccion == ZonaId).Distinct().ToList();
            }
            if (OficinaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoGerencia == OficinaId).Distinct().ToList();
            }
            if (cedula != "-1" && EvaluadorId != null && EvaluadorId != "0" && EvaluadorId != "")
            {
                objResult = objResult.Where(p => p.InIdEvaluador.ToString().ToLower().Contains(cedula)).Distinct().ToList();
            }

            objResult = objResult.OrderBy(p => p.NomEvaluado).ToList();
            return _mapper.Map<List<ResponseTbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesTalentosFuncionarios", ex, EmpresaId + "/" + InAnio + "/" + ZonaId + "/" + OficinaId + "/" + ProcesoId + "/" + UbicacionMD + "/" + EvaluadorId + "/" + EvaluadoId + "/" + BEstado);
            throw;
        }
    }

    public async Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesNivelesDesempenoM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, int UbicacionMD_M, string EvaluadorId, 
        long EvaluadoId, bool BEstado)
    {
        try
        {
            string cedula = "-1";
            if (EvaluadoId != -1)
            {
                cedula = EvaluadoId.ToString();
            }
            else
            {
                cedula = EvaluadorId;
            }

            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == InAnio && x.EvaluadObj.EmpresaId == EmpresaId && x.TipoEvaluacion == 1 && x.TipoValoracionId == 1 && x.BEstado == true && x.UbicacionMD_M == UbicacionMD_M)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj)
            .ToListAsync();

            if (ZonaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoDireccion == ZonaId).Distinct().ToList();
            }
            if (OficinaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoGerencia == OficinaId).Distinct().ToList();
            }
            if (cedula != "-1" && EvaluadorId != null && EvaluadorId != "0" && EvaluadorId != "")
            {
                objResult = objResult.Where(p => p.InIdEvaluador.ToString().ToLower().Contains(cedula)).Distinct().ToList();
            }

            objResult = objResult.OrderBy(p => p.NomEvaluado).ToList();

            return _mapper.Map<List<ResponseTbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("ListEvaluacionesTalentosFuncionarios", ex, EmpresaId + "/" + InAnio + "/" + ZonaId + "/" + OficinaId + "/" + ProcesoId + "/" + UbicacionMD_M + "/" + EvaluadorId + "/" + EvaluadoId + "/" + BEstado);
            throw;
        }
    }
}
