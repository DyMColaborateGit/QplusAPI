using App.Models.Models.Share;
using App.Models.Models.TblCom;
using App.Models.Models.TblInd;

namespace App.logic.IServices
{
    public interface IGestEvaluacionService
    {
        Task<List<ResponseJoinTbl_com_ResultadosEvaluacionModels>> GetListComportamientos(long EvaluacionId);

        Task<GetGestEvaluacionModels> GetGestEvaluacion(long EvaluacionId, int EmpresaId);

        Task<GetGestIndicadoresEvaluacionModels> GetGestIndicadoresEvaluacion(long EvaluacionId, int EmpresaId, int InAnio);

        Task<string> GetTiposdeindicadores(int EmpresaId, long EvaluacionId);

        Task<string> PutActualizarComportamientoEvaluacion(RequestUpdateComportamiento ObjRequest, int Bcerrado);

        Task<string> PutConsolidarIndicador(RequestIndicadores ObjRequest);

        Task<string> PostGestionResultadoIndicadores(Tbl_com_ResultadosEvaIndicadoresModels ObjRequest, int EmpresaId);

        Task<List<Tbl_ind_ObjetivosCalidadModels>> GetListObjetivosCalidad(int EmpresaId);

        Task<string> GestValidarAnalisisDesarrollo(long EvaluacionId, string UserName, bool Estado, int EmpresaId);

        Task<TBL_com_TotalesConsolidadoDesempenoModels> TotalAnalisisIndicadoresGestion(long EvaluacionId, int EmpresaId);

        Task<List<TBL_com_TotalesConsolidadoDesempenoModels>> TotalAnalisisIndicadoresEstrategicos(long EvaluacionId, int EmpresaId);

        Task<GeneralTBL_ind_TotalIndEstCorporativosModels> GetTotalIndicadoresCorporativos(int EmpresaId, int Anio, int TipoNivelEst, int IdtipoIndicadorEst);

        Task<GeneralTotalUES> GeTotalAnalisisUesOne(long EvaluacionId, int EmpresaId, int Tipo, int Nivel);

        Task<GeneralTotalUES> GeTotalAnalisisuesTwo(long EvaluacionId, int EmpresaId);

        Task<GetGestVerEvaluacionModels> GetVerEvaluacion(int EmpresaId, long EvaluacionId, int TipoId, int Nivel);
    }
}
