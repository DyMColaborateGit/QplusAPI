using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class ConsolidadoDesempenoService: IConsolidadoDesempenoService
    {
        private readonly IConsolidadoDesempenoRepository _consolidadoDesempenoRepository;

        public ConsolidadoDesempenoService(IConsolidadoDesempenoRepository consolidadoDesempenoRepository)
        {
            _consolidadoDesempenoRepository = consolidadoDesempenoRepository;
        }

        public async Task<List<TBL_com_ConsolidadoDesempenoModels>> GetListConsolidadoDesempeno(long EvaluacionId, int Tipo)
        {
            var lista = await _consolidadoDesempenoRepository.ListConsolidadoDesempeno(EvaluacionId, Tipo);

            return lista;
        }
        public async Task<List<TBL_com_ConsolidadoDesempenoModels>> GetListaConsolidadosByEvaluacionId(int EvaluacionId)
        {
            var lista = await _consolidadoDesempenoRepository.GetListaConsolidadosByEvaluacionId(EvaluacionId);

            return lista;
        }
    }
}
