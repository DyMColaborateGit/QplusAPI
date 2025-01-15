using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;

namespace App.logic.Services
{
    public class EmpresasTitulosService: IEmpresasTitulosService
    {
        private readonly IEmpresasTitulosRepository _empresasTitulosRepository;

        public EmpresasTitulosService(IEmpresasTitulosRepository empresasTitulosRepository)
        {
            _empresasTitulosRepository = empresasTitulosRepository;
        }

        public async Task<List<SCP_EmpresasTitulosModels>> GetListEmpresasTitulos()
        {
            return await _empresasTitulosRepository.ListEmpresasTitulos();
        }

        public async Task<SCP_EmpresasTitulosModels> GetEmpresasTitulosByempresaId(int EmpresaId)
        {
            return await _empresasTitulosRepository.ObjEmpresasTitulos(EmpresaId);
        }
    }
}
