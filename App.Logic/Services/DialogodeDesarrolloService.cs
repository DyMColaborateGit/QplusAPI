using App.Infraestructure.IRepositories;
using App.logic.IServices;
using App.Models.Models.TblCom;
using System;

namespace App.logic.Services
{
    public class DialogodeDesarrolloService: IDialogodeDesarrolloService
    {
        private readonly IDialogodeDesarrolloRepository _dialogodeDesarrolloRepository;
        private readonly IProgEvaluacionRepository _progEvaluacionRepository;
        private readonly IRelGestoresDialogoDesarrolloRepository _relGestoresDialogoDesarrolloRepository;

        public DialogodeDesarrolloService(IDialogodeDesarrolloRepository dialogodeDesarrolloRepository, IProgEvaluacionRepository progEvaluacionRepository, IRelGestoresDialogoDesarrolloRepository relGestoresDialogoDesarrolloRepository)
        {
            _dialogodeDesarrolloRepository = dialogodeDesarrolloRepository;
            _progEvaluacionRepository = progEvaluacionRepository;
            _relGestoresDialogoDesarrolloRepository = relGestoresDialogoDesarrolloRepository;
        }

        public async Task<List<TBL_com_DialogodeDesarrolloModels>> GetListDialogodeDesarrollo(int EmpresaId, long FuncionarioId, long Lider, int Anio)
        {
            return await _dialogodeDesarrolloRepository.ListDialogodeDesarrollo(EmpresaId, FuncionarioId, Lider, Anio);
        }

        public async Task<List<TBL_com_DialogodeDesarrolloModels>> GetListDialogodedesarrolloByevaluacionId(int EmpresaId, long EvaluacionId)
        {
            List<TBL_com_DialogodeDesarrolloModels> Dialogo = new List<TBL_com_DialogodeDesarrolloModels>();
            Tbl_com_ProgEvaluacionModels dEv = await _progEvaluacionRepository.ObjProgEvaluacion(EvaluacionId);

             var GestorLider = _relGestoresDialogoDesarrolloRepository.GetGestoresLiderByFuncionarioByGestorId(EmpresaId, (long)dEv.InIdEvaluado, (long)dEv.InIdEvaluador, "L");

            if (GestorLider is object)
            {
                Dialogo = await _dialogodeDesarrolloRepository.ListDialogodeDesarrollo(EmpresaId, (long)dEv.InIdEvaluado, -1, (int)dEv.InAno);
            }
            else
            {
                Dialogo = await _dialogodeDesarrolloRepository.ListDialogodeDesarrollo(EmpresaId, (long)dEv.InIdEvaluado, (long)dEv.InIdEvaluador, (int)dEv.InAno);
            }
            return Dialogo;
        }

        public async Task<TBL_com_DialogodeDesarrolloModels> GetObjDialogodeDesarrolloById(int IdDialogo)
        {
            return await _dialogodeDesarrolloRepository.ObjDialogodeDesarrolloById(IdDialogo);
        }
    }
}
