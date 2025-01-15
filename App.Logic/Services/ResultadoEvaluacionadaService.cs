using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services;

public class ResultadoEvaluacionadaService: IResultadoEvaluacionadaService
{
    private readonly IResultadoEvaluacionadaRepository _resultadoEvaluacionadaRepository;

    public ResultadoEvaluacionadaService(IResultadoEvaluacionadaRepository resultadoEvaluacionadaRepository)
    {
        _resultadoEvaluacionadaRepository = resultadoEvaluacionadaRepository; ;
    }

    public async Task<List<TBL_com_ResultadoEvaluacionADAModels>> GetListResultadoEvaluacionadaByEvaluacionId(long EvaluacionId)
    {
        var resultados = await _resultadoEvaluacionadaRepository.ListResultadoEvaluacionadaByEvaluacionId(EvaluacionId);
        return resultados;
    }


    public async Task<List<TBL_com_ResultadoEvaluacionADAModels>> PutResultadoEvaluacionadaByEvaluacionId(long EvaluacionId, int IdHijo, long IdResultado)
    {
        var ObjResultado = await _resultadoEvaluacionadaRepository.ObjResultadoEvaluacionada(IdResultado);
        ObjResultado.Resultado = true;
        var UpdateObjResultado = await _resultadoEvaluacionadaRepository.UpdateResultadoEvaluacionada(ObjResultado);

        List<TBL_com_ResultadoEvaluacionADAModels> resultados = await _resultadoEvaluacionadaRepository.ListResultadoEvaluacionadaByIdHijoByEvaluacionId(EvaluacionId, IdHijo);
        resultados = resultados.Where(x => x.Resultado == false).ToList();
        resultados.ForEach(x => x.Resultado = false);
        var result = await _resultadoEvaluacionadaRepository.UpdateListResultadoEvaluacionada(resultados);

        result.Add(UpdateObjResultado);

        return result;
    }

    public async Task<TBL_com_ResultadoEvaluacionADAModels> PutResultadoEvaluacionadaTxt(TBL_com_ResultadoEvaluacionADAModels ObjPut)
    {
        TBL_com_ResultadoEvaluacionADAModels objResultado = await _resultadoEvaluacionadaRepository.ObjResultadoEvaluacionada(ObjPut.IdResultado);
        objResultado.ResultadoTxt = ObjPut.ResultadoTxt;
        objResultado.Resultado = ObjPut.Resultado;
        TBL_com_ResultadoEvaluacionADAModels resultados = await _resultadoEvaluacionadaRepository.UpdateResultadoEvaluacionada(objResultado);

        return resultados;
    }

}
