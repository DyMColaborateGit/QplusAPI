using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Share;
using App.Models.Models.TblCom;

namespace App.logic.Services;

public class ResultadosEvaluacionService : IResultadosEvaluacionService
{
    private readonly IResultadosEvaluacionRepository _competenciasRepository;
    private readonly IResultadosRepository _resultadosRepository;
    private readonly IProgEvaluacionRepository _progEvaluacionRepository;
    private readonly IGetPorcentajesRepository _getPorcentajesRepository;

    public ResultadosEvaluacionService(IResultadosEvaluacionRepository competenciasRepository, IResultadosRepository resultadosRepository, IProgEvaluacionRepository progEvaluacionRepository, IGetPorcentajesRepository getPorcentajesRepository)
    {
        _competenciasRepository = competenciasRepository;
        _resultadosRepository = resultadosRepository;
        _progEvaluacionRepository = progEvaluacionRepository;
        _getPorcentajesRepository = getPorcentajesRepository;
    }

    public async Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> GetListCompetenciasByEvaluacionId(long EvaluacionId)
    {
        var competencias   = await _competenciasRepository.ListFormEvaluacionByEvaluacionId(EvaluacionId);
        return competencias;
    }

    public async Task<Tbl_com_ResultadosEvaluacionModels> PutResultadoEvaluacionObservacion(long EvaluacionId, RequestUpdateObservaciones ObjPut)
    {
        Tbl_com_ResultadosEvaluacionModels objResultado = await _competenciasRepository.ObjResultadosEvaluacionByEvaluacionIdByNormaId(EvaluacionId, ObjPut.NormaId);
        objResultado.Observaciones = ObjPut.Observacion;

        Tbl_com_ResultadosEvaluacionModels resultados = await _competenciasRepository.UpdateResultadosEvaluacion(objResultado);

        List<Tbl_com_ResultadosModels> listResultados = await _resultadosRepository.ListResultadosByEvaluacionIdByNormaId(EvaluacionId, ObjPut.NormaId);

        foreach (var mod in listResultados)
        {
            bool bestado = mod.ResEscala > 0 ? true : false;
            mod.BCerrado = ((resultados.Observaciones.Length >= ObjPut.Caracteres) && bestado) ? 1 : 0;
            mod.BEstado = bestado;
            await _resultadosRepository.UpdateResultados(mod, mod.BCerrado);
        }

        Tbl_com_ProgEvaluacionModels ObjEvaluacion = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);
        List<Tbl_com_ResultadosModels> getListResultados = await _resultadosRepository.ListResultadosByEvaluacionId(EvaluacionId);
        ObjEvaluacion.CompEva = getListResultados.Where(x => x.BEstado == true && x.BCerrado == 1).ToList().Count();
        ObjEvaluacion.PorEvaComp = await _getPorcentajesRepository.GetPorcentajeEvaCompetencias(EvaluacionId);
        ObjEvaluacion = await _progEvaluacionRepository.UpdateProgEvaluacion(ObjEvaluacion);

        return resultados;
    }
}
