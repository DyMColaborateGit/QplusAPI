using App.Models.Models.TblCom;
using System;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface IMatrizdeTalentoService
{
    Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListMatrizdeTalentos(int EmpresaId, int Codmatriz);

    Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListConsolidadoMatrizdeTalentos(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId);
    Task<List<ResponseTBL_com_MatrizdeTalentosModels>> GetListConsolidadoMatrizdeTalentosM(int EmpresaId, int Codmatriz, int InAnio, int ZonaId, int OficinaId, int ProcesoId, string EvaluadorId, long EvaluadoId);
    Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListEvaluacionesAnioEvaluadorId(int Anio, long EvaluadorId);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoMatrizdeTalentos(int EmpresaId, int NumeroCaja, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId);
    Task<List<ResponseTbl_com_ProgEvaluacionModels>> FiltroListConsolidadoMatrizdeTalentosM(int EmpresaId, int NumeromapatalentoM, int InAnio, int ZonaId, int OficinaId, string EvaluadorId, long EvaluadoId);

    Task<int> GestUpdateMatrizdeTalentosFuncionarios(int Anio, int EmpresaId);
}
