using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IActividadesPIDService
    {
        Task<TBL_com_ActividadesPIDModels> PostCreatenewActividadPID(TBL_com_ActividadesPIDModels ObjRequest);
    }
}
