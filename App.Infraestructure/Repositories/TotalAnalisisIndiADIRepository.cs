using App.Infraestructure.Connect;
using App.Infraestructure.IRepositories;
using App.Models.Models.Scp;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using App.Models.Models.TblMast;
using AutoMapper;

namespace App.Infraestructure.Repositories;

public class TotalAnalisisIndiADIRepository : ITotalAnalisisIndiADIRepository
{
    private readonly ConnectContext _context;
    private readonly IMapper _mapper;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IResulDirectorGerentesRepository _resulDirectorGerentesRepository;
    private readonly IProgramacionMasivaEvaluacionesRepository _programacionMasivaEvaluacionesRepository;
    private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;
    private readonly IGetPorcentajesRepository _getPorcentajesRepository;
    private readonly ITotalIndEstCorporativosRepository _totalIndEstCorporativosRepository;
    private readonly IZonasRepository _zonasRepository;
    private readonly IOficinasRepository _oficinasRepository;
    private readonly IFuncionariosRepository _funcionariosRepository;
    private readonly IParametrosDesempenoRepository _parametrosDesempenoRepository;

    public TotalAnalisisIndiADIRepository(ConnectContext context, IMapper mapper, IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository,
        IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository, IResulDirectorGerentesRepository resulDirectorGerentesRepository, IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository,
        IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository, IGetPorcentajesRepository getPorcentajesRepository, ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository, IZonasRepository zonasRepository,
        IOficinasRepository oficinasRepository, IFuncionariosRepository funcionariosRepository, IParametrosDesempenoRepository parametrosDesempenoRepository)
    {
        _context = context;
        _mapper = mapper;
        _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
        _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
        _resulDirectorGerentesRepository = resulDirectorGerentesRepository;
        _programacionMasivaEvaluacionesRepository = programacionMasivaEvaluacionesRepository;
        _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
        _getPorcentajesRepository = getPorcentajesRepository;
        _totalIndEstCorporativosRepository = totalIndEstCorporativosRepository;
        _zonasRepository = zonasRepository;
        _oficinasRepository = oficinasRepository;
        _funcionariosRepository = funcionariosRepository;
        _parametrosDesempenoRepository = parametrosDesempenoRepository;
    }

    public async Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicosADI(Tbl_com_ProgEvaluacionModels progEvaluacion, int EmpresaId)
    {
        List<TBL_com_TotalesConsolidadoDesempenoModels> List = new List<TBL_com_TotalesConsolidadoDesempenoModels>();

        decimal sumaEstra = 0;
        //Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        Tbl_com_ProgramacionMasivaEvaluacionesModels dataProgMa = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion((long)progEvaluacion.IdPrgramacionEvaluacion);
        int nivel = (int)progEvaluacion.NivelCargo;
        int tiponivel = (int)progEvaluacion.TipoNivelEstrategico;
        Tbl_ind_PesosxTipoIndxNivelCompModels ObjNivelComp = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, nivel, 2);
        decimal pesoE = ObjNivelComp.Peso;

        decimal TIE = 0;
        int indEstra = 0;
        bool pesoEstra = false;
        List<Tbl_com_ResultadosEvaIndicadoresModels> ListResultadosIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(progEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);
        indEstra = ListResultadosIndicadores.Count();

