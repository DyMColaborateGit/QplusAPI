using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEncuestaPreguntaRepository
{
    Task<TBL_com_EncuestaPreguntaModels> ObjEncuestaPregunta(int IdEncuestaPregunta);

    Task<List<JOIN_tbl_com_EncuestaPreguntaModels>> ListEncuestaPregunta(int EmpresaId, int IdEncuesta);

    Task<TBL_com_EncuestaPreguntaModels> UpdateEncuestaPregunta(TBL_com_EncuestaPreguntaModels ObjUpdate);

}
