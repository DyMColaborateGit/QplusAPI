
using App.Models.Models.TblRgp;

namespace App.Infraestructure.IRepositories
{
    public interface ITipoAnalisisRepository
    {
        Task<List<Tbl_rgp_TipoAnalisisModels>> GetListaTipoAnalisis(int EmpresaId);

    }
}
