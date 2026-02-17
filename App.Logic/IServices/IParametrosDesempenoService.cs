using App.Models.Models.TblCom;

namespace App.logic.IServices;

public interface IParametrosDesempenoService
{
    Task<TBL_com_ParametrosDesempenoModels> GetDataParametroDesempenoByMaxValor(int TipoId);
    Task<List<TBL_com_ParametrosDesempenoModels>> GetListParametrosDesempeno(int EmpresaId);
}
