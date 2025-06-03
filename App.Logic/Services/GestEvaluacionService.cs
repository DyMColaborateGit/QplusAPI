using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.Share;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using App.Models.Models.TblMast;
using Microsoft.EntityFrameworkCore;

namespace App.logic.Services
{
    public class GestEvaluacionService : IGestEvaluacionService
    {
        #region DependenceInjection
        private readonly IEncabezadoRepository _encabezadoRepository;
        private readonly IResultadosEvaluacionRepository _resultadosEvaluacionRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;
        private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;
        private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
        private readonly ITxtFormEvaluacionRepository _txtFormEvaluacionRepository;
        private readonly IObjetivosCalidadRepository _objetivosCalidadRepository;
        private readonly ITiposIndicadoresEstrategicosRepository _tiposIndicadoresEstrategicosRepository;
        private readonly IParametrosDesempenoRepository _parametrosDesempenoRepository;
        private readonly IResultadosRepository _resultadosRepository;
        private readonly IGetPorcentajesRepository _getPorcentajesRepository;
        private readonly IProgramacionMasivaEvaluacionesRepository _programacionMasivaEvaluacionesRepository;
        private readonly IPesosxTipoIndEstxTipoNivelEstRepository _pesosxTipoIndEstxTipoNivelEstRepository;
        private readonly ITotalIndEstCorporativosRepository _totalIndEstCorporativosRepository;
        private readonly IResulDirectorGerentesRepository _resulDirectorGerentesRepository;
        private readonly IZonasRepository _zonasRepository;
        private readonly IFuncionariosRepository _funcionariosRepository;
        private readonly IOficinasRepository _oficinasRepository;
        private readonly IConsolidadoDesempenoRepository _consolidadoDesempenoRepository;
        private readonly IResultcomTecnicasRepository _resultcomTecnicasRepository;
        private readonly INivelesdeDesempenoRepository _nivelesdeDesempenoRepository;
        private readonly IMatrizdeTalentoRepository _matrizdeTalentoRepository;
        private readonly IResultIndiCoporpRepository _resultIndiCoporpRepository;
        private readonly IEscalaEvaluacionService _escalaEvaluacionService;
        private readonly IParametrosEmpresasRepository _parametrosEmpresasRepository;
        private readonly INivelDesempenoPpalRepository _nivelDesempenoPpalRepository;

        public GestEvaluacionService(
        #region Definition
            IEncabezadoRepository encabezadoRepository,
            IResultadosEvaluacionRepository resultadosEvaluacionRepository,
            IProgEvaluacionRepository progEvaluacionRepository,
            IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository,
            IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository,
            ITxtFormEvaluacionRepository txtFormEvaluacionRepository,
            IObjetivosCalidadRepository objetivosCalidadRepository,
            ITiposIndicadoresEstrategicosRepository tiposIndicadoresEstrategicosRepository,
            IParametrosDesempenoRepository parametrosDesempenoRepository,
            IResultadosRepository resultadosRepository,
            IGetPorcentajesRepository getPorcentajesRepository,
            IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository,
            IPesosxTipoIndEstxTipoNivelEstRepository pesosxTipoIndEstxTipoNivelEstRepository,
            ITotalIndEstCorporativosRepository totalIndEstCorporativosRepository,
            IResulDirectorGerentesRepository resulDirectorGerentesRepository,
            IZonasRepository zonasRepository,
            IFuncionariosRepository funcionariosRepository,
            IOficinasRepository oficinasRepository,
            IConsolidadoDesempenoRepository consolidadoDesempenoRepository,
            IResultcomTecnicasRepository resultcomTecnicasRepository,
            INivelesdeDesempenoRepository nivelesdeDesempenoRepository,
            IMatrizdeTalentoRepository matrizdeTalentoRepository,
            IResultIndiCoporpRepository resultIndiCoporpRepository,
            IEscalaEvaluacionService escalaEvaluacionService,
            IParametrosEmpresasRepository parametrosEmpresasRepository,
            INivelDesempenoPpalRepository nivelDesempenoPpalRepository)
        #endregion
        {
            #region Declare
            _encabezadoRepository = encabezadoRepository;
            _resultadosEvaluacionRepository = resultadosEvaluacionRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
            _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
            _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
            _txtFormEvaluacionRepository = txtFormEvaluacionRepository;
            _objetivosCalidadRepository = objetivosCalidadRepository;
            _tiposIndicadoresEstrategicosRepository = tiposIndicadoresEstrategicosRepository;
            _parametrosDesempenoRepository = parametrosDesempenoRepository;
            _resultadosRepository = resultadosRepository;
            _getPorcentajesRepository = getPorcentajesRepository;
            _programacionMasivaEvaluacionesRepository = programacionMasivaEvaluacionesRepository;
            _pesosxTipoIndEstxTipoNivelEstRepository = pesosxTipoIndEstxTipoNivelEstRepository;
            _totalIndEstCorporativosRepository = totalIndEstCorporativosRepository;
            _resulDirectorGerentesRepository = resulDirectorGerentesRepository;
            _zonasRepository = zonasRepository;
            _funcionariosRepository = funcionariosRepository;
            _oficinasRepository = oficinasRepository;
            _consolidadoDesempenoRepository = consolidadoDesempenoRepository;
            _resultcomTecnicasRepository = resultcomTecnicasRepository;
            _nivelesdeDesempenoRepository = nivelesdeDesempenoRepository;
            _matrizdeTalentoRepository = matrizdeTalentoRepository;
            _resultIndiCoporpRepository = resultIndiCoporpRepository;
            _escalaEvaluacionService = escalaEvaluacionService;
            _parametrosEmpresasRepository = parametrosEmpresasRepository;
            _nivelDesempenoPpalRepository = nivelDesempenoPpalRepository;
            #endregion
        }
        #endregion

        public async Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> GetListComportamientos(long EvaluacionId)
        {
            return await _resultadosEvaluacionRepository.ListFormEvaluacionByEvaluacionId(EvaluacionId);
        }

        public async Task<GetGestEvaluacionModels> GetGestEvaluacion(long EvaluacionId, int EmpresaId)
        {
            GetGestEvaluacionModels ObjResult = new GetGestEvaluacionModels();
            ObjResult.ObjCompetencias = await _resultadosEvaluacionRepository.ListFormEvaluacionByEvaluacionId(EvaluacionId);
            ObjResult.ObjEncabezado = await _encabezadoRepository.ObjConsultEncabezadoEvaluacionByEvaluacionId(EvaluacionId);
            ObjResult.ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacionByMasivas(EvaluacionId);
            ObjResult.Gerencia = await _oficinasRepository.ObjOficinas((int)ObjResult.ObjEvaluacion.PrgramacionMasivaObj.CodigoGerencia, EmpresaId);
            ObjResult.Direccion = await _zonasRepository.ObjZonas((int)ObjResult.ObjEvaluacion.PrgramacionMasivaObj.CodigoDireccion, EmpresaId);
            ObjResult.TextosFormularios = await _txtFormEvaluacionRepository.ListTxtFormEvaluacion(EmpresaId, (int)ObjResult.ObjEvaluacion.InAno);
            return ObjResult;
        }

        public async Task<GetGestIndicadoresEvaluacionModels> GetGestIndicadoresEvaluacion(long EvaluacionId, int EmpresaId, int InAnio)
        {
            GetGestIndicadoresEvaluacionModels ObjResult = new GetGestIndicadoresEvaluacionModels();
            ObjResult.IndicadoresGestion = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByDifClaseId(EvaluacionId, new int[] { 5, 6 }, EmpresaId);
            ObjResult.IndicadoresEstrategicos = await _resultadosEvaIndicadoresRepository.ListJoinResultadosEvaIndicadoresByClaseId(EvaluacionId, new int[] { 6 }, EmpresaId);
            ObjResult.Objetivos = await _objetivosCalidadRepository.ListObjetivosCalidadByEmpresaId(EmpresaId);
            ObjResult.TiposIndicadoresEstrategicos = await _tiposIndicadoresEstrategicosRepository.ListTiposIndicadoresEstrategicosByEmpresaId(EmpresaId);
            ObjResult.ViewIndicadores = await GetTiposdeindicadores(EmpresaId, EvaluacionId);
            ObjResult.IndicadoresCorporativos = await _resultIndiCoporpRepository.ListResultadoTotalIndicadoreCorporativos(EvaluacionId, EmpresaId, InAnio);

            return ObjResult;
        }

