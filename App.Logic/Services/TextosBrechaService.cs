using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblGhu;

namespace App.logic.Services
{
    public class TextosBrechaService : ITextosBrechaService
    {
        private readonly ITextosBrechaRepository _textosBrechaRepository;

        public TextosBrechaService(ITextosBrechaRepository textosBrechaRepository)
        {
            _textosBrechaRepository = textosBrechaRepository;
        }

        public async Task<List<Tbl_ghu_TextosBrechaModels>> GetListaTextosBrecha(int EmpresaId)
        {
            return await _textosBrechaRepository.GetListaTextosBrecha(EmpresaId);
        }
    }
}
