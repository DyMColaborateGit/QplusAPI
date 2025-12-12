using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.Scp;
using App.Models.Models.TblCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.logic.Services
{
    public class ResultadosService : IResultadosService
    {
        private readonly IResultadosRepository _resultadosRepository;


        public ResultadosService(IResultadosRepository ResultadosRepository)
        {
            _resultadosRepository = ResultadosRepository;
        }

        public async Task<List<Tbl_com_ResultadosModels>> GetResultadosEvaluacionListaByEvaluacionId(int EvaluacionId, int NormaId)
        {
            return await _resultadosRepository.GetResultadosEvaluacionListaByEvaluacionId(EvaluacionId, NormaId);
        }
    }
}
