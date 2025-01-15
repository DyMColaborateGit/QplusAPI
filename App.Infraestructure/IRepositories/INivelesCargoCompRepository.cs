using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface INivelesCargoCompRepository
    {
        Task<List<JOINTBL_com_NivelesCargoCompModels>> ListNivelesCargoCompByCargoId(int EmpresaId, int CargoId);
    }
}
