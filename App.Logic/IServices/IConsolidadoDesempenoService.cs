using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IConsolidadoDesempenoService
    {
        Task<List<TBL_com_ConsolidadoDesempenoModels>> GetListConsolidadoDesempeno(long EvaluacionId, int Tipo);
    }
}
