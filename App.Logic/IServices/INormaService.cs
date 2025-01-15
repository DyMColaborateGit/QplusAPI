using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface INormaService
    {
        Task<List<JOINTBL_com_NivelesCargoCompModels>> GetListNormasJoinNivelesCargoComp(int EmpresaId, int CargoId);
        Task<List<Tbl_com_NormasModels>> GetListNormasByEstado(int EmpresaId, bool Estado);
    }
}
