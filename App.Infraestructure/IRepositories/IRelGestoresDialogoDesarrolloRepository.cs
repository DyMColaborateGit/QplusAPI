using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface IRelGestoresDialogoDesarrolloRepository
    {
        Task<TBL_com_RelGestoresDialogoDesarrolloModels> GetGestoresLiderByFuncionarioByGestorId(int EmpresaId, long FuncionarioId, long GestorId, string TipoRel);
    }
}
