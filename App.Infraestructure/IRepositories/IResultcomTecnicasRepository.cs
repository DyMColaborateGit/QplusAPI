using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IResultcomTecnicasRepository
{
    Task<List<TBL_com_ResultcomTecnicasModels>> ListResultcomTecnicasModelsByEvaluacionId(long EvaluacionId);

    Task<TBL_com_ResultcomTecnicasModels> CreateResultcomTecnicas(TBL_com_ResultcomTecnicasModels objCreate, int EmpresaId);

    Task<TBL_com_ResultcomTecnicasModels> UpdateResultcomTecnicas(TBL_com_ResultcomTecnicasModels ObjUpdate);

    Task<string> DeleteResultcomTecnicas(long ResultadoId);
}
