using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories;

public interface IUsuariosRolesRepository
{
    Task<List<ResponseSCP_UsuariosRolesModels>> ListUsuariosRoles(int EmpresaId, string NomRole);
}
