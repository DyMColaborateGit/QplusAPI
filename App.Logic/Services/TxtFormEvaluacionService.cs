using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;

namespace App.logic.Services
{
    public class TxtFormEvaluacionService: ITxtFormEvaluacionService
    {
        private readonly ITxtFormEvaluacionRepository _txtFormEvaluacionRepository;

        public TxtFormEvaluacionService(ITxtFormEvaluacionRepository txtFormEvaluacionRepository) 
        {
            _txtFormEvaluacionRepository = txtFormEvaluacionRepository;
        }

        public async Task<Tbl_com_TxtFormEvaluacionModels> GetObjTxtFormEvaluacion(int EmpresaId, int Tipotexto, int Tipovaloracion, int Anio)
        {
            return await _txtFormEvaluacionRepository.ObjTxtFormEvaluacion(EmpresaId, Tipotexto, Tipovaloracion, Anio);
        }
    }
}
