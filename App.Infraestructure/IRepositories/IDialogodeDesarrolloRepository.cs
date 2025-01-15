using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories
{
    public interface IDialogodeDesarrolloRepository
    {
        Task<List<TBL_com_DialogodeDesarrolloModels>> ListDialogodeDesarrollo(int EmpresaId, long FuncionarioId, long Lider, int Anio);

        Task<TBL_com_DialogodeDesarrolloModels> ObjDialogodeDesarrolloById(int IdDialogo);
    }
}
