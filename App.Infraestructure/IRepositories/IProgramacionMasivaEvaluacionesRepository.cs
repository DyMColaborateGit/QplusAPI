using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IProgramacionMasivaEvaluacionesRepository
{
    Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> ObjProgramacionMasivaEvaluacionesByIdProgramacion(long IdProgramacion);

    Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> Update_ProgramacionMasivaEvaluaciones(Tbl_com_ProgramacionMasivaEvaluacionesModels ObjUpdate);
}
