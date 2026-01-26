using App.Infraestructure.Connect;
using App.Infraestructure.Helpers;
using App.Infraestructure.IRepositories;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace App.Infraestructure.Repositories;

public class ProgEvaluacionRepository: IProgEvaluacionRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
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
    private readonly IResultIndiCoporpRepository _resultIndiCoporpRepository;
    private readonly ItotalUESRepository _totalUESRepository;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultcomTecnicasRepository _resultcomTecnicasRepository;
    private readonly IEmpresasTitulosRepository _empresasTitulosRepository;
    private readonly ITotalAnalisisIndiADIRepository _totalAnalisisIndiADIRepository;
    private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;


    public ProgEvaluacionRepository(ConnectContext context, IMapper mapper, 
        IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository, IFuncionariosRepository funcionariosRepository,
        ICargosRepository cargosRepository, ICargosProcesosRepository cargosProcesosRepository, ITxtFormEvaluacionRepository txtFormEvaluacionRepository,
        IResultadosEvaluacionRepository resultadosEvaluacionRepository, IConsolidadoDesempenoRepository consolidadoDesempenoRepository,
        IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository, IResultadosRepository resultadosRepository, ITiposIndicadoresEstrategicosRepository tiposIndicadoresEstrategicosRepository,
        ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository, ItotalUESRepository totalUESRepository, IResultIndiCoporpRepository resultIndiCoporpRepository,
        IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository, IResultcomTecnicasRepository resultcomTecnicasRepository,
        IEmpresasTitulosRepository empresasTitulosRepository, ITotalAnalisisIndiADIRepository totalAnalisisIndiADIRepository, IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository)
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
        _resultIndiCoporpRepository = resultIndiCoporpRepository;
        _totalUESRepository = totalUESRepository;
        _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
        _resultcomTecnicasRepository = resultcomTecnicasRepository;
        _empresasTitulosRepository = empresasTitulosRepository;
        _totalAnalisisIndiADIRepository = totalAnalisisIndiADIRepository;
        _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
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
    public async Task<string>GeneradorPDFADIByEvaluacionId(int EvaluacionId, int acc)
    {
        try
        {
            var progEva = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
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
            var textoAdi = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, 1, (int)progEva.TipoValoracionId, (int)progEva.InAno);
            var textoAdi2 = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, 2, (int)progEva.TipoValoracionId, (int)progEva.InAno);
            var ADI = await _resultadosEvaluacionRepository.ListFormEvaluacionByEvaluacionId(progEva.InIdEvaluacion);
            var nivelCompe = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(progEva.InIdEvaluacion, 1);
            var indicadoresGestion = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresByEvaluacionId(progEva.InIdEvaluacion);
            var NombreZonaOficina = await _empresasTitulosRepository.ObjEmpresasTitulos(empresa);
            // Construcción del HTML
            string htmlPdf = "";

            string tablaInicio = $@"
            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">Fecha Cierre</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">Cargo</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">Proceso</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">{NombreZonaOficina.Zona}</th>
                    <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">{NombreZonaOficina.Oficina}</th>
                </tr>";

            string filaDatos = $@"
                <tr style=""border: 1px solid #dddddd;"">
                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{progEva.FechaCierre?.ToShortDateString()}</td>
                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{nombreCargo}</td>
                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{nombreCargoProceso}</td>
                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{ZonaOficina?.ZonaObj?.Zona}</td>
                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{ZonaOficina?.OficinaObj?.Oficina}</td>
                </tr>
            </table><br />";

            htmlPdf += tablaInicio + filaDatos;

            // Análisis Competencia
            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">1. Análisis de Competencias</h3>";

            string filaAnalsis = $@"
                <tr>
                    <td colspan=""6"" style=""border: 1px solid #dddddd; padding: 10px 8px 10px 10px; vertical-align: top; text-align: left;"">
                        <br/>
                        {textoAdi}
                    </td>
                </tr>";

            htmlPdf += filaAnalsis;

            foreach (var item in ADI)
            {
                string colorHex = ObtenerHexColor(item.Color);

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

                htmlPdf += $@"
                <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd; margin-bottom: 5px;"">
                    <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                        <th style=""border: 1px solid #dddddd; padding: 8px; width: 50%;"">Competencia</th>
                        <th style=""border: 1px solid #dddddd; padding: 8px;"">Nivel de Desarrollo</th>
                        <th style=""border: 1px solid #dddddd; padding: 8px; width: 50px;""></th>
                    </tr>
                    <tr>
                        <td style=""border: 1px solid #dddddd; padding: 8px;"">{item.Normasobj.VcCompetencia}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{item.Nivel}</td>
                        <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{ovaloHtml}</td>
                    </tr>
                </table>";

                var criterios = await _resultadosRepository.GetResultadosEvaluacionListaByEvaluacionId(progEva.InIdEvaluacion, item.NormaId);
                if (criterios != null && criterios.Any())
                {
                    StringBuilder filasCriterios = new StringBuilder();

                    foreach (var criterio in criterios)
                    {
                        // icono
                        string iconoHtml = @"<span style='display: inline-block; width: 18px; height: 18px; background-color: black; color: white; border-radius: 50%; text-align: center; line-height: 18px; font-size: 10px; vertical-align: middle; margin-right: 8px;'>&#10004;</span>";

                        filasCriterios.Append($@"
                                <tr>
                                    <td style=""width: 70%; border: none; padding: 6px 0; text-align: left; display: flex; align-items: center;"">
                                        {iconoHtml}
                                        <span style=""vertical-align: middle;"">{criterio.Criterio}</span>
                                    </td>
                                    <td style=""width: 30%; border: none; padding: 6px 0; text-align: right;"">
                                        <span style=""border: 1px solid #ccc; padding: 2px 10px; border-radius: 3px; font-weight: bold; font-size: 12px;"">
                                            {criterio.Escalanivel}
                                        </span>
                                    </td>
                                </tr>");
                    }

                    // Fila contenedora de la sub-tabla
                    htmlPdf += $@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td colspan=""4"" style=""border: 1px solid #dddddd; padding: 0;"">
                                <table style=""width: 100%; border-collapse: collapse;"">
                                    {filasCriterios}
                                </table>
                            </td>
                        </tr>";

                    // Sección de Observaciones
                    htmlPdf += $@"
                        <tr style=""border: 1px solid #dddddd;"">
                            <td colspan=""4"" style=""border: 1px solid #dddddd; padding: 10px; vertical-align: top; text-align: left; background-color: #f9f9f9;"">
                                <strong>Observaciones Análisis Competencia:</strong>
                            </td>
                        </tr>
                        <tr style=""border: 1px solid #dddddd;"">
                            <td colspan=""4"" style=""border: 1px solid #dddddd; padding: 10px; vertical-align: top; text-align: left;"">
                                {item.Observaciones ?? "Sin observaciones"}
                            </td>
                        </tr>";
                }

                htmlPdf += "</table><br />";
            }
            // Título y Cabecera de la tabla
            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">Resultados Análisis Competencias</h3>";

            string tablaResultadosHeader = $@"
                        <br/>
                        <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                            <tr style=""border: 1px solid #dddddd; background-color: #f2f2f2;"">
                                <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">Competencia</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; text-align: center;"">Nivel de Desarrollo</th>
                                <th style=""border: 1px solid #dddddd; padding: 8px; width: 50px;""></th>
                            </tr>";

            StringBuilder filasResultados = new StringBuilder();

            if (ADI != null)
            {
                foreach (var ResultadoAC in ADI)
                {
                    // Reemplazo de imagen por icono circular negro con check blanco
                    string iconoHtml = @"<span style='display: inline-block; width: 20px; height: 20px; background-color: black; color: white; border-radius: 50%; text-align: center; line-height: 20px; font-size: 11px; vertical-align: middle;'>&#10004;</span>";

                    filasResultados.Append($@"
                            <tr style=""border: 1px solid #dddddd;"">
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{ResultadoAC.Normasobj.VcCompetencia}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{ResultadoAC.Nivel}</td>
                                <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{iconoHtml}</td>
                            </tr>");
                }
            }

            htmlPdf += tablaResultadosHeader + filasResultados.ToString() + "</table><br />";

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

            htmlPdf += "<h3 style=\"font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;\">2. Análisis del Rendimiento</h3>";

            htmlPdf += $@"
                <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                    <tr>
                        <td style=""border: 1px solid #dddddd; padding: 10px; vertical-align: top; text-align: left;"">
                            <br/>
                            {textoAdi2}
                        </td>
                    </tr>
                </table><br/>";

            if (nivelCargo == 1)
            {
                if (tipoNivel == 1)
                {
                    var tituloIndEstra = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 1);
                    string nombreIndEstra = tituloIndEstra.tipoIndicadorEstrategico;

                    var indiCorporativos = await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);
                    var ResultIndiCorporativos = await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);

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
                    var tituloIndEstra = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 1);
                    string nombreIndEstra = tituloIndEstra.tipoIndicadorEstrategico;

                    var indiCorporativos = await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);
                    var ResultIndiCorporativos = await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);

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

                    var tituloUes1 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 2);
                    string nombreTituloUes1 = tituloUes1.tipoIndicadorEstrategico;

                    htmlPdf += $@"
                            <br />
                            <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                                {nombreTituloUes1}
                            </h3>";

                    // REVISAR COMO TRAER LOS DATOS DEL UES1
                    var idPadre = progEva.IdPadre;
                    if (idPadre > 0)
                    {
                        var anio = progEva.InAno;
                        var mesInicio = progEva.MesIni;
                        var mesFin = progEva.MesFin;
                        int tipoValoracion = 1;
                        int tipoEvaluacion = 1;

                        if (progEva.InAno == anio && progEva.MesIni == mesInicio && progEva.MesFin == mesFin && tipoEvaluacion == 1 && tipoValoracion == 1 && progEva.InIdEvaluado == idPadre)
                        {
                            int idEvaluacionPadre = progEva.InIdEvaluacion;

                            var UES1 = await _totalUESRepository.GetTotalAnalisisUES1(idEvaluacionPadre, empresa, (int)progEva.TipoNivelEstrategico, ZonaOficina.CodigoNivelCompetencia);
                            var indicadoresExtra = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(idEvaluacionPadre);

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
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.InIdIndicador}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                                </tr>");
                                }
                            }
                            htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";
                        }
                    }
                }
                else
                {
                    // Indicadores Estratégicos
                    var tituloIndEstra = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 1);
                    string nombreIndEstra = tituloIndEstra.tipoIndicadorEstrategico;

                    var indiCorporativos = await _totalIndEstCorporativosRepository.GetListaTotalIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);
                    var ResultIndiCorporativos = await _resultIndiCoporpRepository.GetListaResultadoIndicadoresCorporativos(progEva.InIdEvaluacion, empresa);

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

                    var tituloUes1 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 2);
                    string nombreTituloUes1 = tituloUes1.tipoIndicadorEstrategico;

                    htmlPdf += $@"
                            <br />
                            <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                                {nombreTituloUes1}
                            </h3>";

                    // REVISAR COMO TRAER LOS DATOS DEL UES1
                    var idPadre = progEva.IdPadre;
                    if (idPadre > 0)
                    {
                        var anio = progEva.InAno;
                        var mesInicio = progEva.MesIni;
                        var mesFin = progEva.MesFin;
                        int tipoValoracion = 1;
                        int tipoEvaluacion = 1;

                        if (progEva.InAno == anio && progEva.MesIni == mesInicio && progEva.MesFin == mesFin && tipoEvaluacion == 1 && tipoValoracion == 1 && progEva.InIdEvaluado == idPadre)
                        {
                            int idEvaluacionPadre = progEva.InIdEvaluacion;

                            var UES1 = await _totalUESRepository.GetTotalAnalisisUES1(idEvaluacionPadre, empresa, (int)progEva.TipoNivelEstrategico, ZonaOficina.CodigoNivelCompetencia);
                            var indicadoresExtra = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(idEvaluacionPadre);

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
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.InIdIndicador}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                                </tr>");
                                }
                            }
                            htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";

                            var tituloUes2 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 3);
                            string nombreTituloUes2 = tituloUes2.tipoIndicadorEstrategico;

                            htmlPdf += $@"
                            <br />
                            <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                                {nombreTituloUes2}
                            </h3>";

                                int idEvaluacionPadre2 = progEva.InIdEvaluacion;

                                var UES2 = await _totalUESRepository.GetTotalAnalisisUES2(idEvaluacionPadre, empresa);
                                var indicadoresExtra2 = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(idEvaluacionPadre);

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
                                        filasIndicadoresExtrate.Append($@"
                                        <tr style=""border: 1px solid #dddddd;"">
                                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.ClaseIndicador}</td>
                                            <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.InIdIndicador}</td>
                                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                                            <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                                        </tr>");
                                    }
                                }
                                htmlPdf += tablaIndicadoresExtrateCabecera2 + filasIndicadoresExtrate2.ToString() + "</table><br />";

                            // --- Total Análisis Indicadores Estratégicos ---
                            var TotalAnaIndiEstra = await _totalAnalisisIndiADIRepository.TotalAnalisisIndicadoresEstrategicosADI(progEva.InIdEvaluacion, empresa);

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
                }
            }
            else
            {
                var gestion = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(empresa, nivelCargo, 1);
                bool gestionVisible = gestion.VisibleADI;
                var estretegicos = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(empresa, nivelCargo, 2);
                bool estretegicosVisible = estretegicos.VisibleADI;

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
                                <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{IndicadoresG.MastIndicadoresobj.CodIndicador}</td>
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
                    var tituloUes1 = await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(empresa, 3);
                    string nombreTituloUes1 = tituloUes1.tipoIndicadorEstrategico;

                    htmlPdf += $@"
                            <br />
                            <h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">
                                {nombreTituloUes1}
                            </h3>";

                    var idPadre = progEva.IdPadre;
                    var anio = progEva.InAno;
                    var mesInicio = progEva.MesIni;
                    var mesFin = progEva.MesFin;
                    int tipoValoracion = 1;
                    int tipoEvaluacion = 1;

                    if (progEva.InAno == anio && progEva.MesIni == mesInicio && progEva.MesFin == mesFin && tipoEvaluacion == 1 && tipoValoracion == 1 && progEva.InIdEvaluado == idPadre)
                    {
                        int idEvaluacionPadre = progEva.InIdEvaluacion;

                        var UES1 = await _totalUESRepository.GetTotalAnalisisUES1(idEvaluacionPadre, empresa, (int)progEva.TipoNivelEstrategico, ZonaOficina.CodigoNivelCompetencia);
                        var indicadoresExtra = await _resultadosEvaIndicadoresRepository.GetListaEvaluacionIndicadoresEstrategicosEvaluacionId(idEvaluacionPadre);

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
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{indiExtra.MastIndicadoresobj.InIdIndicador}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Peso}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px;"">{indiExtra.Real}</td>
                                </tr>");
                            }
                        }
                        htmlPdf += tablaIndicadoresExtrateCabecera + filasIndicadoresExtrate.ToString() + "</table><br />";

                        // --- Total Análisis Indicadores Estratégicos ---
                        var TotalAnaIndiEstra = await _totalAnalisisIndiADIRepository.TotalAnalisisIndicadoresEstrategicosADI(progEva.InIdEvaluacion, empresa);

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
            }
            // Total Análisis de Rendimiento
            htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Total Análisis de Rendimiento</h3>";

            // Obtención de datos asíncrona desde el repositorio
            var AnalisisRendi = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(progEva.InIdEvaluacion, 2);

            StringBuilder filasAnalisisRendimiento = new StringBuilder();

            if (AnalisisRendi != null)
            {
                foreach (var itemRendi in AnalisisRendi)
                {
                    // Generación del óvalo CSS dinámico basado en el color de la DB
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

            var listaTecnicas = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(EvaluacionId);
            int comptc = listaTecnicas?.Count() ?? 0;
            if (comptc > 0)
            {
                // --- 3. Competencias Técnicas ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">3. Competencias Técnicas</h3>";

                // Obtención del texto descriptivo desde el repositorio
                var textoTecnicas = await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(empresa, (int)progEva.InAno, 3, (int)progEva.TipoValoracionId);

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
                var ResultCompeTecnicas = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(progEva.InIdEvaluacion);

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

                // Obtención de datos asíncrona (Asegúrate de tener inyectado el repositorio correspondiente)
                var TotalCompTecnicas = await _progEvaluacionRepository.GetListaProgEvaluacionByEvaluacionId(progEva.InIdEvaluacion);

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

                // Concatenamos el contenido y cerramos con el espacio final
                htmlPdf += sbTotalCompTecnicas.ToString() + "<br />";
            }
            /// traer este dato en el parametro
            //int acc = int.Parse(Request.QueryString.Get("acc"));
            if (acc == 2)
            {
                // --- Resultados Análisis de Desarrollo ---
                htmlPdf += $@"<h3 style=""font-family: arial, sans-serif; text-align: center; font-weight: bold; font-size: 20px; margin: 15px 0 5px 0;"">Resultados Análisis de Desarrollo</h3><br />";

                var ResultAnalisisDesarrollo = await _consolidadoDesempenoRepository.GetListaConsolidadosByEvaluacionId(progEva.InIdEvaluacion);

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

                var ConcepFinalAnaDesarrollo = await _progEvaluacionRepository.GetListaProgEvaluacionByEvaluacionId(progEva.InIdEvaluacion);

                StringBuilder sbConceptoFinal = new StringBuilder();

                if (ConcepFinalAnaDesarrollo != null)
                {
                    foreach (var ConcepFinalAnaDesa in ConcepFinalAnaDesarrollo)
                    {
                        string colorHex = ObtenerHexColor(ConcepFinalAnaDesa.Color);

                        string ovaloHtml = $@"
                                <span style=""display: inline-block; width: 35px; height: 18px; background-color: {colorHex}; border-radius: 12px; border: 0.5px solid #444; vertical-align: middle;"">
                                </span>";

                        sbConceptoFinal.Append($@"
                            <br/>
                            <table style=""font-family: arial, sans-serif; border-collapse: collapse; width: 100%; border: 1px solid #dddddd;"">
                                <tr style=""border: 1px solid #dddddd;"">
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 20%;"">{ConcepFinalAnaDesa.Nivel}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: left; padding: 8px;"">{ConcepFinalAnaDesa.DescNivel}</td>
                                    <td style=""border: 1px solid #dddddd; text-align: center; padding: 8px; width: 10%;"">
                                        {ovaloHtml}
                                    </td>
                                </tr>
                            </table>");
                    }
                }

                htmlPdf += sbConceptoFinal.ToString() + "<br />";
            }

                return htmlPdf;
        }
        catch (Exception ex)
        {
            ExceptionLogHelpers.LogException("GeneradorPDFADIByEvaluacionId", ex, EvaluacionId.ToString());
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
}
