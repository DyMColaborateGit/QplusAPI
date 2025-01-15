using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services
{
    public class EscalaEvaluacionService: IEscalaEvaluacionService
    {
        private readonly IEscalaEvaluacionRepository _escalaEvaluacionRepository;

        public EscalaEvaluacionService(IEscalaEvaluacionRepository escalaEvaluacionRepository)
        {
            _escalaEvaluacionRepository = escalaEvaluacionRepository;
        }

        public async Task<List<Tbl_com_EscalaEvaluacionModels>> GetListEscalasByAspectoId(int EmpresaId, long AspectoId)
        {
            return await _escalaEvaluacionRepository.ListEscalasByAspectoId(EmpresaId, AspectoId);
        }

        public async Task<List<Tbl_com_EscalaEvaluacionModels>> GetListEscalasEvaluacion(int EmpresaId)
        {
            return await _escalaEvaluacionRepository.ListEscalasEvaluacion(EmpresaId);
        }

        public async Task<Tbl_com_EscalaEvaluacionModels> GetEscalaByEscalaIdn(int EscalaId)
        {
            return await _escalaEvaluacionRepository.EscalaByEscalaId(EscalaId);
        }
    }
}
