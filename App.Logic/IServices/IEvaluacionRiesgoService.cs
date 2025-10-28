
using App.Models.Models.TblRgp;

namespace App.logic.IServices;
public interface IEvaluacionRiesgoService
{
    Task<List<Tbl_rgp_EvaluacionRiesgoModels>> GetListaEvaluacionRiesgo();

}
