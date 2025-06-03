using App.Models.Models.TblCom;
using System;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface INivelDesempenoPpalService
{
    //Task<TBL_com_NivelesDesempenoPpalModels> GetObjNivelDesempenoPpal(int EmpresaId, string Nivel);
    Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListNivelDesempenoPpal(int EmpresaId, int InAnio);

    Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListConsolidadoNivelDesempeno(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId);

    Task<List<TBL_com_NivelesDesempenoPpalModels>> GetListConsolidadoNivelDesempenoM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoNivelesDesempenoPpal(int EmpresaId, int UbicacionMD, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoNivelesDesempenoPpalM(int EmpresaId, int UbicacionMD_M, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId);



}
