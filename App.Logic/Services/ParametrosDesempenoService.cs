using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services;

public class ParametrosDesempenoService : IParametrosDesempenoService
{
    private readonly IParametrosDesempenoRepository _parametrosDesempenoRepository;


    public ParametrosDesempenoService(IParametrosDesempenoRepository parametrosDesempenoRepository)
    {
        _parametrosDesempenoRepository = parametrosDesempenoRepository;
    }

    public async Task<TBL_com_ParametrosDesempenoModels> GetDataParametroDesempenoByMaxValor(int TipoId)
    {
        return await _parametrosDesempenoRepository.GetDataParametroDesempenoByMaxValor(TipoId);
    }
    public async Task<List<TBL_com_ParametrosDesempenoModels>> GetListParametrosDesempeno(int EmpresaId)
    {
        return await _parametrosDesempenoRepository.GetListParametrosDesempeno(EmpresaId);
    }
}
