using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.Share;
using App.Models.Models.TblCom;

namespace App.logic.Services;

public class ProgEvaluacionService : IProgEvaluacionSercice
{
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IResultadoEvaluacionadaRepository _resultadoEvaluacionadaRepository;
    private readonly INotificacionesService _notificacionesService;
    private readonly IFuncionariosRepository _funcionariosRepository;
    private readonly IProgramacionMasivaEvaluacionesRepository _programacionMasivaEvaluacionesRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IGetPorcentajesRepository _getPorcentajesRepository;

    public ProgEvaluacionService(IProgEvaluacionRepository progEvaluacionRepository,
        IResultadoEvaluacionadaRepository resultadoEvaluacionadaRepository,
        INotificacionesService notificacionesService,
        IFuncionariosRepository funcionariosRepository,
        IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository,
        IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository,
        IGetPorcentajesRepository getPorcentajesRepository)
    {
        _progEvaluacionRepository = progEvaluacionRepository;
        _resultadoEvaluacionadaRepository = resultadoEvaluacionadaRepository;
        _notificacionesService = notificacionesService;
        _funcionariosRepository = funcionariosRepository;
        _programacionMasivaEvaluacionesRepository = programacionMasivaEvaluacionesRepository;
        _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
        _getPorcentajesRepository = getPorcentajesRepository;
    }

    public async Task<Tbl_com_ProgEvaluacionModels> GetObjProgEvaluacion(long EvaluacionId)
    {
        var getResult = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        return getResult;
    }

    public async Task<string> GetCerrarEvaluacion(long EvaluacionId, int EmpresaId, int Caracteres)
    {
        Tbl_com_ProgEvaluacionModels objEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        List<TBL_com_ResultadoEvaluacionADAModels> ListResultados = await _resultadoEvaluacionadaRepository.ListResultadoEvaluacionadaByEvaluacionId(EvaluacionId);
        List<TBL_com_ResultadoEvaluacionADAModels> ResultadosTipo1 = ListResultados.Where(x => x.Tipo == 1).ToList();
        List<TBL_com_ResultadoEvaluacionADAModels> ResultadosTipo2 = ListResultados.Where(x => x.Tipo == 2 && x.IdPadre != 0).ToList();

        int valPreguntas = 0, valCaracteresPreguntas = 0;

        foreach (var res in ResultadosTipo1)
        {
            if (res.ResultadoTxt == "" || res.ResultadoTxt == null)
            {
                valPreguntas = valPreguntas + 1;
            }

            if (res.ResultadoTxt.Length < Caracteres)
            {
                valCaracteresPreguntas = valCaracteresPreguntas + 1;
            }
        }

        foreach (var res2 in ResultadosTipo2)
        {
            List<TBL_com_ResultadoEvaluacionADAModels> respuestaHijotipo2 = ListResultados.Where(x => x.IdHijo == res2.IdPadre).ToList();
            foreach (var res in respuestaHijotipo2)
            {
                int calificado = respuestaHijotipo2.Where(x => x.Resultado == true).Count();
                if (calificado == 0)
                {
                    valPreguntas = valPreguntas + 1;
                }
            }
        }

        if (valPreguntas == 0)
        {
            if (valCaracteresPreguntas == 0)
            {
                objEvaluacion.BEstado = true;
                objEvaluacion.UsuarioModificacion = "AdminCompetencias";
                objEvaluacion.FechaModificacion = DateTime.Now;
                var upEv = await _progEvaluacionRepository.UpdateProgEvaluacion(objEvaluacion);
                return upEv != null ? "Evaluación finalizada" : "Error en proceso de la plataforma, por favor comunícate con los Administradores de QPlus-nube";
            }
            else
            {
                return "Existen respuestas que no cumplen el minimo de caracteres, el minimo de caracteres es: " + Caracteres;
            }
        }
        else
        {
            return "Faltan preguntas por responder";
        }
    }

