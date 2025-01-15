using App.Models.Models.T;
using App.Models.Models.TblDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices
{
    public interface IAreasService
    {
        Task<List<AreasModels>> GetListMacroProcesos(int EmpresaId);
    }
}
