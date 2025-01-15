using App.Models.Models.TblInd;
using System;

namespace App.Infraestructure.IRepositories;

public interface IResulDirectorGerentesRepository
{
    Task<List<TBL_Ind_ResulDirectorGerentesModels>> ListResulDirectorGerentes(long Identificacion, int Anio, int Mesini, int Mesfin);

    Task<TBL_Ind_ResulDirectorGerentesModels> CreateResulDirectorGerentes(TBL_Ind_ResulDirectorGerentesModels objCreate);

    Task<TBL_Ind_ResulDirectorGerentesModels> UpdateResulDirectorGerentes(TBL_Ind_ResulDirectorGerentesModels ObjUpdate);
}
