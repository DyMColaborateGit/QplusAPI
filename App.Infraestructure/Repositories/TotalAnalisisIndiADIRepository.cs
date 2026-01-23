

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
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IResulDirectorGerentesRepository _resulDirectorGerentesRepository;

    public TotalAnalisisIndiADIRepository(ConnectContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TBL_com_TotalesConsolidadoDesempenoModels> TotalAnalisisIndicadoresEstrategicosADI(long EvaluacionId, int EmpresaId)
    {
        List<TBL_com_TotalesConsolidadoDesempenoModels> List = new List<TBL_com_TotalesConsolidadoDesempenoModels>();

        decimal sumaEstra = 0;
        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        Tbl_com_ProgramacionMasivaEvaluacionesModels dataProgMa = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion((long)ObjEvaluacion.IdPrgramacionEvaluacion);
        int nivel = (int)ObjEvaluacion.NivelCargo;
        int tiponivel = (int)ObjEvaluacion.TipoNivelEstrategico;
        Tbl_ind_PesosxTipoIndxNivelCompModels ObjNivelComp = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, nivel, 2);
        decimal pesoE = ObjNivelComp.Peso;

        decimal TIE = 0;
        int indEstra = 0;
        bool pesoEstra = false;
        List<Tbl_com_ResultadosEvaIndicadoresModels> ListResultadosIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(EvaluacionId, new int[] { 6 }, EmpresaId);
        indEstra = ListResultadosIndicadores.Count();

        //verifica si tiene indicadores Estretgicos
        if (indEstra != 0)
        {
            decimal sumaPesoEstra = await _getPorcentajesRepository.GetGesSumaPesosIndiEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);
            if (sumaPesoEstra == 100)
            {
                #region Tácticos Operativos 1  || Tacticos
                if (nivel == 100 || nivel == 2)
                {
                    sumaEstra = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);
                    pesoEstra = true;

                }
                #endregion

                #region Estrategicos/Directores
                if (nivel == 1 && ObjEvaluacion.TipoNivelEstrategico == 2)
                {
                    //peso corporativo
                    decimal ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)ObjEvaluacion.TipoNivelEstrategico, 1)).Peso;
                    // peso UES1
                    decimal pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)ObjEvaluacion.TipoNivelEstrategico, 2)).Peso;
                    // resultado corporativo
                    decimal caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)ObjEvaluacion.InAno)).Total;
                    //resultado suma ponderados indicadores Estrategicos
                    decimal sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);

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

                if (nivel == 1 && ObjEvaluacion.TipoNivelEstrategico == 3)
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


                            rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin)).Count();
                            if (rr != 0)
                            {
                                //peso corporativo
                                decimal ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)ObjEvaluacion.TipoNivelEstrategico, 1)).Peso;
                                // peso UES1
                                decimal pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)ObjEvaluacion.TipoNivelEstrategico, 2)).Peso;
                                //peso UES2
                                decimal pesoUES2 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)ObjEvaluacion.TipoNivelEstrategico, 3)).Peso;
                                // resultado corporativo
                                decimal caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)ObjEvaluacion.InAno)).Total;
                                //resultado suma ponderados indicadores Estrategicos
                                decimal sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(ObjEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId);

                                // resultado Corporativo
                                decimal dv = ptC / 100;
                                decimal totC = dv * caltC;

                                //resultado UES1

                                decimal resultZo = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin))[0].Resultado;
                                decimal dvUES1 = pesoUES1 / 100;
                                decimal totUES1 = dvUES1 * resultZo;

                                ObjEvaluacion.IdPadre = cc;
                                ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

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
                    rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin)).Count();

                    if (rr != 0)
                    {
                        // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                        decimal result = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin))[0].Resultado;

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
                        rr = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin)).Count();

                        if (rr != 0)
                        {
                            // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                            sumaEstra = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin))[0].Resultado;
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
        else if (indEstra == 0 && nivel == 1 && ObjEvaluacion.TipoNivelEstrategico == 1)
        {
            decimal caltC = 0;
            caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)ObjEvaluacion.InAno)).Total;
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
}
