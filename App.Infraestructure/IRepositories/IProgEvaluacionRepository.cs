using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IProgEvaluacionRepository
{
    Task<Tbl_com_ProgEvaluacionModels> ObjProgEvaluacion(long evaluacionId);

    Task<ResponseTbl_com_ProgEvaluacionModels> ObjProgEvaluacionByMasivas(long evaluacionId);

    Task<List<Tbl_com_ProgEvaluacionModels>> ListEvaluacionesAnio(int Anio, int TipoEvaluacion);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesTalentosFuncionarios(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, int Numeromapatalento, string EvaluadorId, long EvaluadoId, bool BEstado);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesTalentosFuncionariosM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, int NumeromapatalentoM, string EvaluadorId, long EvaluadoId, bool BEstado);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesAnioEvaluadorId(int Anio, long EvaluadorId);

    Task<Tbl_com_ProgEvaluacionModels> UpdateProgEvaluacion(Tbl_com_ProgEvaluacionModels ObjUpdate);

    Task<Tbl_com_ProgEvaluacionModels> ObjProgEvaluacionPadre(long InIdEvaluado, int Anio, int MesIni, int MesFin, int EmpresaId, int TipoEvaluacion, int TipoValoracionId);

    Task<List<Tbl_com_ProgEvaluacionModels>> ListEvaluacionesHeredadas(long Evaluado, int EmpresaId, int Anio, int MesIni, int MesFin);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesNivelesDesempeno(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, int UbicacionMD, string EvaluadorId, long EvaluadoId, bool BEstado);

    Task<List<ResponseTbl_com_ProgEvaluacionModels>> ListEvaluacionesNivelesDesempenoM(int EmpresaId, int InAnio, int ZonaId, int OficinaId, int ProcesoId, int UbicacionMD_M, string EvaluadorId, long EvaluadoId, bool BEstado);


}
