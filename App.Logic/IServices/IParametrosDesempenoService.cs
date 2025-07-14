using App.Models.Models.TblCom;

namespace App.logic.IServices;

public interface IParametrosDesempenoService
{
    Task<List<TBL_com_ParametrosDesempenoModels>> GetListParametrosDesempeno(int EmpresaId);
}
