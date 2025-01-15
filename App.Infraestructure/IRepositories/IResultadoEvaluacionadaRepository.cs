using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IResultadoEvaluacionadaRepository
    {
        Task<TBL_com_ResultadoEvaluacionADAModels> ObjResultadoEvaluacionada(long IdResultado);
        Task<List<TBL_com_ResultadoEvaluacionADAModels>> ListResultadoEvaluacionadaByEvaluacionId(long EvaluacionId);

        Task<List<TBL_com_ResultadoEvaluacionADAModels>> ListResultadoEvaluacionadaByIdHijoByEvaluacionId(long EvaluacionId, int IdHijo);

        Task<List<TBL_com_ResultadoEvaluacionADAModels>> UpdateListResultadoEvaluacionada(List<TBL_com_ResultadoEvaluacionADAModels> ObjUpdate);

        Task<TBL_com_ResultadoEvaluacionADAModels> UpdateResultadoEvaluacionada(TBL_com_ResultadoEvaluacionADAModels ObjUpdate);
    }
}
