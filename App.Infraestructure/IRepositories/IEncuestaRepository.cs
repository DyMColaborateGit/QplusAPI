using App.Models.Models.TblCom;
using System;

namespace App.Infraestructure.IRepositories;

public interface IEncuestaRepository
{
    Task<TBL_com_EncuestaModels> ObjEncuesta(int IdEncuesta);

    Task<TBL_com_EncuestaModels> UpdateEncuesta(TBL_com_EncuestaModels ObjUpdate);
}
