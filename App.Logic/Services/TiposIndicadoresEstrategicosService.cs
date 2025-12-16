using App.Infraestructure.IRepositories;
using App.Infraestructure.Repositories;
using App.logic.IServices;
using App.Models.Models.Scp;
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
        public async Task<TBL_ind_TiposIndicadoresEstrategicosModels> GetDataTiposIndicadoresEstrategicosByTipo(int EmpresaId, int idTipoIndiEstra)
        {
            return await _tiposIndicadoresEstrategicosRepository.GetDataTiposIndicadoresEstrategicosByTipo(EmpresaId, idTipoIndiEstra);
        }
        public async Task<List<TBL_ind_TiposIndicadoresEstrategicosModels>> GetListTiposIndicadoresEstrategicos(int EmpresaId)
        {
            return await _tiposIndicadoresEstrategicosRepository.ListTiposIndicadoresEstrategicosByEmpresaId(EmpresaId);
        }
    }
}
