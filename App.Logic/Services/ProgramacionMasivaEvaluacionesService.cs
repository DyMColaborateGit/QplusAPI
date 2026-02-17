using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services;

public class ProgramacionMasivaEvaluacionesService : IProgramacionMasivaEvaluacionesService
{
    private readonly IProgramacionMasivaEvaluacionesRepository _programacionMasivaEvaluacionesRepository;

    public ProgramacionMasivaEvaluacionesService(IProgramacionMasivaEvaluacionesRepository programacionMasivaEvaluacionesRepository)
    {
        _programacionMasivaEvaluacionesRepository = programacionMasivaEvaluacionesRepository;
    }
    public async Task<Tbl_com_ProgramacionMasivaEvaluacionesModels> GetObjProgramacionMasivaEvaluaciones(long IdProgramacion)
    {
        var getResult = await _programacionMasivaEvaluacionesRepository.ObjProgramacionMasivaEvaluacionesByIdProgramacion(IdProgramacion);
        return getResult;
    }
    public async Task<ResponseTbl_com_ProgramacionMasivaEvaluacionesModels> GetDataProgramacionByID(int IdProgramacion)
    {
        var getResult = await _programacionMasivaEvaluacionesRepository.GetDataProgramacionByID(IdProgramacion);
        return getResult;
    }
}
