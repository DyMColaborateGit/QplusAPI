using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services;

public class EncabezadoEvaService : IEncabezadoEvaService
{
    private readonly IEncabezadoRepository _encabezadoRepository;
    public EncabezadoEvaService(IEncabezadoRepository encabezadoRepository)
    {
        _encabezadoRepository = encabezadoRepository;
    }

    /// <summary>
    /// GetObjEncabezadoEvaluacionByEvaluacionId
    /// </summary>
    public async Task<ResponseEncabezadoEvaModels> GetObjEncabezadoEvaluacionByEvaluacionId(long EvaluacionId)
    {
        ResponseEncabezadoEvaModels Result = await _encabezadoRepository.ObjEncabezadoEvaluacionByEvaluacionId(EvaluacionId);
        Result.Fecha = DateTime.Now.ToString("yyyy-MM-dd").ToString();

        return Result;
    }
}
