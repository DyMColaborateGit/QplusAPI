
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories;
public interface IEvaluacionRiesgoRepository
{
    Task<List<Tbl_rgp_EvaluacionRiesgoModels>> GetListaEvaluacionRiesgo(int EmpresaId);
}
