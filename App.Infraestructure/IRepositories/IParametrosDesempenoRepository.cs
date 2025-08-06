using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructure.IRepositories;

public interface IParametrosDesempenoRepository
{
    Task<List<TBL_com_ParametrosDesempenoModels>> GetListParametrosDesempeno(int EmpresaId);
    Task<TBL_com_ParametrosDesempenoModels> ObjParametrosDesempenoByParametroId(long ParametroId);
    Task<TBL_com_ParametrosDesempenoModels> ObjParametrosDesempenoByTipoId(int TipoId, Decimal Valor, int EmpresaId);
}
