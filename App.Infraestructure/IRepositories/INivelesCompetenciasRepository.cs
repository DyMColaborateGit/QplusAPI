using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories
{
    public interface INivelesCompetenciasRepository
    {
        Task<TBL_com_NivelesCompetenciasModels> ObjNivelesCompetencias(double ValorComp, double ValorInd);
    }
}
