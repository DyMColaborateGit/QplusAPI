using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services;

public class ResultcomTecnicasService: IResultcomTecnicasService
{
    private readonly IResultcomTecnicasRepository _resultcomTecnicasRepository;
    private readonly IAspectosValoracionRepository _aspectosValoracionRepository;
    private readonly IEscalaEvaluacionRepository _escalaEvaluacionRepository;

    public ResultcomTecnicasService(IResultcomTecnicasRepository resultcomTecnicasRepository, IAspectosValoracionRepository aspectosValoracionRepository, IEscalaEvaluacionRepository escalaEvaluacionRepository)
    {
        _resultcomTecnicasRepository = resultcomTecnicasRepository;
        _aspectosValoracionRepository = aspectosValoracionRepository;
        _escalaEvaluacionRepository = escalaEvaluacionRepository;
    }

    public async Task<List<TBL_com_ResultcomTecnicasModels>> GetListResultcomTecnicasModelsByEvaluacionId(long EvaluacionId)
    {
        var ListResult = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(EvaluacionId);
        return ListResult;
    }

    public async Task<TBL_com_ResultcomTecnicasModels> PostCrearcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjCreate, int EmpresaId)
    {
        var ListResult = await _resultcomTecnicasRepository.CreateResultcomTecnicas(ObjCreate, EmpresaId);
        return ListResult;
    }

    public async Task<TBL_com_ResultcomTecnicasModels> PutModificarcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjModificar)
    {
        var ObjEscala = await _escalaEvaluacionRepository.EscalaByEscalaId(ObjModificar.EscalaId);
        ObjModificar.ResEscala = ObjEscala.Escala;
        ObjModificar.EscalaNivel = ObjEscala.Nivel;
        ObjModificar.Color = ObjEscala.Color;
        ObjModificar.BCerrado = ObjEscala.Escala == -2 ? 0 : ObjModificar.BCerrado;
        var ListResult = await _resultcomTecnicasRepository.UpdateResultcomTecnicas(ObjModificar);
        return ListResult;
    }

    public async Task<string> DeleteResultcomTecnicas(TBL_com_ResultcomTecnicasModels ObjModificar)
    {
        var ListResult = await _resultcomTecnicasRepository.DeleteResultcomTecnicas(ObjModificar.ResultadoId);
        return ListResult;
    }

    public async Task<string> GetVerificarcomptecnicas(long EvaluacionId)
    {
        var ListResult = await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(EvaluacionId);
        return ListResult.Count == 0? "true":"false";
    }

    public async Task<string> GetVerificarcomptecnicasCerradas(long EvaluacionId)
    {
        var ListResult = (await _resultcomTecnicasRepository.ListResultcomTecnicasModelsByEvaluacionId(EvaluacionId)).Where(x => x.BCerrado == 0).ToList();
        return ListResult.Count == 0 ? "true" : "false";
    }

    public async Task<string> GetVerificarVerFormularioTecnicas(int EmpresaId)
    {
        var ListResult = await _aspectosValoracionRepository.ExisteAspectosValoracion(EmpresaId,3,true);
        return ListResult.ToString();
    }
}
