using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using System;

namespace App.logic.Services
{
    public class UsuariosRolesService: IUsuariosRolesService
    {
        private readonly IUsuariosRolesRepository _usuariosRolesRepository;

        public UsuariosRolesService(IUsuariosRolesRepository usuariosRolesRepository)
        {
            _usuariosRolesRepository = usuariosRolesRepository;
        }

        public async Task<List<ResponseSCP_UsuariosRolesModels>> GetListUsuariosRoles(int EmpresaId, string NomRole)
        {
            return await _usuariosRolesRepository.ListUsuariosRoles(EmpresaId, NomRole);
        }
    }
}
