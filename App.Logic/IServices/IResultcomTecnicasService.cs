using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices;

public interface IResultcomTecnicasService
{
    Task<List<TBL_com_ResultcomTecnicasModels>> GetListResultcomTecnicasModelsByEvaluacionId(long EvaluacionId);

    Task<TBL_com_ResultcomTecnicasModels> PostCrearcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjCreate, int EmpresaId);

    Task<TBL_com_ResultcomTecnicasModels> PutModificarcompetenciastecnicas(TBL_com_ResultcomTecnicasModels ObjCreate);

    Task<string> DeleteResultcomTecnicas(TBL_com_ResultcomTecnicasModels ObjModificar);

    Task<string> GetVerificarcomptecnicas(long EvaluacionId);

    Task<string> GetVerificarcomptecnicasCerradas(long EvaluacionId);

    Task<string> GetVerificarVerFormularioTecnicas(int EmpresaId);
}
