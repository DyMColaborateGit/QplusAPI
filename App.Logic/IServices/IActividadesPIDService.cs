using App.Models.Models.TblCom;
using App.Models.Models.TblGhu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IActividadesPIDService
    {
        Task<TBL_com_ActividadesPIDModels> GetObjActividadesPDI(int EmpresaId);
        Task<List<TBL_com_ActividadesPIDModels>> GetListaActividadesPDI(int EmpresaId);
        Task<TBL_com_ActividadesPIDModels> PostCreatenewActividadPID(TBL_com_ActividadesPIDModels ObjRequest);

    }
}