        //verifica si tiene indicadores Estretgicos
        if (indEstra != 0)
        {
            decimal sumaPesoEstra = await _getPorcentajesRepository.GetGesSumaPesosIndiEstrategicos(progEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);
            if (sumaPesoEstra == 100)
            {
                #region Tácticos Operativos 1  || Tacticos
                if (nivel == 100 || nivel == 2)
                {
                    sumaEstra = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(progEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);
                    pesoEstra = true;

                }
                #endregion

                #region Estrategicos/Directores
                if (nivel == 1 && progEvaluacion.TipoNivelEstrategico == 2)
                {
                    //peso corporativo
                    decimal ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)progEvaluacion.TipoNivelEstrategico, 1)).Peso;
                    // peso UES1
                    decimal pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)progEvaluacion.TipoNivelEstrategico, 2)).Peso;
                    // resultado corporativo
                    decimal caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)progEvaluacion.InAno)).Total;
                    //resultado suma ponderados indicadores Estrategicos
                    decimal sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(progEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);

                    // resultado Corporativo
                    decimal dv = ptC / 100;
                    decimal totC = dv * caltC;

                    //resultado UES1
                    decimal dvUES1 = pesoUES1 / 100;
                    decimal totUES1 = dvUES1 * sumPorndeind;

                    sumaEstra = totC + totUES1;
                    pesoEstra = true;
                }
                #endregion

                #region Estrategicos/Gerentes

                if (nivel == 1 && progEvaluacion.TipoNivelEstrategico == 3)
                {
                    TBL_mast_ZonasModels ObjZona = await _zonasRepository.ObjZonas(dataProgMa.CodigoDireccion, EmpresaId);
                    int cargoResZo = ObjZona.CargoResponsable;

                    // si tiene responsable de la zona 
                    if (cargoResZo != 0)
                    {
                        // consult si tiene valor UES1 o UES2 Segun sea el caso
                        int rr;
                        List<SCP_FuncionariosModels> ObjListFuncionarios = await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, cargoResZo, true);
                        int existeFuncinCargo = ObjListFuncionarios.Count();

                        if (existeFuncinCargo != 0)
                        {

                            long cc = ObjListFuncionarios[0].Identificacion;


                            rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin)).Count();
                            if (rr != 0)
                            {
                                //peso corporativo
                                decimal ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)progEvaluacion.TipoNivelEstrategico, 1)).Peso;
                                // peso UES1
                                decimal pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)progEvaluacion.TipoNivelEstrategico, 2)).Peso;
                                //peso UES2
                                decimal pesoUES2 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)progEvaluacion.TipoNivelEstrategico, 3)).Peso;
                                // resultado corporativo
                                decimal caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)progEvaluacion.InAno)).Total;
                                //resultado suma ponderados indicadores Estrategicos
                                decimal sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(progEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);

                                // resultado Corporativo
                                decimal dv = ptC / 100;
                                decimal totC = dv * caltC;

                                //resultado UES1

                                decimal resultZo = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin))[0].Resultado;
                                decimal dvUES1 = pesoUES1 / 100;
                                decimal totUES1 = dvUES1 * resultZo;

                                progEvaluacion.IdPadre = cc;

                                progEvaluacion = await UpdateProgEvaluacion(progEvaluacion);

                                //resultado UES2
                                decimal dvUES2 = pesoUES2 / 100;
                                decimal totUES2 = dvUES2 * sumPorndeind;

                                sumaEstra = totC + totUES1 + totUES2;
                                pesoEstra = true;
                            }
                            else
                            {
                                pesoEstra = false;
                            }
                        }
                        else
                        {
                            pesoEstra = false;

                        }
                    }
                    else
                    {
                        pesoEstra = false;
                    }
                }
                #endregion
            }
            else
            {
                pesoEstra = false;
            }
        }//si no tiene indicadores verifica si es de nivel tactico
        else if (indEstra == 0 && (nivel != 1))
        {
            /// consulta el cargo responsable de la ofcina
            int codRespo = 0;
            codRespo = (await _oficinasRepository.ObjOficinas(dataProgMa.CodigoGerencia, EmpresaId)).CargoResponsable;

            // si tiene responsable
            if (codRespo != 0)
            {
                int exitFuncInCargo = (await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, codRespo, true)).Count();

                if (exitFuncInCargo != 0)
                {

                    // consulta lacedula de la parsona que ocua elcargo
                    long cc = (await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, codRespo, true))[0].Identificacion;

                    // consulta el id de la evaluacin de la persona con el cargo resposble de la oficina
                    int rr;
                    rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin)).Count();

                    if (rr != 0)
                    {
                        // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                        decimal result = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin))[0].Resultado;

                        pesoEstra = true;
                        sumaEstra = result;
                        indEstra = 1;

                    }
                    else
                    {
                        pesoEstra = false;
                        indEstra = 0;
                    }
                }
                else
                {
                    pesoEstra = false;
                    indEstra = 0;
                }

            }// si no tiene responsable de la oficina consulta el responsable de la zona
            else if (codRespo == 0)
            {
                //trea el cargo del resposable de la zona
                TBL_mast_ZonasModels ObjZona = await _zonasRepository.ObjZonas(dataProgMa.CodigoDireccion, EmpresaId);
                int cargoResZo = ObjZona.CargoResponsable;

                // si tiene responsable de la zona 
                if (cargoResZo != 0)
                {
                    List<SCP_FuncionariosModels> ObjListFuncionarios = await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, cargoResZo, true);
                    int exitFuncInCargo = ObjListFuncionarios.Count();

                    if (exitFuncInCargo != 0)
                    {

                        // trae la identificacion de la persona que ocupa el cargo resposable de la zona
                        long cc = ObjListFuncionarios[0].Identificacion;
                        // consulta la evaluacion de la persona responsable de la zona
                        int rr;
                        rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin)).Count();

                        if (rr != 0)
                        {
                            // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                            sumaEstra = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)progEvaluacion.InAno, (int)progEvaluacion.MesIni, (int)progEvaluacion.MesFin))[0].Resultado;
                            pesoEstra = true;
                            indEstra = 1;

                        }
                        else
                        {
                            pesoEstra = true;
                            indEstra = 0;
                        }
                    }
                    else
                    {
                        pesoEstra = true;
                        indEstra = 0;
                    }
                }
                else
                {
                    pesoEstra = false;
                    indEstra = 0;
                }
            }
            //si no tiene indicadores verfica si es de nivel estrategico de tipo DirectorGenreal
        }
        else if (indEstra == 0 && nivel == 1 && progEvaluacion.TipoNivelEstrategico == 1)
        {
            decimal caltC = 0;
            caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)progEvaluacion.InAno)).Total;
            sumaEstra = caltC;
            pesoE = 100;
            indEstra = 1;
            pesoEstra = true;
        }

        if (pesoE != 0)
        {
            //decimal dv = pesoE / 100;
            //decimal m = sumaEstra * dv;
            TIE = sumaEstra;
        }

        if (TIE != 0)
        {

            TBL_com_ParametrosDesempenoModels param = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(2, Decimal.Round(TIE, 2), EmpresaId);
            string parametro1 = param.Parametro;
            string col1 = param.Color;

            TBL_com_TotalesConsolidadoDesempenoModels dCD = new TBL_com_TotalesConsolidadoDesempenoModels();
            dCD.Nivel = parametro1;
            dCD.Color = col1;
            dCD.ValorAnalisis = (decimal)TIE;
            dCD.Peso = pesoE;
            dCD.Tiponivel = tiponivel;
            dCD.TipoId = nivel;
            dCD.PesoEstra = pesoEstra;
            List.Add(dCD);

        }
        else
        {
            TBL_com_TotalesConsolidadoDesempenoModels dCD = new TBL_com_TotalesConsolidadoDesempenoModels();
            dCD.Nivel = "No Especificado";
            dCD.Color = "white.png";
            dCD.ValorAnalisis = 0;
            dCD.Peso = 0;
            dCD.Tiponivel = 0;
            dCD.TipoId = 0;
            List.Add(dCD);
        }
        return List;
    }
    private async Task<Tbl_com_ProgEvaluacionModels> UpdateProgEvaluacion(Tbl_com_ProgEvaluacionModels ObjUpdate)
    {
        var UpdateRegistro = _context.TBL_com_ProgEvaluacion.FirstOrDefault(p => p.InIdEvaluacion == ObjUpdate.InIdEvaluacion);
        
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
            UpdateRegistro.Concepto = ObjUpdate.Concepto;
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

            await _context.SaveChangesAsync();
        }
        return ObjUpdate;
    }
    

}