        public async Task<string> GetTiposdeindicadores(int EmpresaId, long EvaluacionId)
        {
            var ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            bool gestion = _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, (int)ObjEvaluacion.NivelCargo, 1).Result.VisibleADI;
            bool estretegicos = _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, (int)ObjEvaluacion.NivelCargo, 2).Result.VisibleADI;
            int indEstra = _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(ObjEvaluacion.InIdEvaluacion, new int[] { 6 }, EmpresaId).Result.Count();
            return await _pesosxTipoIndxNivelCompRepository.StringValueTiposdeindicadores(EmpresaId, ObjEvaluacion, gestion, estretegicos, indEstra);
        }

        public async Task<string> PutActualizarComportamientoEvaluacion(RequestUpdateComportamiento ObjRequest, int Bcerrado)
        {
            string ResulText = "";
            int bM = 0;
            decimal prom = 0;
            string parametro = "";
            string col = "";
            decimal porc = 0;

            var objEscala = await _escalaEvaluacionService.GetEscalaByEscalaIdn(ObjRequest.Escalaid);
            int valueBcerrado = objEscala.Escala > -2 && Bcerrado == 1 ? 1 : 0;

            Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(ObjRequest.EvaluacionId);

            List<Tbl_com_ResultadosModels> getListResultados = new List<Tbl_com_ResultadosModels>();

            if (objEscala.Escala > -2)
            {
                string color = await GetColor(ObjRequest.Escala, ObjRequest.EmpresaId);

                Tbl_com_ResultadosModels getObjResultado = await _resultadosRepository.ObjResultados(ObjRequest.ResultadoIdEscala);
                getObjResultado.EscalaId = ObjRequest.Escalaid;
                getObjResultado.Escalanivel = ObjRequest.Escalanivel;
                getObjResultado.BMejoramiento = bM;
                getObjResultado.FechaEva = DateTime.Now;

                Tbl_com_ResultadosModels mod = await _resultadosRepository.UpdateResultados(getObjResultado, valueBcerrado);

                getListResultados = await _resultadosRepository.ListResultadosByEvaluacionId(ObjRequest.EvaluacionId);

                if (mod != null)
                {
                    List<Tbl_com_ResultadosModels> getListResultadosBynormaId = getListResultados.Where(x => x.NormaId == (int)ObjRequest.NormaId).ToList();

                    //verificar si ya esta consolidada la competencia en resultados evaluacion
                    //si no esta, crearla y si esta, modificarla
                    //insertar el resultado del comportamiento individual
                    if (getListResultadosBynormaId.Where(x => x.ResEscala >= 0).ToList().Count() > 0)
                    {
                        prom = getListResultadosBynormaId.Select(x => (decimal)x.ResEscala).Average();
                        SCP_ParametrosEmpresasModels parametroEmpresa = await _parametrosEmpresasRepository.ObjGetParametroEmpresaByParametroId(ObjRequest.EmpresaId, 9);

                        decimal parametroValor = parametroEmpresa.Valor.Value;
                        decimal multi = prom * 100;
                        decimal divi = multi / parametroValor;
                        porc = divi;

                        //el resultado de la suma se debe comparar con los parametros mandarselos al appCode para analisis
                        TBL_com_ParametrosDesempenoModels param = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(1, Decimal.Round(porc, 2), ObjRequest.EmpresaId);
                        parametro = param.Parametro;
                        col = param.Color;
                    }
                    else
                    {
                        prom = -1;
                        parametro = "";
                        col = "white.png";
                    }

                    try
                    {
                        Tbl_com_ResultadosEvaluacionModels exRC = await _resultadosEvaluacionRepository.ObjResultadosEvaluacionByEvaluacionIdByNormaId(ObjRequest.EvaluacionId, (int)ObjRequest.NormaId);

                        Tbl_com_ResultadosEvaluacionModels ObjResultadoEvaluacion = await _resultadosEvaluacionRepository.ObjResultadosEvaluacion(ObjRequest.ResultadoId);

                        ObjResultadoEvaluacion.NormaId = (int)ObjRequest.NormaId;
                        ObjResultadoEvaluacion.Resultado = (double)prom;
                        ObjResultadoEvaluacion.Porcentaje = (double)porc;
                        ObjResultadoEvaluacion.Nivel = parametro;
                        ObjResultadoEvaluacion.Color = col;

                        if (exRC != null)
                        {
                            //actualiza con los nuevos valores
                            Tbl_com_ResultadosEvaluacionModels modRE = await _resultadosEvaluacionRepository.UpdateResultadosEvaluacion(ObjResultadoEvaluacion);
                            ObjEvaluacion.CompEva = getListResultados.Where(x => x.BEstado == true && x.BCerrado == 1).ToList().Count();
                            ObjEvaluacion.PorEvaComp = await _getPorcentajesRepository.GetPorcentajeEvaCompetencias(ObjRequest.EvaluacionId);
                            ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

                            return "El registro fue Actualizado con éxito "+ modRE.ResultadoId;
                        }
                        else
                        {
                            //crea el registro de la norma en los resultados
                            Tbl_com_ResultadosEvaluacionModels insRE = await _resultadosEvaluacionRepository.CreaResultadosEvaluacion(ObjResultadoEvaluacion);
                            ObjEvaluacion.CompEva = getListResultados.Where(x => x.BEstado == true && x.BCerrado == 1).ToList().Count();
                            ObjEvaluacion.PorEvaComp = await _getPorcentajesRepository.GetPorcentajeEvaCompetencias(ObjRequest.EvaluacionId);
                            ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);
                            return "El registro fue Creado con éxito Id " + insRE.ResultadoId;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                string color = await GetColor(ObjRequest.Escala, ObjRequest.EmpresaId);

                Tbl_com_ResultadosModels getObjResultado = await _resultadosRepository.ObjResultados(ObjRequest.ResultadoIdEscala);
                getObjResultado.ResEscala = ObjRequest.Escala;
                getObjResultado.EscalaId = ObjRequest.Escalaid;
                getObjResultado.Escalanivel = ObjRequest.Escalanivel;
                getObjResultado.BMejoramiento = bM;
                getObjResultado.Color = color;
                getObjResultado.FechaEva = DateTime.Now;

                getObjResultado = await _resultadosRepository.UpdateResultados(getObjResultado, valueBcerrado);

                getListResultados = await _resultadosRepository.ListResultadosByEvaluacionId(ObjRequest.EvaluacionId);
                var comportamientos = getListResultados.Where(x => x.NormaId == ObjRequest.NormaId && x.ResEscala >= 0).ToList();

                int cal = 0;

                foreach (var c in comportamientos)
                {
                    if (c.ResEscala == -2)
                    {
                        cal = cal ++;
                    }
                }

                int total = comportamientos.Count();

                if (total == cal)
                {
                    int exRC = getListResultados.Where(x => x.NormaId == ObjRequest.NormaId).ToList().Count();

                    Tbl_com_ResultadosEvaluacionModels ObjResultadoEvaluacion = await _resultadosEvaluacionRepository.ObjResultadosEvaluacion(ObjRequest.ResultadoId);

                    ObjResultadoEvaluacion.NormaId = (int)ObjRequest.NormaId;
                    ObjResultadoEvaluacion.Resultado = 0;
                    ObjResultadoEvaluacion.Porcentaje = 0;
                    ObjResultadoEvaluacion.Nivel = " ";
                    ObjResultadoEvaluacion.Color = "white.png";

                    //actualiza con los nuevos valores
                    Tbl_com_ResultadosEvaluacionModels modRE = await _resultadosEvaluacionRepository.UpdateResultadosEvaluacion(ObjResultadoEvaluacion);
                    ObjEvaluacion.CompEva = getListResultados.Count();
                    ObjEvaluacion.PorEvaComp = await _getPorcentajesRepository.GetPorcentajeEvaCompetencias(ObjRequest.EvaluacionId);
                    ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

                    if (exRC > 0)
                    {
                        //actualiza con los nuevos valores
                        Tbl_com_ResultadosEvaluacionModels modREsult = await _resultadosEvaluacionRepository.UpdateResultadosEvaluacion(ObjResultadoEvaluacion);
                        ObjEvaluacion.CompEva = getListResultados.Count();
                        ObjEvaluacion.PorEvaComp = await _getPorcentajesRepository.GetPorcentajeEvaCompetencias(ObjRequest.EvaluacionId);
                        ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

                        return "El registro fue Actualizado con éxito";
                    }
                    else
                    {
                        //crea el registro de la norma en los resultados
                        Tbl_com_ResultadosEvaluacionModels insRE = await _resultadosEvaluacionRepository.CreaResultadosEvaluacion(ObjResultadoEvaluacion);
                        return "El registro fue Creado con éxito Id " + insRE.ResultadoId;
                    }

                }
            }
            return ResulText;
        }


        public async Task<GetGestVerEvaluacionModels> GetVerEvaluacion(int EmpresaId, long EvaluacionId, int TipoId, int Nivel)
        {
            GetGestVerEvaluacionModels GestVerEvaluacion = new GetGestVerEvaluacionModels();
            GestVerEvaluacion.ConsolidadoCompetencias = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, 1);
            GestVerEvaluacion.ConsolidadoRendimiento = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, 2);
            GestVerEvaluacion.TotalIndicadoresGestion = await TotalAnalisisIndicadoresGestion(EvaluacionId, EmpresaId);
            GestVerEvaluacion.TotalIndicadoresEstrategicos = await TotalAnalisisIndicadoresEstrategicos(EvaluacionId, EmpresaId);
            GestVerEvaluacion.TotalesUesOne = await GeTotalAnalisisUesOne(EvaluacionId, EmpresaId, TipoId, Nivel);
            GestVerEvaluacion.TotalesUesTwo = await GeTotalAnalisisuesTwo(EvaluacionId, EmpresaId);
            return GestVerEvaluacion;

        }

        public async Task<string> GetColor(decimal resEscala, int EmpresaId)
        {
            if (resEscala >= 0)
            {
                SCP_ParametrosEmpresasModels parametroEmpresa = await _parametrosEmpresasRepository.ObjGetParametroEmpresaByParametroId(EmpresaId, 9);
                
                decimal parametroValor = parametroEmpresa.Valor.Value;
                decimal multi = resEscala * 100;
                decimal divi = multi / parametroValor;
                decimal porc = divi;

                TBL_com_ParametrosDesempenoModels param = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(1, Decimal.Round(porc, 2), EmpresaId);

                return param.Color;
            }
            else
            {
                return "whiteRd.png";
            }
        }

        public async Task<string> PutConsolidarIndicador(RequestIndicadores ObjRequest)
        {

            Tbl_com_ResultadosEvaIndicadoresModels ObjResultado = await _resultadosEvaIndicadoresRepository.ObjResultadosEvaIndicadores(ObjRequest.ResultadoId);

            Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(ObjResultado.EvaluacionId);

            if (ObjRequest.Tipo == 1)
            {
                ObjRequest.Peso = ObjResultado.Peso;
            }
            else
            {
                ObjRequest.Real = ObjResultado.Real;
            }

            //Insertar el consolidado
            ObjResultado.Fecha = DateTime.Now;
            ObjResultado.Peso = ObjRequest.Peso;
            ObjResultado.Meta = ObjRequest.Meta;
            ObjResultado.Real = ObjRequest.Real == 0 ? ObjRequest.Resultado : ObjRequest.Real;
            ObjResultado.Ponderado = GetCalcularPonderado(ObjRequest.Peso, ObjRequest.Meta, ObjRequest.Real);
            ObjResultado.Color = ObjResultado.Real >= ObjResultado.Meta ? "green.png" : "red.png";

            ObjResultado = await _resultadosEvaIndicadoresRepository.UpdateResultadosEvaIndicadores(ObjResultado);
            List<Tbl_com_ResultadosEvaIndicadoresModels> getListResultados = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(ObjResultado.EvaluacionId);
            if (ObjResultado != null)
            {
                //actualiza con los nuevos valores
                ObjEvaluacion.IndiEva = getListResultados.Where(x => x.Ponderado != 0).ToList().Count();
                ObjEvaluacion.PorEvaIndi = await _getPorcentajesRepository.GetPorcentajeEvaluacionIndi(ObjResultado.EvaluacionId, ObjRequest.EmpresaId);
                ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);
                return "Los indicadores fueron modificados";
            }
            else
            {
                return "Error en proceso de la plataforma, por favor comunícate con los Administradores de QPlus";
            }
        }

        private static decimal GetCalcularPonderado(decimal peso, decimal meta, decimal real)
        {
            //pendiente validar si alguno de los valores puede ser cero
            decimal valor = 0;

            if (peso != 0 && meta != 0 && real != 0)
            {
                decimal divi = real / meta;
                decimal multi = divi * peso;

                valor = multi;
            }

            return valor;
        }

        public async Task<string> PostGestionResultadoIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjRequest, int EmpresaId)
        {
            List<Tbl_com_ResultadosEvaIndicadoresModels> exIn = (await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(ObjRequest.EvaluacionId)).Where(x => x.IndcadorId == ObjRequest.IndcadorId).ToList();
            if (exIn.Count() == 0)
            {
                ObjRequest.Fecha = DateTime.Now;
                ObjRequest.Peso = 0;
                ObjRequest.Meta = 100;
                ObjRequest.Real = 0;
                ObjRequest.Ponderado = 0;
                ObjRequest.Color = "white.png";
                ObjRequest.PesoNext = 0;
                ObjRequest.EnableCalificacion = true;
                ObjRequest.EnablePeso = true;

                ObjRequest = await _resultadosEvaIndicadoresRepository.CreateResultadosEvaIndicadores(ObjRequest);
                List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListIndicadores = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId(ObjRequest.EvaluacionId, EmpresaId);

                return await UpdateProgEvaluacionDatosTotalIndicadores(ObjRequest.EvaluacionId, ListIndicadores, EmpresaId);
            }
            else
            {
                await _resultadosEvaIndicadoresRepository.DeleteResultadosEvaIndicadores(exIn[0].ResultadoId, ObjRequest.EvaluacionId);
                List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListIndicadores = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId(ObjRequest.EvaluacionId, EmpresaId);
                return await UpdateProgEvaluacionDatosTotalIndicadores(ObjRequest.EvaluacionId, ListIndicadores, EmpresaId);
            }
        }

        private async Task<string> UpdateProgEvaluacionDatosTotalIndicadores(long EvaluacionId, List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListIndicadores, int EmpresaId)
        {
            List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListResultados = ListIndicadores.Where(x => new[] { 1, 2 }.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId).ToList();
            int totIndi = ListIndicadores.Where(x => !new[] { 6, 5 }.Contains(x.MastIndicadoresobj.ClaseId) && x.MastIndicadoresobj.EmpresaId == EmpresaId).ToList().Count();
            foreach (var item in ListResultados)
            {
                Tbl_com_ResultadosEvaIndicadoresModels ObjResultado = await _resultadosEvaIndicadoresRepository.ObjResultadosEvaIndicadores(item.ResultadoId);
                if (ObjResultado != null)
                {
                    ObjResultado.Peso = 0;
                    ObjResultado.Meta = 100;
                    ObjResultado.Real = 0;
                    ObjResultado.Ponderado = 0;
                    ObjResultado.Color = "white.png";

                    ObjResultado = await _resultadosEvaIndicadoresRepository.UpdateResultadosEvaIndicadores(ObjResultado);
                }
               
            }

            int tie = ListIndicadores.Where(x => x.MastIndicadoresobj.ClaseId == 6 && x.MastIndicadoresobj.EmpresaId == EmpresaId).ToList().Count();
            int t = totIndi + tie;
            int idEsC = ListIndicadores.Where(x => x.MastIndicadoresobj.ClaseId == 6 && x.Ponderado != 0 && x.MastIndicadoresobj.EmpresaId == EmpresaId).ToList().Count();
            Tbl_com_ProgEvaluacionModels ObjProevaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            ObjProevaluacion.PorEvaIndi = await _getPorcentajesRepository.GetPorcentajeEvaluacionIndi(EvaluacionId, EmpresaId);
            ObjProevaluacion.TotIndi = t;
            ObjProevaluacion.IndiEva = idEsC;
            ObjProevaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjProevaluacion);
            return "Resultado gestionado con Exito";
        }

        public async Task<List<Tbl_ind_ObjetivosCalidadModels>> GetListObjetivosCalidad(int EmpresaId)
        {
            return await _objetivosCalidadRepository.ListObjetivosCalidadByEmpresaId(EmpresaId);
        }

        public async Task<string> GestValidarAnalisisDesarrollo(long EvaluacionId, string UserName, bool Estado, int EmpresaId)
        {
            try
            {
                Tbl_com_ProgEvaluacionModels dEv = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

                // CALCULAR EL TAC
                bool varC = await GestVerificarCompetencias(dEv, EmpresaId);
                if (varC)
                {
                    List<TBL_com_ConsolidadoDesempenoModels> ConsolidadoDesempeno = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, 1);
                    int eCC = ConsolidadoDesempeno.Count();

                    if (eCC > 0)
                    {
                        if (dEv.TipoEvaluacion == 1)
                        {
                            bool verI = false;

                            if (dEv.TipoValoracionId == 1)
                            {
                                // CALCULAR EL TAR
                                verI = await GestVerificaIndicadores(dEv.InIdEvaluacion, EmpresaId, dEv);
                                dEv = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                            }
                            else
                            {
                                verI = await GestVerificaIndicadoresADA(dEv, EmpresaId);
                                dEv = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                            }

                            if (verI)
                            {
                                bool verificarTecnicas;
                                //Verificar si existen competencias tecnicas
                                List<TBL_com_ResultcomTecnicasModels> resultadoTecnicas = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(dEv.InIdEvaluacion);
                                int contTecnicas = resultadoTecnicas.Count;

                                // CALCULAR EL TAT
                                if (contTecnicas > 0)
                                {
                                    verificarTecnicas = await GestVerificarCompetenciasTecnicas(dEv, resultadoTecnicas, EmpresaId);
                                    dEv = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                                }
                                else
                                {
                                    dEv.PromTec = 0;
                                    dEv.ColorComt = "white.png";
                                    dEv.NivelComt = "";
                                    dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(dEv);
                                    verificarTecnicas = true;
                                }

                                if (verificarTecnicas)
                                {
                                    // PROMEDIO PONDERADO TAC - TAR - TAT
                                    #region Calcular nivel desempeño 
                                    List<TBL_com_ConsolidadoDesempenoModels> ConsolidadoDesempeno2 = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, 2);
                                    int eCI = ConsolidadoDesempeno2.Count();
                                    if (eCI > 0)
                                    {
                                        dEv.BEstado = Estado;
                                        dEv.UsuarioCreacion = UserName;
                                        dEv.FechaCreacion = DateTime.Now;
                                        dEv.UsuarioModificacion = UserName;
                                        dEv.FechaModificacion = DateTime.Now;
                                        decimal porceCompe;
                                        decimal porceIndi;
                                        decimal porceTec;
                                        decimal resulA;

                                        decimal porEC = decimal.Parse(dEv.PromComp.ToString());
                                        decimal porEI = decimal.Parse(dEv.PromIndi.ToString());
                                        decimal porTC = decimal.Parse(dEv.PromTec.ToString());
                                        decimal peC = (decimal)dEv.PesoCompe;
                                        decimal peI = (decimal)dEv.PesoIndi;
                                        decimal peT = (decimal)dEv.PesoTec;

                                        if (contTecnicas > 0)
                                        {// TIENE COMPETENCIAS TECNICAS
                                            porceCompe = porEC * peC / 100;
                                            porceIndi = porEI * peI / 100;
                                            porceTec = porTC * peT / 100;
                                            resulA = porceCompe + porceIndi + porceTec;
                                        }
                                        else
                                        {// NO TIENE COMPETENCIAS TECNICAS
                                            dEv = await GestRecalcularpesos(dEv);

                                            porceCompe = decimal.Parse(dEv.PromComp.ToString()) * (decimal)dEv.PesoCompe / 100;
                                            porceIndi = decimal.Parse(dEv.PromIndi.ToString()) * (decimal)dEv.PesoIndi / 100;
                                            porceTec = decimal.Parse(dEv.PromTec.ToString()) * (decimal)dEv.PesoTec / 100;
                                            resulA = porceCompe + porceIndi + porceTec;
                                        }

                                        dEv.ResultadoADI = resulA;
                                        //averiguar el nivel de competencia del funcionario y actualizar los valores en la progEvaluacion
                                        TBL_com_NivelesdeDesempenoModels niD = await _nivelesdeDesempenoRepository.ObjNivelesdeDesempeno(decimal.Round(resulA, 2), (int)dEv.NivelCargo);
                                        dEv.Nivel = niD.Nivel;
                                        dEv.DescNivel = niD.ComceptoFinal;
                                        dEv.Color = niD.Color;
                                        dEv.ColorNivelM = niD.Color;
                                        dEv.NivelM = niD.Nivel;
                                        dEv.Obs_Nivel_MapaD = "N/A";

                                        // con el nivel se optiene la ubicación y se actualizan los valores en progEvaluacion
                                        var nDP = await _nivelDesempenoPpalRepository.GetObjNivelDesempenoPpal(EmpresaId, dEv.Nivel);
                                        dEv.UbicacionMD = nDP.UbicacionMD;
                                        dEv.UbicacionMD_M = nDP.UbicacionMD;
                                        dEv.Mod_MD = false;
                                        dEv.UsuarioModNivel = "N/A";

                                        dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(dEv);
                                        if (dEv != null)
                                        {
                                            await GestCategoriaMapadeTalentosfuncionarios(dEv, EmpresaId);
                                            return "ok";
                                        }
                                        else
                                        {
                                            return "No se puede verificar el análisis porque el cruce del total de competencias y de rendimiento no corresponde a ninguna escala de Niveles de Desempeño.  Comuníquese con el administrador";
                                        }
                                    }
                                    else
                                    {
                                        return "nCI";
                                    }
                                    #endregion
                                    // FIN
                                }
                                else
                                {
                                    return "no se puede verificar el análisis porque las competencias técnicas no cumplen con los caracteres de la Observación o no están calificadas";
                                }
                            }
                            else
                            {
                                return "No se puede verificar el análisis. Verifique que la suma de los pesos de los indicadores de 100 o que haya algún indicador con %Cumplimiento 0 o si el cálculo del total de rendimiento depende de otro ADI que este realizado para el periodo activo";
                            }
                        }
                        else
                        {
                            // validar si peso indicadores gestion > 0, contador indicadores gestion = 0, sacar mensaje 


                            dEv.BEstado = Estado;
                            dEv.UsuarioCreacion = UserName;
                            dEv.UsuarioModificacion = UserName;
                            dEv.FechaModificacion = DateTime.Now;
                            dEv.FechaCierre = DateTime.Now;

                            dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(dEv);
                            if (dEv != null)
                            {
                                if (dEv.TipoValoracionId == 1)
                                {
                                    _ = GestRecalcularIndiHerencia((long)dEv.InIdEvaluado, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin, EmpresaId);// Verificar si el evaluado hereda calificacion del gerente o del director para los indicadores Estrategicos
                                }
                                await GestCategoriaMapadeTalentosfuncionarios(dEv, EmpresaId);
                                return "ok";
                            }
                            else
                            {
                                return "No se puede verificar el análisis porque el cruce del total de competencias y de rendimiento no corresponde a ninguna escala de Niveles de Desempeño.  Comuníquese con el administrador";
                            }
                        }
                    }
                    else
                    {
                        return "nCC";
                    }
                }
                else
                {
                    return "No se puede verificar el análisis debido a que no ha calificado todas las competencias o completado los caracteres de la observación.";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<Tbl_com_ProgEvaluacionModels> GestRecalcularpesos(Tbl_com_ProgEvaluacionModels Evaluacion)
        {
            decimal peC = Decimal.Round((decimal)Evaluacion.PesoCompe, 2);
            decimal peI = Decimal.Round((decimal)Evaluacion.PesoIndi, 2);

            decimal calcularpeC = (peC / (peC + peI)) * 100;
            decimal calcularpeI = (peI / (peC + peI)) * 100;
            decimal calcularpeT = 0;

            Evaluacion.PesoCompe = Decimal.Round(calcularpeC, 2);
            Evaluacion.PesoIndi = Decimal.Round(calcularpeI, 2);
            Evaluacion.PesoTec = calcularpeT;
            return await _progEvaluacionRepository.UpdateProgEvaluacion(Evaluacion);
        }

        private async Task GestRecalcularIndiHerencia(long Evaluado, int Anio, int MesIni, int MesFin, int EmpresaId)
        {
            var eva = await _progEvaluacionRepository.ListEvaluacionesHeredadas(Evaluado, EmpresaId, Anio, MesIni, MesFin);
            if (eva.Count != 0)
            {
                foreach (var e in eva)
                {
                    bool rec = await GestVerificaIndicadores(e.InIdEvaluacion, EmpresaId, e);
                    if (eva.Count != 0)
                    {
                        var evaH = await _progEvaluacionRepository.ListEvaluacionesHeredadas((long)e.InIdEvaluado, EmpresaId, Anio, MesIni, MesFin);
                        foreach (var h in evaH)
                        {
                            await GestVerificaIndicadores(h.InIdEvaluacion, EmpresaId, h);
                        }
                    }
                }
            }
        }

        private async Task<bool> GestVerificaIndicadores(long EvaluacionId, int EmpresaId, Tbl_com_ProgEvaluacionModels dEv)
        {
            decimal sumaGEs = 0, sumaEstra = 0;
            Tbl_com_ProgramacionMasivaEvaluacionesModels dataProgMa = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion((long)dEv.IdPrgramacionEvaluacion);
            int cargo = (int)dEv.CodigoCargo;
            int ofi = dataProgMa.CodigoGerencia;
            int zo = dataProgMa.CodigoDireccion;
            int nivel = (int)dEv.NivelCargo;

            decimal pesoG = (await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, nivel, 1)).Peso;
            decimal pesoE = (await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, nivel, 2)).Peso;
            decimal TIE = 0;
            decimal TIG = 0;

            //analisis de indicadores validando que la suma de los pesos es 100
            var listResultadosEvaIndicadores = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadoresByEvaluacionIdByEmpresaId(EvaluacionId, EmpresaId);
            int exIE = listResultadosEvaIndicadores.Where(x => x.Ponderado != 0).ToList().Count();
            int contInd = listResultadosEvaIndicadores.Count();

            if (contInd == exIE)
            {
                int indiGes = 0, indEstra = 0;
                //lista de indicadores de Gestion
                List<JOINTbl_com_ResultadosEvaIndicadoresModels> DataResulIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByDifClaseId(EvaluacionId, new int[] { 5, 6 }, EmpresaId);
                List<Tbl_com_ResultadosEvaIndicadoresModels> ListResulIndicadoresEstra = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(EvaluacionId, new int[] { 6 }, EmpresaId);
                indiGes = DataResulIndicadores.Count();
                // lista de indicadores de Estratégicos
                indEstra = ListResulIndicadoresEstra.Count;

                decimal sumaPesoGes = 0, sumaPesoEstra = 0;
                bool pesoges = false;
                bool pesoEstra = false;
                bool r = false;

                if (indiGes != 0)
                {
                    sumaPesoGes = await _getPorcentajesRepository.GetGestSumaPesoGestionDifClass(EvaluacionId, new int[] { 5, 6 }, EmpresaId);

                    if (sumaPesoGes == 100)
                    {
                        sumaGEs = await _getPorcentajesRepository.GetGesSumaPonderadosDifClass(EvaluacionId, new int[] { 5, 6 }, EmpresaId);
                        pesoges = true;
                    }                   
                }
                //verifica si tiene indicadores Estretegicos
                if (indEstra != 0)
                {

                    sumaPesoEstra = await _getPorcentajesRepository.GetGesSumaPesosIndiEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);
                    if (sumaPesoEstra == 100)
                    {
                        #region Tácticos Operativos 1

                        sumaEstra = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);
                        if (nivel == 100)
                        {
                            pesoEstra = true;

                        }

                        #endregion

                        #region Tacticos
                        if (nivel == 2)
                        {
                            pesoEstra = true;

                        }
                        #endregion

                        #region Estrategicos/Directores
                        if (nivel == 1 && dEv.TipoNivelEstrategico == 2)
                        {
                            decimal caltC = 0;
                            decimal ptC = 0;
                            decimal totC = 0;
                            decimal sumPorndeind = 0;
                            decimal pesoUES1 = 0;
                            decimal totUES1 = 0;

                            //peso corporativo
                            ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)dEv.TipoNivelEstrategico, 1)).Peso;
                            // peso UES1
                            pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)dEv.TipoNivelEstrategico, 2)).Peso;
                            // resultado corporativo
                            caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)dEv.InAno)).Total;
                            //resultado suma ponderados indicadores Estrategicos
                            sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);

                            // resultado Corporativo
                            decimal dv = ptC / 100;
                            totC = dv * caltC;

                            //resultado UES1
                            decimal dvUES1 = pesoUES1 / 100;
                            totUES1 = dvUES1 * sumPorndeind;

                            //insertar el resultado UES1 del director evaluado
                            TBL_Ind_ResulDirectorGerentesModels resul = new TBL_Ind_ResulDirectorGerentesModels();

                            resul.Anio = (int)dEv.InAno;
                            resul.Mesini = (int)dEv.MesIni;
                            resul.Mesfin = (int)dEv.MesFin;
                            resul.Identificacion = (long)dEv.InIdEvaluado;
                            resul.Resultado = sumPorndeind;
                            resul.Tipo = "UES1";

                            int exUEs = 0;

                            List<TBL_Ind_ResulDirectorGerentesModels> ListDirectorGerentes = await _resulDirectorGerentesRepository.ListResulDirectorGerentes((long)dEv.InIdEvaluado, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin);

                            exUEs = ListDirectorGerentes.Count();

                            if (exUEs == 0)
                            {
                                resul = await _resulDirectorGerentesRepository.CreateResulDirectorGerentes(resul);
                            }
                            else
                            {
                                resul.Resultadoid = ListDirectorGerentes[0].Resultadoid;

                                resul = await _resulDirectorGerentesRepository.UpdateResulDirectorGerentes(resul);
                            }

                            sumaEstra = totC + totUES1;
                            pesoEstra = true;
                        }
                        #endregion

                        #region Estrategicos/Gerentes

                        if (nivel == 1 && dEv.TipoNivelEstrategico == 3)
                        {
                            int cargoResZo = (await _zonasRepository.ObjZonas(zo, EmpresaId)).CargoResponsable;

                            // si tiene responsable de la zona 
                            if (cargoResZo != 0)
                            {
                                List<SCP_FuncionariosModels> ListFuncionarios = await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, cargoResZo, true);
                                int existefuncinCargo = ListFuncionarios.Count();

                                if (existefuncinCargo != 0)
                                {
                                    long cc = ListFuncionarios[0].Identificacion;
                                    // consult si tiene valor UES1 o UES2 Segun sea el caso
                                    int rr;
                                    List<TBL_Ind_ResulDirectorGerentesModels> ListDirectorGerentes = await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin);
                                    rr = ListDirectorGerentes.Count();

                                    if (rr != 0)
                                    {

                                        decimal caltC = 0;
                                        decimal ptC = 0;
                                        decimal totC = 0;
                                        decimal sumPorndeind = 0;
                                        decimal pesoUES1 = 0;
                                        decimal pesoUES2 = 0;
                                        decimal totUES1 = 0;
                                        decimal totUES2 = 0;
                                        decimal resultZo = 0;

                                        //peso corporativo
                                        ptC = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)dEv.TipoNivelEstrategico, 1)).Peso;
                                        // peso UES1
                                        pesoUES1 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)dEv.TipoNivelEstrategico, 2)).Peso;
                                        //peso UES2
                                        pesoUES2 = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, (int)dEv.TipoNivelEstrategico, 3)).Peso;
                                        // resultado corporativo
                                        caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)dEv.InAno)).Total;
                                        //resultado suma ponderados indicadores Estrategicos
                                        sumPorndeind = await _getPorcentajesRepository.GetGesSumaPonderadosEstrategicos(EvaluacionId, new int[] { 6 }, EmpresaId);

                                        // resultado Corporativo
                                        decimal dv = ptC / 100;
                                        totC = dv * caltC;

                                        //resultado UES1

                                        resultZo = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin))[0].Resultado;
                                        decimal dvUES1 = pesoUES1 / 100;
                                        totUES1 = dvUES1 * resultZo;

                                        Tbl_com_ProgEvaluacionModels ObjProgEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                                        ObjProgEvaluacion.IdPadre = cc;
                                        dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjProgEvaluacion);

                                        //resultado UES2
                                        decimal dvUES2 = pesoUES2 / 100;
                                        totUES2 = dvUES2 * sumPorndeind;

                                        //insertar el resultado UES1 del director evaluado
                                        TBL_Ind_ResulDirectorGerentesModels resul = new TBL_Ind_ResulDirectorGerentesModels();

                                        resul.Anio = (int)dEv.InAno;
                                        resul.Mesini = (int)dEv.MesIni;
                                        resul.Mesfin = (int)dEv.MesFin;
                                        resul.Identificacion = (long)dEv.InIdEvaluado;
                                        resul.Resultado = sumPorndeind;
                                        resul.Tipo = "UES2";

                                        int exUEs = 0;

                                        List<TBL_Ind_ResulDirectorGerentesModels> ListDirectorGerente = await _resulDirectorGerentesRepository.ListResulDirectorGerentes((long)dEv.InIdEvaluado, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin);
                                        exUEs = ListDirectorGerente.Count();

                                        if (exUEs == 0)
                                        {
                                            resul = await _resulDirectorGerentesRepository.CreateResulDirectorGerentes(resul);
                                        }
                                        else
                                        {
                                            resul.Resultadoid = ListDirectorGerente[0].Resultadoid;

                                            resul = await _resulDirectorGerentesRepository.UpdateResulDirectorGerentes(resul);
                                        }

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
                }//si no tiene indicadores verifica si es de nivel tactico o Tácticos Operativos 1
                else if (indEstra == 0 && (nivel != 1))
                {
                    if (pesoE != 0)
                    {
                        // consulta el cargo responsable de la oficina
                        int codRespo = 0;
                        codRespo = (await _oficinasRepository.ObjOficinas(ofi, EmpresaId)).CargoResponsable;

                        // si tiene responsable
                        if (codRespo != 0)
                        {
                            List<SCP_FuncionariosModels> ListFuncionarios = await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, codRespo, true);

                            int existeFuncInCargo = ListFuncionarios.Count();

                            if (existeFuncInCargo != 0)
                            {

                                // consulta la cedula de la parsona que ocupa el cargo
                                long cc = ListFuncionarios[0].Identificacion;

                                // consulta el id de la evaluacin de la persona con el cargo resposble de la oficina
                                List<TBL_Ind_ResulDirectorGerentesModels> ListDirectorGerentes = await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin);
                                int rr = ListDirectorGerentes.Count();

                                if (rr != 0)
                                {
                                    // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                                    decimal result = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin))[0].Resultado;

                                    pesoEstra = true;
                                    sumaEstra = result;
                                    indEstra = 1;
                                    Tbl_com_ProgEvaluacionModels ObjProgEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                                    ObjProgEvaluacion.IdPadre = cc;
                                    dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjProgEvaluacion);
                                }
                                else
                                {
                                    pesoEstra = false;
                                    indEstra = 1;
                                }
                            }
                            else
                            {
                                pesoEstra = false;
                                indEstra = 1;

                            }

                        }// si no tiene responsable de la oficina consulta el responsable de la zona
                        else if (codRespo == 0)
                        {
                            //trea el cargo del resposable de la zona
                            int cargoResZo = (await _zonasRepository.ObjZonas(zo, EmpresaId)).CargoResponsable;

                            // si tiene responsable de la zona 
                            if (cargoResZo != 0)
                            {

                                List<SCP_FuncionariosModels> ListFuncionarios = await _funcionariosRepository.ListFuncionarioByEmpresaIdByCargoId(EmpresaId, cargoResZo, true);
                                int existeFuncInCargo = ListFuncionarios.Count();

                                if (existeFuncInCargo != 0)
                                {

                                    // trae la identificacion de la persona que ocupa el cargo resposable de la zona
                                    long cc = ListFuncionarios[0].Identificacion;
                                    // consulta la evaluacion de la persona responsable de la zona
                                    List<TBL_Ind_ResulDirectorGerentesModels> ListDirectorGerentes = await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin);
                                    int rr = ListDirectorGerentes.Count();

                                    if (rr != 0)
                                    {
                                        // trae la suma de los ponderados de la evaluacion del responsable de la oficina
                                        sumaEstra = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)dEv.InAno, (int)dEv.MesIni, (int)dEv.MesFin))[0].Resultado;
                                        pesoEstra = true;
                                        indEstra = 1;
                                        Tbl_com_ProgEvaluacionModels ObjProgEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                                        ObjProgEvaluacion.IdPadre = cc;
                                        dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjProgEvaluacion);
                                    }
                                    else
                                    {
                                        pesoEstra = false;
                                        indEstra = 1;
                                    }
                                }
                                else
                                {
                                    pesoEstra = false;
                                    indEstra = 1;
                                }
                            }
                            else
                            {
                                pesoEstra = false;
                                indEstra = 1;
                            }
                        }

                    }
                    else
                    {
                        pesoEstra = false;
                        sumaEstra = 0;
                        indEstra = 0;
                    }
                    //si no tiene indicadores verfica si es de nivel estrategico de tipo DirectorGenreal
                }
                else if (indEstra == 0 && nivel == 1 && dEv.TipoNivelEstrategico == 1)
                {
                    decimal caltC = 0;
                    caltC = (await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativos(EmpresaId, (int)dEv.InAno)).Total;
                    sumaEstra = caltC;
                    pesoE = 100;
                    indEstra = 1;
                    pesoEstra = true;
                }

                if (indiGes != 0 && indEstra != 0 && pesoges && pesoEstra)
                {
                    r = true;
                }
                else if (indiGes != 0 && pesoges && indEstra == 0 && pesoEstra == false)
                {
                    r = true;
                }
                else if (indEstra != 0 && pesoEstra && indiGes == 0 && pesoges == false)
                {
                    r = true;
                }
                else
                {
                    r = false;
                }

                if (r == true)
                {
                    if (pesoG != 0)
                    {
                        decimal dv = pesoG / 100;
                        decimal m = sumaGEs * dv;
                        TIG = m;
                    }
                    if (pesoE != 0)
                    {
                        decimal dv = pesoE / 100;
                        decimal m = sumaEstra * dv;
                        TIE = m;
                    }

                    decimal TAR = TIG + TIE;

                    //el resultado de la suma se debe comparar con los parametros mandarselos al appCode para analisis
                    int param = (await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(2, Decimal.Round(TAR, 2), EmpresaId)).ParametroId;

                    TBL_com_ParametrosDesempenoModels dPD = await _parametrosDesempenoRepository.ObjParametrosDesempenoByParametroId(param);
                    string parametro1 = dPD.Parametro;
                    string col1 = dPD.Color;

                    List<TBL_com_ConsolidadoDesempenoModels> eCI = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, 2);

                    //insertar el consolidado del analisis de indicadores en la tabla de consolidados
                    TBL_com_ConsolidadoDesempenoModels dCD = new TBL_com_ConsolidadoDesempenoModels();
                    dCD.EvaluacionId = (int)EvaluacionId;
                    dCD.TipoId = 2;
                    dCD.ValorAnalisis = (decimal)Decimal.Round(TAR, 2);
                    dCD.Nivel = parametro1;
                    dCD.Color = col1;

                    if (eCI.Count() == 0)
                    {
                        TBL_com_ConsolidadoDesempenoModels insI = await _consolidadoDesempenoRepository.CreateConsolidadoDesempeno(dCD);
                    }
                    else
                    {
                        int inConsI = eCI[0].ConsolidadoId;
                        dCD.ConsolidadoId = inConsI;
                        TBL_com_ConsolidadoDesempenoModels modC = await _consolidadoDesempenoRepository.UpdateConsolidadoDesempeno(dCD);
                    }

                    Tbl_com_ProgEvaluacionModels dEI = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
                    dEI.PromIndi = (double)Decimal.Round(TAR, 2);
                    dEI.NivelIndi = parametro1;
                    dEI.ColorIndi = col1;
                    dEv = await _progEvaluacionRepository.UpdateProgEvaluacion(dEI);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> GestVerificarCompetencias(Tbl_com_ProgEvaluacionModels dEv, int EmpresaId)
        {
            decimal sumNv = 0, cont = 0;

            //validar cantidad de comportamientos
            int tCrit = (int)dEv.TotComp;
            int tCritEva = (int)dEv.CompEva;
            int bCerrado = (await _resultadosRepository.ListResultadosByEvaluacionIdByestado(dEv.InIdEvaluacion, 0)).Count();
            int bEstado =  (await _resultadosRepository.ListResultadosByEvaluacionCerrados(dEv.InIdEvaluacion, false)).Count();
            //el numero de competencias de la evaluacion es igual al numero evaluadas
            if (bEstado == 0 && tCrit == tCritEva && bCerrado == 0 )
            {
                //promedio de competencias
                List<ResponseJoinTbl_com_ResultadosEvaluacionModels> nivel = await _resultadosEvaluacionRepository.ListCompetenciasByEvaluacionId(dEv.InIdEvaluacion);

                foreach (var sn in nivel)
                {
                    if (sn.Porcentaje > 0)
                    {
                        sumNv = sumNv + (decimal)sn.Porcentaje;
                        cont++;
                    }
                }

                decimal prom = sumNv / cont;

                //el resultado de la suma se debe comparar con los parametros mandarselos al appCode para analisis

                TBL_com_ParametrosDesempenoModels dPDC = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(1, Decimal.Round(prom, 2), EmpresaId);
                string parametro = dPDC.Parametro;
                string col = dPDC.Color;
                List<TBL_com_ConsolidadoDesempenoModels> ConsolidadoDesempeno = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(dEv.InIdEvaluacion, 1);
                int eCC = ConsolidadoDesempeno.Count();

                //insertar el consolidado del analisis de indicadores en la tabla de consolidados
                TBL_com_ConsolidadoDesempenoModels dCDC = new TBL_com_ConsolidadoDesempenoModels();
                dCDC.EvaluacionId = dEv.InIdEvaluacion;
                dCDC.TipoId = 1;
                dCDC.ValorAnalisis = (decimal)Decimal.Round(prom, 2);
                dCDC.Nivel = parametro;
                dCDC.Color = col;

                dEv.PromComp = (double)Decimal.Round(prom, 2);
                dEv.NivelComp = parametro;
                dEv.ColorComp = col;

                if (eCC == 0)
                {
                    TBL_com_ConsolidadoDesempenoModels insC = await _consolidadoDesempenoRepository.CreateConsolidadoDesempeno(dCDC);
                }
                else
                {
                    dCDC.ConsolidadoId = ConsolidadoDesempeno[0].ConsolidadoId;
                    TBL_com_ConsolidadoDesempenoModels modC = await _consolidadoDesempenoRepository.UpdateConsolidadoDesempeno(dCDC);
                }

                await _progEvaluacionRepository.UpdateProgEvaluacion(dEv);

                return true;
            }
            else
            {
                return false;
            }

        }

        private async Task<bool> GestVerificarCompetenciasTecnicas(Tbl_com_ProgEvaluacionModels Dataeval, List<TBL_com_ResultcomTecnicasModels> resultadoTecnicas, int EmpresaId)
        {
            decimal sumNv = 0;
            decimal cont = 0;

            foreach (var tecnicas in resultadoTecnicas)
            {
                sumNv = sumNv + tecnicas.ResEscala;
                cont++;
            }
            SCP_ParametrosEmpresasModels parametroEmpresa = await _parametrosEmpresasRepository.ObjGetParametroEmpresaByParametroId(EmpresaId, 9);

            decimal parametroValor = parametroEmpresa.Valor.Value;
            decimal prom = sumNv / cont;
            decimal tat = prom * 100 / parametroValor;

            //el resultado de la suma se debe comparar con los parametros mandarselos al appCode para analisis
            TBL_com_ParametrosDesempenoModels dPDC = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(3, Decimal.Round(tat, 2), EmpresaId);

            // Verificar si ya existe un calculo realizado para las competencias tecnicas
            var temResulta = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(Dataeval.InIdEvaluacion, 3);
            TBL_com_ConsolidadoDesempenoModels ListResultadosDesempeno = temResulta.Count() != 0 ? temResulta[0] : new TBL_com_ConsolidadoDesempenoModels();

            //insertar el consolidado del analisis competencias tecnicas en la tabla de consolidados
            TBL_com_ConsolidadoDesempenoModels dCDC = new TBL_com_ConsolidadoDesempenoModels();
            dCDC.EvaluacionId = Dataeval.InIdEvaluacion;
            dCDC.TipoId = 3;
            dCDC.ValorAnalisis = (decimal)Decimal.Round(tat, 2);
            dCDC.Nivel = dPDC.Parametro;
            dCDC.Color = dPDC.Color;

            Dataeval.PromTec = Decimal.Round(tat, 2);
            Dataeval.ColorComt = dPDC.Color;
            Dataeval.NivelComt = dPDC.Parametro;

            if (ListResultadosDesempeno.ConsolidadoId == 0)
            {
                TBL_com_ConsolidadoDesempenoModels insC = await _consolidadoDesempenoRepository.CreateConsolidadoDesempeno(dCDC);
                if (insC != null)
                {
                    Tbl_com_ProgEvaluacionModels ObjUpdate = await _progEvaluacionRepository.UpdateProgEvaluacion(Dataeval);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                dCDC.ConsolidadoId = ListResultadosDesempeno.ConsolidadoId;
                TBL_com_ConsolidadoDesempenoModels modC = await _consolidadoDesempenoRepository.UpdateConsolidadoDesempeno(dCDC);
                if (modC != null)
                {
                    Tbl_com_ProgEvaluacionModels ObjUpdate = await _progEvaluacionRepository.UpdateProgEvaluacion(Dataeval);
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private async Task<bool> GestVerificaIndicadoresADA(Tbl_com_ProgEvaluacionModels Evaluacion, int EmpresaId)
        {
            JOINSCP_FuncionariosModels daf = await _funcionariosRepository.ObjJoinFuncionarioByEmpresaIdByIdentificacion(EmpresaId, (long)Evaluacion.InIdEvaluado);
            Tbl_com_ProgramacionMasivaEvaluacionesModels dataProgMa = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion((long)Evaluacion.IdPrgramacionEvaluacion);
            int cargo = daf.CargoId;
            int ofi = dataProgMa.CodigoGerencia;
            int zo = dataProgMa.CodigoDireccion;
            int nivel = daf.Cargoobj.GrupoCargo;
            decimal TIG = 0;

            //analisis de indicadores validando que la suma de los pesos es 100
            List<Tbl_com_ResultadosEvaIndicadoresModels> ListResultEvaindi = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(Evaluacion.InIdEvaluacion);
            int exIE = ListResultEvaindi.Where(x => x.Ponderado != 0).ToList().Count();
            int contInd = ListResultEvaindi.Count();

            if (contInd == exIE)
            {
                int indiGes = 0;

                //lista de indicadores de Gestion
                indiGes = (await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(Evaluacion.InIdEvaluacion, new int[] { 9 }, EmpresaId)).Count();

                decimal sumaPesoGes = 0;

                if (indiGes != 0)
                {
                    sumaPesoGes = await _getPorcentajesRepository.GetGesSumaPesosIndiEstrategicos(Evaluacion.InIdEvaluacion, new int[] { 9 }, EmpresaId);

                    if (sumaPesoGes == 100)
                    {
                        TIG = await _getPorcentajesRepository.GetGesSumaPesosIndiEstrategicos(Evaluacion.InIdEvaluacion, new int[] { 9 }, EmpresaId);

                    }
                }

                decimal TAR = TIG;

                //el resultado de la suma se debe comparar con los parametros mandarselos al appCode para analisis
                TBL_com_ParametrosDesempenoModels ObjParametroDesem = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(2, Decimal.Round(TAR, 2), EmpresaId);

                string parametro1 = ObjParametroDesem.Parametro;
                string col1 = ObjParametroDesem.Color;

                TBL_com_ConsolidadoDesempenoModels ObjConsolidado = (await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(Evaluacion.InIdEvaluacion, 2))[0];

                //insertar el consolidado del analisis de indicadores en la tabla de consolidados
                TBL_com_ConsolidadoDesempenoModels dCD = new TBL_com_ConsolidadoDesempenoModels();
                dCD.EvaluacionId = Evaluacion.InIdEvaluacion;
                dCD.TipoId = 2;
                dCD.ValorAnalisis = (decimal)Decimal.Round(TAR, 2);
                dCD.Nivel = parametro1;
                dCD.Color = col1;

                if (ObjConsolidado == null)
                {
                    ObjConsolidado = await _consolidadoDesempenoRepository.CreateConsolidadoDesempeno(dCD);
                }
                else
                {
                    dCD.ConsolidadoId = ObjConsolidado.ConsolidadoId;
                    ObjConsolidado = await _consolidadoDesempenoRepository.UpdateConsolidadoDesempeno(dCD);
                }

                Evaluacion.PromIndi = (double)Decimal.Round(TAR, 2);
                Evaluacion.NivelIndi = parametro1;
                Evaluacion.ColorIndi = col1;

                await _progEvaluacionRepository.UpdateProgEvaluacion(Evaluacion);

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<TBL_com_TotalesConsolidadoDesempenoModels> TotalAnalisisIndicadoresGestion(long EvaluacionId, int EmpresaId)
        {
            Tbl_com_ProgEvaluacionModels Evaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

            TBL_com_TotalesConsolidadoDesempenoModels ConsolidadoTotales = new TBL_com_TotalesConsolidadoDesempenoModels();
            decimal sumaGEs = 0;

            Tbl_ind_PesosxTipoIndxNivelCompModels PesosxTipoIndxNivelComp = await _pesosxTipoIndxNivelCompRepository.ObjPesosxTipoIndxNivelComp(EmpresaId, (int)Evaluacion.NivelCargo, 1);
            decimal pesoG = PesosxTipoIndxNivelComp.Peso;
            decimal TIG = 0;

            //analisis de indicadores validando que la suma de los pesos es 100
            bool pesoges = false;

            //lista de indicadores de Gestion
            List<Tbl_com_ResultadosEvaIndicadoresModels> ListResultadosEvaIndicadores = await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(Evaluacion.InIdEvaluacion);

            if (ListResultadosEvaIndicadores.Count() != 0)
            {
                decimal sumaPesoGes = await _getPorcentajesRepository.GetGestSumaPesoGestionDifClass(Evaluacion.InIdEvaluacion, new int[] { 5, 6 }, EmpresaId);

                if (sumaPesoGes == 100)
                {
                    sumaGEs = await _getPorcentajesRepository.GetGesSumaPonderadosDifClass(Evaluacion.InIdEvaluacion, new int[] { 5, 6 }, EmpresaId);
                    pesoges = true;
                }

                if (pesoG != 0)
                {
                    TIG = sumaGEs;
                }

                TBL_com_ParametrosDesempenoModels dPD = await _parametrosDesempenoRepository.ObjParametrosDesempenoByTipoId(2, Decimal.Round(TIG, 2), EmpresaId);

                    ConsolidadoTotales.Nivel = dPD.Parametro;
                    ConsolidadoTotales.Color = dPD.Color;
                    ConsolidadoTotales.ValorAnalisis = (decimal)TIG;
                    ConsolidadoTotales.Peso = pesoG;
                    ConsolidadoTotales.Pesoges = pesoges;

                    Evaluacion.PesoTIG = pesoG;
                    Evaluacion.PromTIG = TIG;
                    Evaluacion.ColorTIG = dPD.Color;
                    Evaluacion.NivelTIG = dPD.Parametro;

                    Evaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(Evaluacion);

            }

            return ConsolidadoTotales;
        }

        public async Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicos(long EvaluacionId, int EmpresaId)
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

        public async Task<GeneralTBL_ind_TotalIndEstCorporativosModels> GetTotalIndicadoresCorporativos(int EmpresaId, int Anio, int TipoNivelEst, int IdtipoIndicadorEst)
        {
            GeneralTBL_ind_TotalIndEstCorporativosModels ObjTotalIndEstCorporativos = await _totalIndEstCorporativosRepository.ObjTotalIndEstCorporativospeso(EmpresaId, Anio);
            TBL_ind_PesosxTipoIndEstxTipoNivelEstModels ObjPesosxTipoIndEstxTipoNivel = await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, TipoNivelEst, 1);
            ObjTotalIndEstCorporativos.Peso = ObjPesosxTipoIndEstxTipoNivel.Peso;
            return ObjTotalIndEstCorporativos;
        }

        public async Task<GeneralTotalUES> GeTotalAnalisisUesOne(long EvaluacionId, int EmpresaId, int Tipo, int Nivel)
        {
            Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            GeneralTotalUES TotalUes = new GeneralTotalUES();
            int t = 0;
            long idEVa = 0;
            long cc = 0;
            int tipoIndi = (int)ObjEvaluacion.TipoNivelEstrategico;
            decimal peso = 100;

            if (tipoIndi != 0)
            {
                peso = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, tipoIndi, 2)).Peso;
            }

            if (Nivel == 1)
            {

                if (Tipo == 1)
                {
                    t = 1;
                    idEVa = EvaluacionId;
                }
                if (Tipo == 2)
                {
                    t = 2;
                    idEVa = (await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1)).InIdEvaluacion;
                    cc = (int)ObjEvaluacion.IdPadre;
                }

            }
            if (Nivel != 1)
            {
                if (ObjEvaluacion.IdPadre == 0)
                {
                    t = 1;
                    idEVa = EvaluacionId;
                }
                else
                {
                    t = 2;
                    var DataEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacionPadre((int)ObjEvaluacion.IdPadre, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin, EmpresaId, 1, 1);
                    idEVa = DataEvaluacion.InIdEvaluacion;
                    cc = (int)ObjEvaluacion.IdPadre;
                }
                peso = (await TotalAnalisisIndicadoresEstrategicos(EvaluacionId, EmpresaId))[0].Peso;
            }

            if (t == 1)
            {
                var listInd = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(idEVa, new int[] { 6 }, EmpresaId); ;
                decimal sum = 0;
                foreach (var li in listInd)
                {
                    sum += li.Ponderado;
                }


                TotalUes.Total = sum;
                TotalUes.peso = peso;

            }
            else
            {
                decimal res = (await _resulDirectorGerentesRepository.ListResulDirectorGerentes(cc, (int)ObjEvaluacion.InAno, (int)ObjEvaluacion.MesIni, (int)ObjEvaluacion.MesFin))[0].Resultado;
                TotalUes.Total = res;
                TotalUes.peso = peso;
            }
            return TotalUes;
        }

        public async Task<GeneralTotalUES> GeTotalAnalisisuesTwo(long EvaluacionId, int EmpresaId)
        {
            GeneralTotalUES To = new GeneralTotalUES();
            Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
            int tipoIndi = (int)ObjEvaluacion.TipoNivelEstrategico;
            decimal peso = 100;

            if (tipoIndi != 0)
            {
                peso = (await _pesosxTipoIndEstxTipoNivelEstRepository.ObjPesosxTipoIndEstxTipoNivelEst(EmpresaId, tipoIndi, 2)).Peso;
            }

            var listInd = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadores(EvaluacionId);
            decimal sum = 0;
            foreach (var li in listInd)
            {
                sum += li.Ponderado;
            }

            To.Total = sum;
            To.peso = peso;
            return To;
        }
    
        private async Task<Tbl_com_ProgEvaluacionModels> GestCategoriaMapadeTalentosfuncionarios(Tbl_com_ProgEvaluacionModels ProgEvaluacion, int EmpresaId)
        {
            TBL_com_MatrizdeTalentosModels ObjCatgoriaMapaTalento = await _matrizdeTalentoRepository.CategoriaMatrizdeTalentos(decimal.Parse(ProgEvaluacion.PromComp.ToString()), decimal.Parse(ProgEvaluacion.PromIndi.ToString()), EmpresaId);
            if (ObjCatgoriaMapaTalento is object)
            {
                ProgEvaluacion.NumeroMapaTalento = ObjCatgoriaMapaTalento.NumeroCaja;
                ProgEvaluacion.ColorMapaTalento = ObjCatgoriaMapaTalento.Color;
                ProgEvaluacion.CajaMapaTalento = ObjCatgoriaMapaTalento.NombreCaja;
                ProgEvaluacion.NumeroMapaTalentoM = ObjCatgoriaMapaTalento.NumeroCaja;
                ProgEvaluacion.ColorMapaTalentoM = ObjCatgoriaMapaTalento.Color;
                ProgEvaluacion.CajaMapaTalentoM = ObjCatgoriaMapaTalento.NombreCaja;
                ProgEvaluacion.Mod_MT = false;
                ProgEvaluacion.Obs_Mod_MapaT = "N/A";

            }
            else
            {
                ProgEvaluacion.NumeroMapaTalento = 0;
                ProgEvaluacion.ColorMapaTalento = "white.png";
                ProgEvaluacion.CajaMapaTalento = "0";
                ProgEvaluacion.NumeroMapaTalentoM = 0;
                ProgEvaluacion.ColorMapaTalentoM = "white.png";
                ProgEvaluacion.CajaMapaTalentoM = "0";
                ProgEvaluacion.Mod_MT = false;
                ProgEvaluacion.Obs_Mod_MapaT = "N/A";
            }
            return await _progEvaluacionRepository.UpdateProgEvaluacion(ProgEvaluacion);
        }
    }
}