    public async Task<string> GetConceptoFinalEval(RequestConceptoFinal ConceptoFinal)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(ConceptoFinal.EvaluacionId);
        ObjEvaluacion.Concepto = ConceptoFinal.Concepto;
        ObjEvaluacion.JustificacionConcepto = ConceptoFinal.Justificacion;
        var upEv = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);
        string conceptoText = ConceptoFinal.Concepto == false ? "Desfavorable" : "Favorable";
        if (upEv != null)
        {
            string asunto = "Concepto Final Evaluador ADA";
            string rol = "AdminAdaptacionCargo";
            string nomEvaludor = ObjEvaluacion.NomEvaluador;
            string nomEvaluado = ObjEvaluacion.NomEvaluado;
            string mesaje = "El evaluador " + nomEvaludor + " ha terminado el análisis de adaptación al cargo del funcionario " + nomEvaluado + " y el concepto fue " + conceptoText + ".";
            await _notificacionesService.SentNotificacionComceptoFinal(asunto, mesaje, rol, ConceptoFinal.EmpresaId);
            return conceptoText;
        }
        else
        {
            return "Error en proceso de la plataforma, por favor comunícate con los Administradores de QPlus-nube";
        }

    }

    public async Task<string> PutUpdateEvaluador(long EvaluacionId, long Evaluador, long Usuariomod)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

        SCP_FuncionariosModels objFuncionario = await _funcionariosRepository.ObjFuncionarioByIdentificacion(Evaluador);

        Tbl_com_ProgramacionMasivaEvaluacionesModels objProMasiva = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion((long)ObjEvaluacion.IdPrgramacionEvaluacion);

        ObjEvaluacion.InIdEvaluador = Evaluador;
        ObjEvaluacion.NomEvaluador = objFuncionario.Nombre;
        ObjEvaluacion.UsuarioModificacion = Usuariomod.ToString();
        ObjEvaluacion.FechaModificacion = DateTime.UtcNow;
        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        objProMasiva.CedulaEvaluador = Evaluador;
        objProMasiva.UsuarioProgramacion = Usuariomod;
        await _programacionMasivaEvaluacionesRepository.Update_ProgramacionMasivaEvaluaciones(objProMasiva);

        return "Evaluador Modificado con éxito";
    }

    public async Task<Tbl_com_ProgEvaluacionModels> UpdateProgEvaluacionTotalIndicadores(long EvaluacionId, int TotIndi, int EmpresaId, List<Tbl_com_ResultadosEvaIndicadoresModels> IndicadoresEvaluacion)
    {
        foreach (Tbl_com_ResultadosEvaIndicadoresModels item in IndicadoresEvaluacion)
        {
            item.Peso = 0;
            item.Meta = 100;
            item.Real = 0;
            item.Ponderado = 0;
            item.Color = "white.png";

            await _resultadosEvaIndicadoresRepository.UpdateResultadosEvaIndicadores(item);
        }

        int tie = 0;
        var ListIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(EvaluacionId, new int[] { 6 }, EmpresaId);
        tie = ListIndicadores.Count;
        int t = TotIndi + tie;

        int idEsC = 0;
        idEsC = ListIndicadores.Where(x => x.Ponderado != 0).ToList().Count;

        Tbl_com_ProgEvaluacionModels ObjProevaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjProevaluacion.PorEvaIndi = await _getPorcentajesRepository.GetPorcentajeEvaluacionIndi(EvaluacionId, EmpresaId);
        ObjProevaluacion.TotIndi = t;
        ObjProevaluacion.IndiEva = idEsC;
        ObjProevaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjProevaluacion);
        return ObjProevaluacion;
    }

    public async Task<string> PutUpdateObservacionGeneral(long EvaluacionId, string Observacion)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.ObservacionGeneral = Observacion;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return Observacion;
    }

    public async Task<string> PutUpdateObsModMapaT(long EvaluacionId, string ObsModMapaT)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.Obs_Mod_MapaT = ObsModMapaT;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return ObsModMapaT;
    }

    public async Task<string> PutUpdateModMT(long EvaluacionId, bool ModMT)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.Mod_MT = ModMT;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return "ModMT";
    }

    public async Task<string> PutUpdateCajaMapaTalentoM(long EvaluacionId, int NumeroMapaTalentoM, string CajaMapaTalentoM, string ColorMapaTalentoM) 
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.NumeroMapaTalentoM = NumeroMapaTalentoM;
        ObjEvaluacion.CajaMapaTalentoM = CajaMapaTalentoM;
        ObjEvaluacion.ColorMapaTalentoM = ColorMapaTalentoM;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return "Caja Mapa Talentos Modificado con éxito";
    }

    public async Task<string> PutUpdateObsModMapaDesempeno(long EvaluacionId, string obsNivelMapaD)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.Obs_Nivel_MapaD = obsNivelMapaD;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return obsNivelMapaD;
    }

    public async Task<string> PutUpdateCajaMapaDesempenoM(long EvaluacionId, int UbicacionMD_M, string NivelM, string ColorNivelM)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.UbicacionMD_M = UbicacionMD_M;
        ObjEvaluacion.NivelM = NivelM;
        ObjEvaluacion.ColorNivelM = ColorNivelM;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return "Caja Mapa Desempeño Modificado con éxito";
    }

    public async Task<string> PutUpdateModMD(long EvaluacionId, bool ModMD)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.Mod_MD = ModMD;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return "ModMD";
    }
    public async Task<string> PutUpdateUsuarioModNivel(long EvaluacionId, string UsuarioModNivel)
    {
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        ObjEvaluacion.UsuarioModNivel = UsuarioModNivel;

        await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return "ModMD";
    }

}
