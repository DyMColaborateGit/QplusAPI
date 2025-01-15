using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblInd;
using System;

namespace App.logic.Services
{
    public class TiposIndicadoresEstrategicosService: ITiposIndicadoresEstrategicosService
    {
        private readonly ITiposIndicadoresEstrategicosRepository _tiposIndicadoresEstrategicosRepository;

        public TiposIndicadoresEstrategicosService(ITiposIndicadoresEstrategicosRepository tiposIndicadoresEstrategicosRepository)
        {
            _tiposIndicadoresEstrategicosRepository = tiposIndicadoresEstrategicosRepository;
        }

        public async Task<List<TBL_ind_TiposIndicadoresEstrategicosModels>> GetListTiposIndicadoresEstrategicos(int EmpresaId)
        {
            return await _tiposIndicadoresEstrategicosRepository.ListTiposIndicadoresEstrategicosByEmpresaId(EmpresaId);
        }
    }
}
