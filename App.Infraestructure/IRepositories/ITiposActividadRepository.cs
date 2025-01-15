using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface ITiposActividadRepository
    {
        Task<List<TBL_com_TiposActividadModels>> ListTiposActividadByCtegoriaIdEstado(int EmpresaId, int CategoriaId, bool Estado);
    }
}
