
using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models;

namespace App.logic.Services
{
    public class LinkRelacionadoActividadesPIDService : ILinkRelacionadoActividadesPIDService
    {
        private readonly ILinkRelacionadoActividadesPIDRepository _linkRelacionadoActividadesPIDRepository;

        public LinkRelacionadoActividadesPIDService(ILinkRelacionadoActividadesPIDRepository LinkRelacionadoActividadesPIDRepository)
        {
            _linkRelacionadoActividadesPIDRepository = LinkRelacionadoActividadesPIDRepository;
        }
        public async Task<List<LinkRelacionadoActividadesPIDModels>> GetListaLinkRelacionadoActividadesPID(int EmpresaId, int InIdActividadPID)
        {
            return await _linkRelacionadoActividadesPIDRepository.GetListaLinkRelacionadoActividadesPID(EmpresaId, InIdActividadPID);
        }
    }
}
