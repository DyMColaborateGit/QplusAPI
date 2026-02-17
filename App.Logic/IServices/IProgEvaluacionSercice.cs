using App.Models.Global;
using App.Models.Models.FileMove;
using App.Models.Models.Share;
using App.Models.Models.TblCom;

namespace App.logic.IServices;

public interface IProgEvaluacionSercice 
{
    Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesByParametrosBasicos(int EmpresaId, int InAnio, int MesInicio, int MesFinal);

    Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesByParametros(int EmpresaId, int InAnio, int MesInicio, int MesFinal, int DireccionId, int OficinaId);

    Task<List<Tbl_com_ProgEvaluacionModels>> GetListEvaluacionesFuncionarioByParametros(int EmpresaId, int InAnio, long EvaluadoId);

    Task<Tbl_com_ProgEvaluacionModels> GetObjProgEvaluacion(long EvaluacionId);

    Task<List<Tbl_com_ProgEvaluacionModels>> GetListaProgEvaluacionByEvaluacionId(int EvaluacionId);

    Task<string> GetCerrarEvaluacion(long EvaluacionId, int EmpresaId, int Caracteres);

    Task<string> GetConceptoFinalEval(RequestConceptoFinal ConceptoFinal);

    Task<string> PutUpdateEvaluador(long EvaluacionId, long Evaluador, long Usuariomod);

    Task<string> PutUpdateObservacionGeneral(long EvaluacionId, string Observacion);

    Task<string> PutUpdateObsModMapaT(long EvaluacionId, string ObsModMapaT);

    Task<string> PutUpdateModMT(long EvaluacionId, bool ModMT);

    Task<string> PutUpdateCajaMapaTalentoM(long EvaluacionId, int NumeroMapaTalentoM, string CajaMapaTalentoM, string ColorMapaTalentoM);

    Task<string> PutUpdateObsModMapaDesempeno(long EvaluacionId, string obsNivelMapaD);

    Task<string> PutUpdateCajaMapaDesempenoM(long EvaluacionId, int UbicacionMD_M, string NivelM, string ColorNivelM);

    Task<string> PutUpdateModMD(long EvaluacionId, bool Mod_MD);

    Task<string> PutUpdateUsuarioModNivel(long EvaluacionId, string UsuarioModNivel);

    Task<Tbl_com_ProgEvaluacionModels> UpdateProgEvaluacionTotalIndicadores(long EvaluacionId, int TotIndi, int EmpresaId, List<Tbl_com_ResultadosEvaIndicadoresModels> IndicadoresEvaluacion);

    //Task<string> GeneradorBodyADIByEvaluacionId(FilePdfADIPdiModel pdiAdiObj);
}
