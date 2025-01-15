using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface ITiposActividadService
    {
        Task<List<TBL_com_TiposActividadModels>> GetListTiposActividadByCtegoriaIdEstado(int EmpresaId, int CategoriaId, bool Estado);
    }
}
