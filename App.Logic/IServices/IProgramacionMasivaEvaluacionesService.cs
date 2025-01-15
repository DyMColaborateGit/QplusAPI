using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices;

public interface IProgramacionMasivaEvaluacionesService
{
    Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> GetObjProgramacionMasivaEvaluaciones(long IdProgramacion);
}
