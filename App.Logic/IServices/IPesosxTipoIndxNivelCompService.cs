using App.Models.Models.TblAud;
using App.Models.Models.TblInd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.IServices;

public interface IPesosxTipoIndxNivelCompService
{
    Task<Tbl_ind_PesosxTipoIndxNivelCompModels> GetPesosxTipoIndxNivelComp(int EmpresaId, int Nivel, int IdTipoIndicador);
}
