using App.Models.Models;
using App.Models.Models.TblCom;

namespace App.logic.IServices
{
    public interface ILinkRelacionadoActividadesPIDService
    {
        Task<List<LinkRelacionadoActividadesPIDModels>> GetListaLinkRelacionadoActividadesPID(int EmpresaId, int InIdActividadPID);
    }
}
