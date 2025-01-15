using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IGetPorcentajesRepository
    {

        Task<double> GetPorcentajeEvaluacionIndi(long EvaluacionId, int EmpresaId);

        Task<double> GetPorcentajeEvaCompetencias(long EvaluacionId);

        Task<decimal> GetGesSumaPesosIndiGestion(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<decimal> GetGesSumaPesosIndiEstrategicos(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<decimal> GetGestSumaPesoGestionDifClass(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<decimal> GetGesSumaPonderadosEstrategicos(long EvaluacionId, int[] ClaseId, int EmpresaId);

        Task<decimal> GetGesSumaPonderadosDifClass(long EvaluacionId, int[] ClaseId, int EmpresaId);

    }
}
