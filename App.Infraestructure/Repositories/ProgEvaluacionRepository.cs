using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Global;
using App.Models.Models.FileMove;
using App.Models.Models.TblCom;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace App.Infraestructure.Repositories;

public class ProgEvaluacionRepository: IProgEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IProgramacionMasivaEvaluacionesRepository _programacionMasivaEvaluacionesRepository;
    private readonly IFuncionariosRepository _funcionariosRepository;
    private readonly ICargosRepository _cargosRepository;
    private readonly ICargosProcesosRepository _cargosProcesosRepository;
    private readonly ITxtFormEvaluacionRepository _txtFormEvaluacionRepository;
    private readonly IResultadosEvaluacionRepository _resultadosEvaluacionRepository;
    private readonly IConsolidadoDesempenoRepository _consolidadoDesempenoRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IResultadosRepository _resultadosRepository;
    private readonly ITiposIndicadoresEstrategicosRepository _tiposIndicadoresEstrategicosRepository;
    private readonly ITotalIndEstCorporativosRepository _totalIndEstCorporativosRepository;
    private readonly ItotalUESRepository _totalUESRepository;
    private readonly IResultIndiCoporpRepository _resultIndiCoporpRepository;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultcomTecnicasRepository _resultcomTecnicasRepository;
    private readonly IEmpresasTitulosRepository _empresasTitulosRepository;
    private readonly ITotalAnalisisIndiADIRepository _totalAnalisisIndiADIRepository;
    private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;
    private readonly IEmpresasRepository _empresasRepository;

    public ProgEvaluacionRepository(ConnectContext context, IMapper mapper,
        IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository, IFuncionariosRepository funcionariosRepository, ICargosRepository cargosRepository,
        ICargosProcesosRepository cargosProcesosRepository, ITxtFormEvaluacionRepository txtFormEvaluacionRepository, IResultadosEvaluacionRepository resultadosEvaluacionRepository,
        IConsolidadoDesempenoRepository consolidadoDesempenoRepository, IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository, IResultadosRepository resultadosRepository,
        ITiposIndicadoresEstrategicosRepository tiposIndicadoresEstrategicosRepository, IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository,
        IResultcomTecnicasRepository resultcomTecnicasRepository, IEmpresasTitulosRepository empresasTitulosRepository, IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository,
        IEmpresasRepository empresasRepository, ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository, IResultIndiCoporpRepository resultIndiCoporpRepository,
        ITotalAnalisisIndiADIRepository totalAnalisisIndiADIRepository, ItotalUESRepository totalUESRepository)
    {
        _context = context;
        _mapper = mapper;
        _programacionMasivaEvaluacionesRepository = programacionMasivaEvaluacionesRepository;
        _funcionariosRepository = funcionariosRepository;
        _cargosRepository = cargosRepository;
        _cargosProcesosRepository = cargosProcesosRepository;
        _txtFormEvaluacionRepository = txtFormEvaluacionRepository;
        _resultadosEvaluacionRepository = resultadosEvaluacionRepository;
        _consolidadoDesempenoRepository = consolidadoDesempenoRepository;
        _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
        _resultadosRepository = resultadosRepository;
        _tiposIndicadoresEstrategicosRepository = tiposIndicadoresEstrategicosRepository;
        _totalIndEstCorporativosRepository = totalIndEstCorporativosRepository;
        _totalUESRepository = totalUESRepository;
        _resultIndiCoporpRepository = resultIndiCoporpRepository;
        _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
        _resultcomTecnicasRepository = resultcomTecnicasRepository;
        _empresasTitulosRepository = empresasTitulosRepository;
        _totalAnalisisIndiADIRepository = totalAnalisisIndiADIRepository;
        _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
        _empresasRepository = empresasRepository;
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

    public async Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesByParametrosBasicos(int EmpresaId, int InAnio, int MesInicio, int MesFinal)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
                .Include(x => x.EvaluadObj)
                .Include(x => x.PrgramacionMasivaObj)
                .Where(x => x.EvaluadObj.EmpresaId == EmpresaId &&
                x.BEstado == true &&
                x.TipoEvaluacion == 1 &&
                x.TipoValoracionId == 1 &&
                x.InAno == InAnio &&
                x.MesIni == MesInicio &&
                x.MesFin == MesFinal)
                .ToListAsync();

            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetListEvaluacionesByParametrosBasicos", ex, EmpresaId + "/" + InAnio + "/" + MesInicio + "/" + MesFinal);
            throw;
        }
    }

    public async Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesByParametros(int EmpresaId, int InAnio, int MesInicio, int MesFinal, int DireccionId, int OficinaId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
                .Where(x => x.EvaluadObj.EmpresaId == EmpresaId &&
                x.BEstado == true &&
                x.TipoEvaluacion == 1 &&
                x.TipoValoracionId == 1 &&
                x.InAno == InAnio &&
                x.MesIni == MesInicio &&
                x.MesFin == MesFinal)
                .Include(x => x.EvaluadObj)
                .Include(x => x.PrgramacionMasivaObj)
                .ToListAsync();

            if (DireccionId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoDireccion == DireccionId).Distinct().ToList();
            }
            if (OficinaId != -1)
            {
                objResult = objResult.Where(p => p.PrgramacionMasivaObj?.CodigoGerencia == OficinaId).Distinct().ToList();
            }

            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetListEvaluacionesByParametros", ex, EmpresaId + "/" + InAnio + "/" + MesInicio + "/" + MesFinal + "/" + DireccionId + "/" + OficinaId);
            throw;
        }
    }
    
    public async Task<List<Tbl_com_ProgEvaluacionModels>> GetListaProgEvaluacionByEvaluacionId(int EvaluacionId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion
                .AsNoTracking()
                .Where(x => x.InIdEvaluacion == EvaluacionId)
                .ToListAsync();

            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetListaProgEvaluacionByEvaluacionId", ex, EvaluacionId.ToString());
            throw;
        }
    }
    
    public async Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesFuncionarioByParametros(int EmpresaId, int InAnio, long EvaluadoId)
    {
        try
        {
            var objResult = await _context.TBL_com_ProgEvaluacion.AsNoTracking()
            .Where(x => x.InAno == InAnio && x.EvaluadObj.EmpresaId == EmpresaId && x.InIdEvaluado == EvaluadoId && x.InAno == InAnio)
            .Include(x => x.EvaluadObj)
            .Include(x => x.PrgramacionMasivaObj)
            .ToListAsync();

            return _mapper.Map<List<Tbl_com_ProgEvaluacionModels>>(objResult);
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GetListEvaluacionesFuncionarioByParametros", ex, EvaluadoId.ToString());
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
    
    private string ObtenerHexColor(string nombreArchivo)
    {
        if (string.IsNullOrEmpty(nombreArchivo)) return "#ccc"; // Gris si es nulo

        string nombre = nombreArchivo.ToLower();
        if (nombre.Contains("green")) return "#82E007"; // Verde
        if (nombre.Contains("blue")) return "#007BFF"; // Azul
        if (nombre.Contains("red")) return "#FF4136"; // Rojo
        if (nombre.Contains("yellow")) return "#FFDC00"; // Amarillo

        return "#ccc"; // Color por defecto
    }

    private string ObtenerHexColorCriterio(string colorEstilo)
    {
        if (string.IsNullOrEmpty(colorEstilo)) return "background-color:#FFFFFF;color:#000000;"; // Gris si es nulo

        //string nombre = colorEstilo.ToLower();
        if (colorEstilo.Contains("white")) return "background-color:#FFFFFF; color:#000000;";
        if (colorEstilo.Contains("green")) return "background-color:#92D050; color:#FFFFFF;";
        if (colorEstilo.Contains("blue")) return "background-color:#00B0F0; color:#FFFFFF;"; // Azul
        if (colorEstilo.Contains("red")) return "background-color:#FF0000; color:#FFFFFF;"; // Rojo
        if (colorEstilo.Contains("yellow")) return "backgrounnd-color:#FFFF00; color:#000000"; // Amarillo
        if (colorEstilo.Contains("background-color:#92D050;")) return "background-color:#92D050; color:#FFFFFF;";
        if (colorEstilo.Contains("background-color:#00B0F0;")) return "background-color:#00B0F0; color:#FFFFFF;"; // Azul
        if (colorEstilo.Contains("background-color:#FF0000;")) return "background-color:#FF0000; color:#FFFFFF;"; // Rojo
        if (colorEstilo.Contains("background-color:#FFFF00;")) return "background-color:#FFFF00; color:#000000;"; // Amarillo

        return "background-color:#FFFFFF;color:#000000;"; // Color por defecto
    }

    public async Task<string> GeneradorBodyADIByEvaluacionId(FilePdfADIPdiModel pdiAdiObj)
    {
        try
        {
            var progEva = pdiAdiObj.Evaluacion;
            var ZonaOficina = await _programacionMasivaEvaluacionesRepository.GetDataProgramacionByID((int)progEva.IdPrgramacionEvaluacion);
            var emp = await _funcionariosRepository.GetObjFuncionarioByIdentificacion((long)progEva.InIdEvaluado);
            int empresa = emp.EmpresaId;
            int codigoCargo = (int)progEva.CodigoCargo;
            int nivelCargo = (int)progEva.NivelCargo;
            int tipoNivel = (int)progEva.TipoNivelEstrategico;
            var dataCargo = await _cargosRepository.GetDataCargoByCodigo(codigoCargo, empresa);
            string nombreCargo = "";
            if (dataCargo != null)
            {
                string codigo = dataCargo.Codigo.ToString() ?? "";
                string nombre = dataCargo.VcNombre ?? "";

                nombreCargo = (string.IsNullOrEmpty(codigo))
                    ? nombre
                    : $"{codigo} - {nombre}";
            }
            var dataCargoproceso = await _cargosProcesosRepository.GetProcesoPerteneceByIdCargo(codigoCargo, empresa);
            string nombreCargoProceso = "";
            if (dataCargoproceso != null)
            {
                nombreCargoProceso = dataCargoproceso.ProcesosObj.Proceso ?? "";
            }
            // var texto = "<p style=\"text-decoration-color: initial; margin: 0px; color: #000000; font-size: 14.6667px; font-family: Calibri, sans-serif; text-align: center;\"><strong><span style=\"font-size: 12pt; font-family: Arial, sans-serif; color: #2b2b2b;\">Califique la frecuencia en que se evidencia el comportamiento, según la siguiente escala:</span></strong></p><p style=\"text-decoration-color: initial; margin: 0px; color: #000000; font-size: 14.6667px; font-family: Calibri, sans-serif; text-align: center;\"><br /></p><div style=\"text-align: center;\"><img src=\"/UserFiles/Imagenes/escala(1).png\" alt=\"\" /></div>";
            var textoAdi = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, 1, (int)progEva.TipoValoracionId, (int)progEva.InAno);
            var textoAdi2 = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, 2, (int)progEva.TipoValoracionId, (int)progEva.InAno);
            textoAdi.Texto = textoAdi.Texto.Replace("<img src=\"/UserFiles/Imagenes/escala(1).png\" alt=\"\" />", "<img src=\"https://laboratorio1.qplusnube2.co/UserFiles/Imagenes/escala(1).png\" alt =\"\" />");
            textoAdi2.Texto = textoAdi2.Texto.Replace("<img src=\"/UserFiles/Imagenes/indis.png\" alt=\"\" />", "<img src=\"https://laboratorio1.qplusnube2.co/UserFiles/Imagenes/indis.png\" alt =\"\" />");
            var ADI = await _resultadosEvaluacionRepository.ListFormEvaluacionByEvaluacionId(progEva.InIdEvaluacion);
            var nivelCompe = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(progEva.InIdEvaluacion, 1);
            var indicadoresGestion = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresByEvaluacionId(progEva.InIdEvaluacion);
            var NombreZonaOficina = await _empresasTitulosRepository.ObjEmpresasTitulos(empresa);
            var dataEmpresa = await _empresasRepository.ObjEmpresa(empresa);
            var tituloIndEstra = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 1);
            string nombreIndEstra = "" + tituloIndEstra.tipoIndicadorEstrategico;
            var indiCorporativos = await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(progEva, empresa);
            var ResultIndiCorporativos = await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(progEva, empresa);
            var tituloUes1 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 2);
            string nombreTituloUes1 = "" + tituloUes1.tipoIndicadorEstrategico;
            Tbl_com_ProgEvaluacionModels tieneData = null;
            var dataPadre = await ObjProgEvaluacionPadre((long)progEva.IdPadre, (int)progEva.InAno, (int)progEva.MesIni, (int)progEva.MesFin, empresa, (int)progEva.TipoEvaluacion, (int)progEva.TipoValoracionId);
            if (dataPadre == null)
            {
                tieneData = progEva;
            }
            else
            {
                tieneData = dataPadre;
            }
            var UES1 = await _totalUESRepository.GetTotalAnalisisUES1(tieneData, empresa, (int)tieneData.TipoNivelEstrategico, (int)progEva.NivelCargo, progEva);
            var indicadoresExtra = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(tieneData.InIdEvaluacion);
            var tituloUes2 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 3);
            string nombreTituloUes2 = tituloUes2.tipoIndicadorEstrategico;
            var TotalAnaIndiEstra = await _totalAnalisisIndiADIRepository.TotalAnalisisIndicadoresEstrategicosADI(progEva, empresa);
            var AnalisisRendi = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(progEva.InIdEvaluacion, 2);
            var listaTecnicas = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(progEva.InIdEvaluacion);
            int comptc = listaTecnicas?.Count() ?? 0;
            var textoTecnicas = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, (int)progEva.InAno, 3, (int)progEva.TipoValoracionId);
            var ResultCompeTecnicas = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(progEva.InIdEvaluacion);
            var TotalCompTecnicas = await GetListaProgEvaluacionByEvaluacionId(progEva.InIdEvaluacion);
            var ResultAnalisisDesarrollo = await _consolidadoDesempenoRepository.GetListaConsolidadosByEvaluacionId(progEva.InIdEvaluacion);
            var ConcepFinalAnaDesarrollo = await GetListaProgEvaluacionByEvaluacionId(progEva.InIdEvaluacion);
            var gestion = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(empresa, nivelCargo, 1);
            bool gestionVisible = gestion.VisibleADI;
            var estretegicos = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(empresa, nivelCargo, 2);
            bool estretegicosVisible = estretegicos.VisibleADI;
            var UES2 = await _totalUESRepository.GetTotalAnalisisUES2(progEva, empresa);
            var indicadoresExtra2 = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(tieneData.InIdEvaluacion);

            // Construcción del HTML
            string htmlPdf = "";

            string tablaInicio = $@"
            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                <th style=""border: 1px solid #dddddd; width: 10%; padding: 8px; text-align: center;"">Fecha Cierre</th>
                <th style=""border: 1px solid #dddddd; width: 20%; padding: 8px; text-align: center;"">Cargo</th>
                <th style=""border: 1px solid #dddddd; width: 30%; padding: 8px; text-align: center;"">Evaluador</th>
                <th style=""border: 1px solid #dddddd; width: 20%; padding: 8px; text-align: center;"">{NombreZonaOficina.Oficina}</th>
                <th style=""border: 1px solid #dddddd; width: 20%; padding: 8px; text-align: center;"">{NombreZonaOficina.Zona}</th>
            </tr>";

            string filaDatos = $@"
            <tr style=""border: 1px solid #dddddd;"">
                <td style=""border: 1px solid #dddddd; width: 10%; text-align: center; padding: 8px;"">{progEva.FechaCierre?.ToShortDateString()}</td>
                <td style=""border: 1px solid #dddddd; width: 20%; text-align: center; padding: 8px;"">{nombreCargo}</td>
                <td style=""border: 1px solid #dddddd; width: 30%; text-align: center; padding: 8px;"">{progEva.NomEvaluador}</td>
                <td style=""border: 1px solid #dddddd; width: 20%; text-align: center; padding: 8px;"">{ZonaOficina?.OficinaObj?.Oficina}</td>
                <td style=""border: 1px solid #dddddd; width: 20%; text-align: center; padding: 8px;"">{ZonaOficina?.ZonaObj?.Zona}</td>
            </tr>
            </table><br />";

            htmlPdf += tablaInicio + filaDatos;

            // condición si es confandi mayor al 2023 y comfandi
            if (progEva.FechaCreacion?.Year > 2023 && dataEmpresa.Empresa == "Comfandi")
            {
                // Análisis Competencia
                htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">1. Análisis de Competencias</h3>";

                htmlPdf += $@"
                <table style=""width: 100%; border-collapse: collapse; font-family: arial, sans-serif;"">
                    <tr>
                        <td colspan=""6"" style=""padding: 10px; vertical-align: top; text-align: center; font-size: 13px;"">
                            {textoAdi.Texto}
                        </td><br/>
                    </tr>
                </table><br/>";

                foreach (var item in ADI)
                {
                    string colorHex = ObtenerHexColor(item.Color);

                    string circuloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 18px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 50%; 
                        border: 1px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                    htmlPdf += $@"
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 70%; text-align: center;"">Competencia</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 20%; text-align: center;"">Nivel de Desarrollo</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 10%; text-align: center;""></th>
                        </tr>
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;""><strong>{item.Normasobj.VcCompetencia}</strong></td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{item.Nivel}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{circuloHtml}</td>
                        </tr>";

                    var criterios = await _resultadosRepository.GetResultadosEvaluacionListaByEvaluacionId(progEva.InIdEvaluacion, item.NormaId);

                    if (criterios != null && criterios.Any())
                    {
                        StringBuilder filasCriterios = new StringBuilder();

                        foreach (var criterio in criterios)
                        {
                            string iconoHtml = @"<span style='display: inline-block; width: 16px; height: 16px; background-color: black; color: white; border-radius: 50%; text-align: center; line-height: 16px; font-size: 10px; vertical-align: middle; margin-right: 8px;'>&#10004;</span>";
                            string colorCriterioHex = ObtenerHexColorCriterio(criterio.Color);

                            filasCriterios.Append($@"
                            <tr>
                                <td style=""border: none; padding: 6px 15px; text-align: left; font-size: 12px;"">
                                    {iconoHtml} {criterio.Criterio}
                                </td>
                                <td style=""padding: 6px 10px; text-align: right; border: none; width: 150px; "">
                                    <span style=""border: 1px solid #ccc; padding: 2px 8px; display: inline-block; width: 150px; text-align: center; border-radius: 3px; {colorCriterioHex};"">
                                        {criterio.Escalanivel}
                                    </span>
                                </td>
                                <td style=""border: none; padding: 6px 8px; text-align: center;""></td>
                            </tr>");
                        }

                        htmlPdf += $@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td colspan=""3"" style=""padding: 5px 0;"">
                                <table style=""width: 100%; border-collapse: collapse;"">
                                    {filasCriterios.ToString()}
                                </table>
                            </td>
                        </tr>";
                    }
                    htmlPdf += "</table><br />";
                }
            }
            else
            {
                // Análisis Competencia
                htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">1. Análisis de Competencias</h3>";

                htmlPdf += $@"
                <table style=""width: 100%; border-collapse: collapse; font-family: arial, sans-serif; margin-bottom: 10px;"">
                    <tr>
                        <td style=""adding: 10px; text-align: center; font-size: 13px;"">
                            {textoAdi.Texto}
                        </td>
                    </tr>
                </table>";

                foreach (var item in ADI)
                {
                    string colorHex = ObtenerHexColor(item.Color);
                    string circuloHtml = $@"<span style=""display: inline-block; width: 18px; height: 18px; background-color: {colorHex}; border-radius: 50%; border: 1px solid #444; vertical-align: middle;""></span>";

                    htmlPdf += $@"
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                        <tr style=""background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 75%; text-align: center;"">Competencia</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 20%; text-align: center;"">Nivel de Desarrollo</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; width: 5%;""></th>
                        </tr>
                        <tr>
                            <td style=""border: 1px solid #dddddd; padding: 10px; text-align: left;""><strong>{item.Normasobj.VcCompetencia}</strong></td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{item.Nivel}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{circuloHtml}</td>
                        </tr>";

                    var criterios = await _resultadosRepository.GetResultadosEvaluacionListaByEvaluacionId(progEva.InIdEvaluacion, item.NormaId);

                    if (criterios != null && criterios.Any())
                    {
                        StringBuilder filasCriterios = new StringBuilder();
                        foreach (var criterio in criterios)
                        {

                            string iconoHtml = @"<span style='display: inline-block; width: 16px; height: 16px; background-color: black; color: white; border-radius: 50%; text-align: center; line-height: 16px; font-size: 10px; vertical-align: middle; margin-right: 8px;'>&#10004;</span>";
                            string colorCriterioHex = ObtenerHexColorCriterio(criterio.Color);

                            filasCriterios.Append($@"
                            <tr>
                                <td style=""padding: 6px 15px; text-align: left; font-size: 12px; border: none;"">
                                    {iconoHtml} {criterio.Criterio}
                                </td>
                                <td style=""padding: 6px 10px; text-align: right; border: none; width: 150px; "">
                                    <span style=""border: 1px solid #ccc; padding: 2px 8px; display: inline-block; width: 150px; text-align: center; border-radius: 3px; {colorCriterioHex};"">
                                        {criterio.Escalanivel}
                                    </span>
                                </td>
                                <td style=""border: none;""></td>
                            </tr>");
                        }

                        htmlPdf += $@"
                    <tr>
                        <td colspan=""3"" style=""border: 1px solid #dddddd; padding: 5px 0;"">
                            <table style=""width: 100%; border-collapse: collapse;"">
                                {filasCriterios.ToString()}
                            </table>
                        </td>
                    </tr>";
                    }

                    htmlPdf += $@"
                    <tr style=""background-color: #f9f9f9;"">
                        <td colspan=""3"" style=""border: 1px solid #dddddd; padding: 8px; font-size: 12px;"">
                            <strong>Observaciones Análisis Competencia:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""3"" style=""border: 1px solid #dddddd; padding: 10px; font-size: 12px; min-height: 40px;"">
                            {item.Observaciones ?? "Sin observaciones"}
                        </td>
                    </tr>";

                    htmlPdf += "</table>";
                }
            }
            // Resultados Análisis Competencia
            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">Resultados Análisis Competencias</h3>";

            string tablaResultadosHeader = $@"
            <br/>
            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 75%;"">Competencia</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 20%;"">Nivel de Desarrollo</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; width: 5%;""></th>
                </tr>";

            StringBuilder filasResultados = new StringBuilder();

            if (ADI != null)
            {
                foreach (var ResultadoAC in ADI)
                {
                    string colorHex = ObtenerHexColor(ResultadoAC.Color);

                    // AJUSTE: Círculo perfecto (como se ve en la imagen image_2c523b.png)
                    string circuloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 18px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 50%; 
                        border: 1px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                    filasResultados.Append($@"
                    <tr style=""border: 1px solid #dddddd;"">
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 10px; font-size: 12px;"">
                            {ResultadoAC.Normasobj.VcCompetencia}
                        </td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; font-size: 12px;"">
                            {ResultadoAC.Nivel}
                        </td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                            {circuloHtml}
                        </td>
                    </tr>");
                }
            }

            htmlPdf += tablaResultadosHeader + filasResultados.ToString() + "</table><br />";

            // Total Nivel de Competencias
            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">Total Nivel de Competencias</h3>";

            StringBuilder totalNivelRows = new StringBuilder();
            totalNivelRows.Append(@"<table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">");

            if (nivelCompe != null)
            {
                foreach (var totalNivelCompe in nivelCompe)
                {
                    // 1. Capturamos el color
                    string colorHex = ObtenerHexColor(totalNivelCompe.Color);

                    // 2.óvalo con CSS
                    string ovaloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 35px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 12px; 
                        border: 1px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                    totalNivelRows.Append($@"
                    <tr style=""border: 1px solid #dddddd;"">
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 10px;"">
                            {totalNivelCompe.Nivel}
                        </td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 5px; width: 60px;"">
                            {ovaloHtml}
                        </td>
                    </tr>");
                }
            }

            totalNivelRows.Append("</table><br />");
            htmlPdf += totalNivelRows.ToString();
            // Análisis del Rendimiento
            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">2. Análisis del Rendimiento</h3>";

            htmlPdf += $@"
            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%;"">
                <tr>
                    <td style=""padding: 10px; vertical-align: top; text-align: left;"">
                        <br/>
                        {textoAdi2.Texto}
                    </td>
                </tr>
            </table><br/><br/>";

            if (nivelCargo == 1)
            {
                if (tipoNivel == 1)
                {
                    htmlPdf += $@"
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            Indicadores Estratégicos
                        </h3>
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 10px 0 5px 0;"">
                            {nombreIndEstra}
                        </h3>";

                    StringBuilder tablaPesoTotal = new StringBuilder();
                    tablaPesoTotal.Append($@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 350px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 33%;"">Año</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 33%;"">Peso</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 34%;"">Total</th>
                                </tr>");

                    if (indiCorporativos != null)
                    {
                        foreach (var indiCorp in indiCorporativos)
                        {
                            tablaPesoTotal.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Anio}
                                </td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Peso:N2}
                                </td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Total:N2}
                                </td>
                            </tr>");
                        }
                    }

                    tablaPesoTotal.Append("</table><br />");

                    htmlPdf += tablaPesoTotal.ToString();

                    string tablaIndicadoresExtraCabecera = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                            </tr>";

                    StringBuilder filasIndicadoresExtra = new StringBuilder();

                    if (ResultIndiCorporativos != null)
                    {
                        foreach (var indiCorp in ResultIndiCorporativos)
                        {
                            filasIndicadoresExtra.Append($@"
                                <tr style=""border: 1px solid #dddddd;"">
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiCorp.MastIndicadoresobj.VcNombreIndicador}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Peso}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Resultado}</td>
                                </tr>");
                        }
                    }

                    string tablaIndicadoresExtraCierre = @"</table><br />";

                    htmlPdf += tablaIndicadoresExtraCabecera + filasIndicadoresExtra.ToString() + tablaIndicadoresExtraCierre;
                }
                else if (tipoNivel == 2)
                {
                    // Indicadores Estratégicos
                    htmlPdf += $@"
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            Indicadores Estratégicos
                        </h3>
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 10px 0 5px 0;"">
                            {nombreIndEstra}
                        </h3>";

                    StringBuilder tablaPesoTotal = new StringBuilder();
                    tablaPesoTotal.Append($@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 350px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 33%;"">Año</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 33%;"">Peso</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center; width: 34%;"">Total</th>
                                </tr>");

                    if (indiCorporativos != null)
                    {
                        foreach (var indiCorp in indiCorporativos)
                        {
                            tablaPesoTotal.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Anio}
                                </td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Peso:N2}
                                </td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {indiCorp.Total:N2}
                                </td>
                            </tr>");
                        }
                    }

                    tablaPesoTotal.Append("</table><br />");

                    htmlPdf += tablaPesoTotal.ToString();

                    string tablaIndicadoresExtraCabecera = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                            </tr>";

                    StringBuilder filasIndicadoresExtra = new StringBuilder();

                    if (ResultIndiCorporativos != null)
                    {
                        foreach (var indiCorp in ResultIndiCorporativos)
                        {
                            filasIndicadoresExtra.Append($@"
                                <tr style=""border: 1px solid #dddddd;"">
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiCorp.MastIndicadoresobj.VcNombreIndicador}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Peso}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Resultado}</td>
                                </tr>");
                        }
                    }

                    string tablaIndicadoresExtraCierre = @"</table><br />";

                    htmlPdf += tablaIndicadoresExtraCabecera + filasIndicadoresExtra.ToString() + tablaIndicadoresExtraCierre;

                    htmlPdf += $@"
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            {nombreTituloUes1}
                        </h3>";

                    decimal pesoTotal = UES1.peso;
                    decimal totalCumplimiento = UES1.Total;

                    htmlPdf += $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 300px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Total</th>
                        </tr>
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{pesoTotal:N2}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{totalCumplimiento:N2}</td>
                        </tr>
                    </table>";

                    // --- Tabla Detalle de Indicadores Extra ---
                    string tablaIndicadoresExtrateCabecera = $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Clase</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                        </tr>";

                    StringBuilder filasIndicadoresExtrate = new StringBuilder();

                    if (indicadoresExtra != null)
                    {
                        foreach (var indiExtra in indicadoresExtra)
                        {
                            filasIndicadoresExtrate.Append($@"
                    <tr style=""border: 1px solid #dddddd;"">
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.ClaseIndicador}</td>
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.Indicador}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                    </tr>");
                        }
                    }
                    htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";
                }
                else
                {
                    // Indicadores Estratégicos
                    htmlPdf += $@"
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            Indicadores Estratégicos
                        </h3>
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 10px 0 5px 0;"">
                            {nombreIndEstra}
                        </h3>";

                    string tablaPrincipalPesoTotalAño = $@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 300px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 33%;"">Año</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 33%;"">Peso</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 34%;"">Total</th>
                                </tr>";

                    StringBuilder filasPrincipal = new StringBuilder();

                    if (indiCorporativos != null)
                    {
                        foreach (var indiCorp in indiCorporativos)
                        {
                            filasPrincipal.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Anio}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Peso:N2}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Total:N2}</td>
                            </tr>");
                        }
                    }

                    htmlPdf += tablaPrincipalPesoTotalAño + filasPrincipal.ToString() + "</table><br />";

                    // --- Tabla Indicadores Extra
                    string tablaIndicadoresExtraCabecera = $@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                                </tr>";

                    StringBuilder filasExtra = new StringBuilder();

                    if (ResultIndiCorporativos != null)
                    {
                        foreach (var indiCorp in ResultIndiCorporativos)
                        {
                            filasExtra.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiCorp.MastIndicadoresobj.VcNombreIndicador ?? ""}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Peso}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiCorp.Resultado}</td>
                            </tr>");
                        }
                    }

                    htmlPdf += tablaIndicadoresExtraCabecera + filasExtra.ToString() + "</table><br />";
                    htmlPdf += $@"
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            {nombreTituloUes1}
                        </h3>";

                    decimal pesoTotal = UES1.peso;
                    decimal totalCumplimiento = UES1.Total;

                    htmlPdf += $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 300px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Total</th>
                        </tr>
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{pesoTotal:N2}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{totalCumplimiento:N2}</td>
                        </tr>
                    </table>";

                    string tablaIndicadoresExtrateCabecera = $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Clase</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                        </tr>";

                    StringBuilder filasIndicadoresExtrate = new StringBuilder();

                    if (indicadoresExtra != null)
                    {
                        foreach (var indiExtra in indicadoresExtra)
                        {
                            filasIndicadoresExtrate.Append($@"
                    <tr style=""border: 1px solid #dddddd;"">
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.ClaseIndicador}</td>
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.Indicador}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                    </tr>");
                        }
                    }
                    htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";

                    htmlPdf += $@"
                <br />
                <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                    {nombreTituloUes2}
                </h3>";

                    decimal pesoTotal2 = UES2.peso;
                    decimal totalCumplimiento2 = UES2.Total;

                    htmlPdf += $@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 300px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Peso</th>
                                    <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Total</th>
                                </tr>
                                <tr style=""border: 1px solid #dddddd;"">
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{pesoTotal2:N2}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{totalCumplimiento2:N2}</td>
                                </tr>
                            </table>";

                    // --- Tabla Detalle de Indicadores Extra ---
                    string tablaIndicadoresExtrateCabecera2 = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Clase</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                            </tr>";

                    StringBuilder filasIndicadoresExtrate2 = new StringBuilder();

                    if (indicadoresExtra2 != null)
                    {
                        foreach (var indiExtra in indicadoresExtra2)
                        {
                            filasIndicadoresExtrate2.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.ClaseIndicador}</td>
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.Indicador}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                            </tr>");
                        }
                    }
                    htmlPdf += tablaIndicadoresExtrateCabecera2 + filasIndicadoresExtrate2.ToString() + "</table><br />";

                    // --- Total Análisis Indicadores Estratégicos ---
                    htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Total Análisis Indicadores Estrategicos</h3>";

                    string tablaTotalCabecera = $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Valor Análisis</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Nivel</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 10%;"">Color</th>
                        </tr>";

                    StringBuilder filasTotalAnalisis = new StringBuilder();

                    if (TotalAnaIndiEstra != null)
                    {
                        foreach (var TotalAIE in TotalAnaIndiEstra)
                        {
                            // Detectamos el color para el óvalo usando la función que definimos antes
                            string colorHex = ObtenerHexColor(TotalAIE.Color);

                            string ovaloHtml = $@"
                        <span style=""
                            display: inline-block; 
                            width: 35px; 
                            height: 18px; 
                            background-color: {colorHex}; 
                            border-radius: 12px; 
                            border: 0.5px solid #444; 
                            vertical-align: middle;"">
                        </span>";

                            filasTotalAnalisis.Append($@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.Peso}</td>
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.ValorAnalisis}</td>
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.Nivel}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                {ovaloHtml}
                            </td>
                        </tr>");
                        }
                    }

                    htmlPdf += tablaTotalCabecera + filasTotalAnalisis.ToString() + "</table><br />";
                }
            }
            else
            {
                if (gestionVisible)
                {
                    // --- Indicadores de Gestión ---
                    htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Indicadores de Gestión</h3>";

                    string tablaIndicadoresGestionCabecera = $@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                        <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Clase</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                            <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                        </tr>";

                    StringBuilder filasIndicadoresGestion = new StringBuilder();

                    if (indicadoresGestion != null)
                    {
                        foreach (var IndicadoresG in indicadoresGestion)
                        {
                            filasIndicadoresGestion.Append($@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{IndicadoresG.MastIndicadoresobj.ClaseIndicador}</td>
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{IndicadoresG.Indicador}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{IndicadoresG.Peso}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{IndicadoresG.Real}</td>
                        </tr>");
                        }
                    }

                    string tablaIndicadoresGestionCierre = @"</table><br />";

                    htmlPdf += tablaIndicadoresGestionCabecera + filasIndicadoresGestion.ToString() + tablaIndicadoresGestionCierre;
                }
                if (estretegicosVisible)
                {
                    htmlPdf += $@"
                        <br />
                        <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                            {nombreTituloUes1}
                        </h3>";

                    decimal pesoTotal = UES1.peso;
                    decimal totalCumplimiento = UES1.Total;

                    htmlPdf += $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 300px; border: 1px solid #dddddd; margin: 0 auto 15px auto;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 50%;"">Total</th>
                            </tr>
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{pesoTotal:N2}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{totalCumplimiento:N2}</td>
                            </tr>
                        </table>";

                    // --- Tabla Detalle de Indicadores Extra ---
                    string tablaIndicadoresExtrateCabecera = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 15px;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Clase</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Indicador</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">% cumplimiento</th>
                            </tr>";

                    StringBuilder filasIndicadoresExtrate = new StringBuilder();

                    if (indicadoresExtra != null)
                    {
                        foreach (var indiExtra in indicadoresExtra)
                        {
                            filasIndicadoresExtrate.Append($@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.ClaseIndicador}</td>
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.Indicador}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                        </tr>");
                        }
                    }
                    htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";

                    // --- Total Análisis Indicadores Estratégicos ---

                    htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Total Análisis Indicadores Estrategicos</h3>";

                    string tablaTotalCabecera = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Peso</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Valor Análisis</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Nivel</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 10%;"">Color</th>
                            </tr>";

                    StringBuilder filasTotalAnalisis = new StringBuilder();

                    if (TotalAnaIndiEstra != null)
                    {
                        foreach (var TotalAIE in TotalAnaIndiEstra)
                        {
                            // Detectamos el color para el óvalo usando la función que definimos antes
                            string colorHex = ObtenerHexColor(TotalAIE.Color);

                            string ovaloHtml = $@"
                            <span style=""
                                display: inline-block; 
                                width: 35px; 
                                height: 18px; 
                                background-color: {colorHex}; 
                                border-radius: 12px; 
                                border: 0.5px solid #444; 
                                vertical-align: middle;"">
                            </span>";

                            filasTotalAnalisis.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.Peso}</td>
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.ValorAnalisis}</td>
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{TotalAIE.Nivel}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                                    {ovaloHtml}
                                </td>
                            </tr>");
                        }
                    }

                    htmlPdf += tablaTotalCabecera + filasTotalAnalisis.ToString() + "</table><br />";
                }
            }
            // Total Análisis de Rendimiento
            htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Total Análisis de Rendimiento</h3>";

            // Obtención de datos asíncrona desde el repositorio

            StringBuilder filasAnalisisRendimiento = new StringBuilder();

            if (AnalisisRendi != null)
            {
                foreach (var itemRendi in AnalisisRendi)
                {
                    string colorHex = ObtenerHexColor(itemRendi.Color);

                    string ovaloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 35px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 12px; 
                        border: 0.5px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                    filasAnalisisRendimiento.Append($@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">
                                {itemRendi.Nivel}
                            </td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 10%;"">
                                {ovaloHtml}
                            </td>
                        </tr>
                    </table>");
                }
            }

            htmlPdf += filasAnalisisRendimiento.ToString() + "<br />";

            // --- Sección Observaciones Generales ---
            if (progEva.FechaCreacion?.Year > 2023 && dataEmpresa.Empresa == "Comfandi")
            {
                htmlPdf += $@"
                <br/>
                <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                    <tr>
                        <td style=""border: 1px solid #dddddd; padding-left: 10px; padding-top: 10px; padding-bottom: 8px; vertical-align: top; text-align: left; background-color: #f2f2f2; width: 30%;"">
                            <strong>Observaciones Generales:</strong>
                        </td>
                        <td style=""border: 1px solid #dddddd; padding-left: 10px; padding-top: 10px; padding-bottom: 8px; vertical-align: top; text-align: left;"">
                            {progEva.ObservacionGeneral}
                        </td>
                    </tr>
                </table><br/>";
            }

            if (comptc > 0)
            {
                // --- Competencias Técnicas ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">3. Competencias Técnicas</h3>";

                htmlPdf += $@"
                <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                    <tr>
                        <td style=""border: 1px solid #dddddd; padding: 10px; vertical-align: top; text-align: left;"">
                            <br/>
                            {textoTecnicas}
                        </td>
                    </tr>
                </table><br/>";

                // --- Resultados Competencias Técnicas ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Resultados Competencias Técnicas</h3>";

                string tablaCabeceraTecnica = $@"
                <br/>
                <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                    <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                        <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Competencia</th>
                        <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Observación</th>
                        <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center;"">Nivel</th>
                        <th style=""border: 1px solid #dddddd; padding: 8px; vertical-align: top; text-align: center; width: 60px;"">Color</th>
                    </tr>";

                StringBuilder filasTecnicas = new StringBuilder();

                if (ResultCompeTecnicas != null)
                {
                    foreach (var ResultCompeTec in ResultCompeTecnicas)
                    {
                        // Generación del óvalo CSS basado en el color que viene de la DB
                        string colorHex = ObtenerHexColor(ResultCompeTec.Color);

                        string ovaloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 35px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 12px; 
                        border: 0.5px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                        filasTecnicas.Append($@"
                    <tr style=""border: 1px solid #dddddd;"">
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{ResultCompeTec.Descripcion}</td>
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{ResultCompeTec.Observacion}</td>
                        <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{ResultCompeTec.EscalaNivel}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">
                            {ovaloHtml}
                        </td>
                    </tr>");
                    }
                }

                htmlPdf += tablaCabeceraTecnica + filasTecnicas.ToString() + "</table><br />";

                // --- Total Competencias Técnicas ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Total Competencias Tecnicas</h3>";

                StringBuilder sbTotalCompTecnicas = new StringBuilder();

                if (TotalCompTecnicas != null)
                {
                    foreach (var TotalCompTecn in TotalCompTecnicas)
                    {
                        // Usamos la función de mapeo de color para el óvalo CSS
                        string colorHex = ObtenerHexColor(TotalCompTecn.Color);

                        string ovaloHtml = $@"
                    <span style=""
                        display: inline-block; 
                        width: 35px; 
                        height: 18px; 
                        background-color: {colorHex}; 
                        border-radius: 12px; 
                        border: 0.5px solid #444; 
                        vertical-align: middle;"">
                    </span>";

                        sbTotalCompTecnicas.Append($@"
                    <br/>
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">
                                {TotalCompTecn.NivelComt}
                            </td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 10%;"">
                                {ovaloHtml}
                            </td>
                        </tr>
                    </table>");
                    }
                }

                htmlPdf += sbTotalCompTecnicas.ToString() + "<br />";
            }
            int acc = 2;
            if (acc == 2)
            {
                // --- Resultados Análisis de Desarrollo ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Resultados Análisis de Desarrollo</h3><br />";

                StringBuilder sbResultadosDesarrollo = new StringBuilder();

                if (ResultAnalisisDesarrollo != null)
                {
                    foreach (var ResultAnaDesa in ResultAnalisisDesarrollo)
                    {
                        string colorHex = ObtenerHexColor(ResultAnaDesa.Color);

                        string ovaloHtml = $@"
                    <span style=""display: inline-block; width: 35px; height: 18px; background-color: {colorHex}; border-radius: 12px; border: 0.5px solid #444; vertical-align: middle;"">
                    </span>";

                        sbResultadosDesarrollo.Append($@"
                    <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                        <tr style=""border: 1px solid #dddddd;"">
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"">{ResultAnaDesa.AspectoValoracionObj.AspectoValoracion}</td>
                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px; width: auto;"">{ResultAnaDesa.Nivel}</td>
                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 10%;"">
                                {ovaloHtml}
                            </td>
                        </tr>
                    </table>");
                    }
                }

                htmlPdf += sbResultadosDesarrollo.ToString() + "<br />";

                // --- Concepto Final Análisis de Desarrollo ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Concepto Final Análisis de Desarrollo</h3>";

                StringBuilder sbConceptoFinal = new StringBuilder();

                if (ConcepFinalAnaDesarrollo != null)
                {
                    foreach (var ConcepFinalAnaDesa in ConcepFinalAnaDesarrollo)
                    {
                        string colorHex = ObtenerHexColor(ConcepFinalAnaDesa.Color);
                        string rectanguloHtml = $@"
                        <span style=""
                            display: inline-block;
                            width: 25px; 
                            height: 18px;
                            background-color: {colorHex};
                            border: 0.1pt solid #888;
                            vertical-align: middle;"">
                        </span>";

                        sbConceptoFinal.Append($@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 20%;"">
                                    {ConcepFinalAnaDesa.Nivel}</td>
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">
                                    {ConcepFinalAnaDesa.DescNivel}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 10%;"">
                                    {rectanguloHtml}
                                </td>
                            </tr>
                        </table>");
                    }
                }

                htmlPdf += sbConceptoFinal.ToString() + "<br />";
            }

            return _mapper.Map<string>(htmlPdf.ToString());

        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GeneradorPDFADIByEvaluacionId", ex, pdiAdiObj.Evaluacion.InIdEvaluacion.ToString());
            throw;
        }
    }
}
