using App.Models.Models.TblGhu;

namespace App.Infraestructure.IRepositories
{
    public interface IPreguntasBrechaPRepository
    {
        Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaP(int EmpresaId);
        Task<List<Tbl_ghu_PreguntasBrechaPModels>> GetListaPreguntasBrechaPByTemaId(int TemaBrechaId);
    }
}
