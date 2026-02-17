
using App.Models.Models;

namespace App.Infraestructure.IRepositories
{
    public interface ILinkRelacionadoActividadesPIDRepository
    {
        Task<List<LinkRelacionadoActividadesPIDModels>> GetListaLinkRelacionadoActividadesPID(int EmpresaId, int InIdActividadPID);
    }
}
