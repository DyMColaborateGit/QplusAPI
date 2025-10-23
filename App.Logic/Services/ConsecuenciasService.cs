
using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.TblRgp;

namespace App.logic.Services
{
    public class ConsecuenciasService : IConsecuenciasService
    {
        private readonly IConsecuenciasRepository _consecuenciasRepository;

        public ConsecuenciasService(IConsecuenciasRepository consecuenciasRepository)
        {
            _consecuenciasRepository = consecuenciasRepository;
        }

        public async Task<List<Tbl_rgp_ConsecuenciasModels>> GetListaConsecuencias(int EmpresaId)
        {
            return await _consecuenciasRepository.GetListaConsecuencias(EmpresaId);
        }
        public async Task<Tbl_rgp_ConsecuenciasModels> GetObjConsecuenciaByEmpresaIdByValor(int EmpresaId, int Valor)
        {
            return await _consecuenciasRepository.GetObjConsecuenciaByEmpresaIdByValor(EmpresaId, Valor);
        }
    }
}
