using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface INormaRepository
    {
        Task<List<Tbl_com_NormasModels>> ListNormasByEstado(int EmpresaId, bool Estado);
    }
}
