using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;

namespace App.logic.Services
{
    public class EmpresasService: IEmpresasService
    {
        private readonly IEmpresasRepository _empresasRepository;

        public EmpresasService(IEmpresasRepository empresasRepository)
        {
            _empresasRepository = empresasRepository;
        }

        public async Task<List<SCP_EmpresasModels>> GetListEmpresa()
        {
            return await _empresasRepository.ListEmpresa();
        }

        public async Task<SCP_EmpresasModels> GetEmpresaByempresaId(int EmpresaId)
        {
            return await _empresasRepository.ObjEmpresa(EmpresaId);
        }
    }
}
