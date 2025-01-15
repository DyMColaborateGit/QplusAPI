using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;
using System;

namespace App.logic.Services;

public class MastIndicadoresService : IMastIndicadoresService
{
    private readonly IPesosxTipoIndxNivelCompRepository _pesosxTipoIndxNivelCompRepository;
    private readonly IResultadosEvaIndicadoresRepository _resultadosEvaIndicadoresRepository;
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IMastIndicadoresRepository _mastIndicadoresRepository;
    private readonly IProgEvaluacionSercice _progEvaluacionSercice;
    private readonly IGestEvaluacionService _gestEvaluacionService;

    public MastIndicadoresService(IPesosxTipoIndxNivelCompRepository pesosxTipoIndxNivelCompRepository,
            IResultadosEvaIndicadoresRepository resultadosEvaIndicadoresRepository,
            IProgEvaluacionRepository progEvaluacionRepository,
            IMastIndicadoresRepository mastIndicadoresRepository,
            IProgEvaluacionSercice progEvaluacionSercice, 
            IGestEvaluacionService gestEvaluacionService)
    {
        _progEvaluacionRepository = progEvaluacionRepository;
        _pesosxTipoIndxNivelCompRepository = pesosxTipoIndxNivelCompRepository;
        _resultadosEvaIndicadoresRepository = resultadosEvaIndicadoresRepository;
        _mastIndicadoresRepository = mastIndicadoresRepository;
        _progEvaluacionSercice = progEvaluacionSercice;
        _gestEvaluacionService = gestEvaluacionService;
    }

    public async Task<string> GetValueTiposdeindicadores(int EmpresaId, long EvaluacionId)
    {
        return await _gestEvaluacionService.GetTiposdeindicadores(EmpresaId, EvaluacionId);
    }

    public async Task<List<Tbl_ind_MastIndicadoresModels>> GetIndicadoresFuncionarioEstrategicos(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo)
    {
        var ResultadoDeFuncionarios = await _mastIndicadoresRepository.ListMastIndicadoresDeCargo(Identificacion,0, EmpresaId, 2,1);

        var ResultadoDeCargo =  await _mastIndicadoresRepository.ListMastIndicadoresDeCargo(0,CodigoCargo, EmpresaId,1,1);

        var ListIndicadores = ResultadoDeCargo.Union(ResultadoDeFuncionarios).Distinct().ToList<Tbl_ind_MastIndicadoresModels>();

        for (int i = 0; i < ListIndicadores.Count; i++)
        {
            int exIn = (await _resultadosEvaIndicadoresRepository.GetListResultadosEvaIndicadores(EvaluacionId)).Where(x => x.IndcadorId == ListIndicadores[i].InIdIndicador).ToList().Count();
            ListIndicadores[i].BEvaluado = exIn > 0 ? true : false;
        }

        return ListIndicadores;
    }

    public async Task<Tbl_ind_MastIndicadoresModels> PostIndicadorFuncionarioByEvaluacionId(Tbl_ind_MastIndicadoresModels ObjRequest, long EvaluacionId)
    {
        ObjRequest.InIdTipoIndicador = 3;
        ObjRequest.InIdTipoMeta = 1;
        ObjRequest.InMetaIndicador = 100;
        ObjRequest.InFrecuencia = 30;
        ObjRequest.InEstado = 1;
        ObjRequest.BRevisionGerencial = false;
        ObjRequest.ClaseId = 2;
        ObjRequest.ClaseIndicador = "Por Funcionario";
        ObjRequest.IdFuenteEstrategico = 1;
        ObjRequest.FechaCreacion = DateTime.Now;
        ObjRequest.FechaModificacion = DateTime.Now;
        ObjRequest.Descripcion = " ";
        ObjRequest.ComoSeCalcula = " ";
        ObjRequest.CodIndicador = " ";
        ObjRequest.TipoIndicadorEstrategico = 0;
        ObjRequest.Finalidad = 0;
        ObjRequest.Unidad = " ";
        ObjRequest.ObjetivoCargo = " ";
        ObjRequest.InIdResponsable = 0;
        ObjRequest.VcDenominador = " ";
        ObjRequest.VcNumerador = " ";

        Tbl_ind_MastIndicadoresModels ResultMastIndicadores = await _mastIndicadoresRepository.CreateMastIndicadores(ObjRequest);

        Tbl_com_ResultadosEvaIndicadoresModels ObjResultadosEvaIndicadores = new Tbl_com_ResultadosEvaIndicadoresModels();
        ObjResultadosEvaIndicadores.EvaluacionId = (int)EvaluacionId;
        ObjResultadosEvaIndicadores.IndcadorId = ResultMastIndicadores.InIdIndicador;
        ObjResultadosEvaIndicadores.Indicador = ResultMastIndicadores.VcNombreIndicador;
        ObjResultadosEvaIndicadores.Fecha = DateTime.Now;
        ObjResultadosEvaIndicadores.Peso = 0;
        ObjResultadosEvaIndicadores.Meta = 100;
        ObjResultadosEvaIndicadores.Real = 0;
        ObjResultadosEvaIndicadores.Ponderado = 0;
        ObjResultadosEvaIndicadores.Cumple = "No Cumple";
        ObjResultadosEvaIndicadores.PesoNext = 0;
        ObjResultadosEvaIndicadores.Editar = false;
        ObjResultadosEvaIndicadores.TipoIndi = 0;
        ObjResultadosEvaIndicadores.EnablePeso = false;
        ObjResultadosEvaIndicadores.EnableCalificacion = false;
        ObjResultadosEvaIndicadores.Color = "white.png";

        ObjResultadosEvaIndicadores = await _resultadosEvaIndicadoresRepository.CreateResultadosEvaIndicadores(ObjResultadosEvaIndicadores);
        List<JOINTbl_com_ResultadosEvaIndicadoresModels> ListIndicadores = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByDifClaseId(EvaluacionId,new int[]{6,5}, ObjRequest.EmpresaId);
        List<Tbl_com_ResultadosEvaIndicadoresModels> indiEva = await _resultadosEvaIndicadoresRepository.ListResultadosEvaIndicadoresByClaseId(EvaluacionId, new int[] { 1, 2 }, ObjRequest.EmpresaId);
        await _progEvaluacionSercice.UpdateProgEvaluacionTotalIndicadores(EvaluacionId, ListIndicadores.Count, ObjRequest.EmpresaId, indiEva);

        return ResultMastIndicadores;
    }

    public async Task<List<Tbl_ind_MastIndicadoresModels>> GetListIndicadoresFuncionarioDifClass(long EvaluacionId, int EmpresaId, long Identificacion, long CodigoCargo)
    {
        var ResultadoDeFuncionarios = await _mastIndicadoresRepository.ListMastIndicadoresDeCargoDifClass(Identificacion, 0, EmpresaId, 5, 1);

        var ResultadoDeCargo = await _mastIndicadoresRepository.ListMastIndicadoresDeCargoDifClass(0,CodigoCargo, EmpresaId, 5,1);

        var indicadores = ResultadoDeCargo.Union(ResultadoDeFuncionarios).Distinct().ToList<Tbl_ind_MastIndicadoresModels>();

        return indicadores;
    }
}
