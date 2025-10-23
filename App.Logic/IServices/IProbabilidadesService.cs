using App.Models.Models.TblRgp;
namespace App.logic.IServices;

public interface IProbabilidadesService
{
    Task<List<Tbl_rgp_ProbabilidadesModels>> GetListaProbabilidades(int EmpresaId);
}
