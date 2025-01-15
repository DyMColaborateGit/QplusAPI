using App.Models.Models.Scp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface IFuncionariosService
{
    Task<SCP_FuncionariosModels> GetObjFuncionarioByIdentificacion(int EmpresaId, long Identificacion);

    Task<JOINSCP_FuncionariosModels> GetJoinFuncionarioByIdentificacion(int EmpresaId, long Identificacion);
}
