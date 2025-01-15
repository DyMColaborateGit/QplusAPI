using App.Models.Models.TblCom;
using System;

namespace App.logic.IServices;

public interface IEncuestaPreguntaService
{
    Task<List<JOIN_tbl_com_EncuestaPreguntaModels>> GetListEncuestaPregunta(int EmpresaId, int IdEncuesta);

    Task<TBL_com_EncuestaPreguntaModels> PutUpdateEncuestaPregunta(TBL_com_EncuestaPreguntaModels ObjRequest);

    Task<string> GetValidateEstadoEncuesta(int EmpresaId, int IdEncuesta);
}
